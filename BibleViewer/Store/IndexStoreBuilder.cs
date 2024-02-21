using BibleViewer.Query;
using BibleViewer.Store.Dic;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Index.Extensions;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Util;
using System;
using System.IO;

namespace BibleViewer.Store
{
    public interface IIndexStore : IDisposable
    {
        const string ID_FIELD_NAME = "__id__";

        bool ReadOnly { get; }

        IIndexInput NewInput(string id);

        void Search(ISearchQuery query, Action<Document> handler);

        void Put(IIndexInput input);

        void Commit();

        void MaybeRefresh();

        int NumDocs { get; }

        void ForceMerge(int maxNumSegments);

        void Close();
    }

    public sealed class IndexStoreBuilder
    {
        private Analyzer analyzer = new StandardAnalyzer(LuceneVersion.LUCENE_48);
        private bool readOnly = false;

        public IndexStoreBuilder SetAnalyzer(Analyzer analyzer) 
        {
            this.analyzer = analyzer;
            return this;
        }

        public IndexStoreBuilder SetReadOnly(bool readOnly) 
        {  
            this.readOnly = readOnly; 
            return this; 
        }

        public IIndexStore Build(DirectoryInfo dir)
        {
            return new IndexStore(dir, this);
        }

        private sealed class IndexStore : IIndexStore
        {
            public IndexStore(DirectoryInfo dir, IndexStoreBuilder builder)
            {
                directory = NIOFSDirectory.Open(dir);
                analyzer = builder.analyzer;
                readOnly = builder.readOnly;
                if (!readOnly)
                    CreateWriter();
                searcherManager = new SearcherManager(directory, null);
                if (!dir.Exists)
                    dir.Create();
                FileInfo df = dir.GetFileInfo("types.dict");
                indexTypeStore = new DictionaryStoreBuilder<IndexType>().Build(df, new DictionaryValueCodec());
            }

            private readonly FSDirectory directory;
            private readonly Analyzer analyzer;
            private readonly bool readOnly;
            private IndexWriterConfig config;
            private IndexWriter writer;
            private SearcherManager searcherManager;
            private readonly IDictionaryStore<IndexType> indexTypeStore;

            private sealed class DictionaryValueCodec : IDictionaryValueCodec<IndexType>
            {
                public IndexType Decode(string s)
                {
                    return Enum.Parse<IndexType>(s);
                }

                public string Encode(IndexType value)
                {
                    return Enum.GetName(value);
                }
            }

            private void CreateWriter()
            {
                config = new IndexWriterConfig(LuceneVersion.LUCENE_48, analyzer);
                config.SetOpenMode(OpenMode.CREATE_OR_APPEND);
                config.SetRAMBufferSizeMB(1);
                TieredMergePolicy policy = new TieredMergePolicy();
                config.MergePolicy = policy;
                writer = new IndexWriter(directory, config);
                writer.Commit();
            }

            private IndexWriter Writer
            {
                get
                {
                    lock(this)
                    {
                        if (writer.IsClosed)
                        {
                            try
                            {
                                CreateWriter();
                            } catch (Exception) { }
                        }
                        return writer;
                    }
                }
            }

            public void Search(ISearchQuery query, Action<Document> handler)
            {
                LuceneQueryMaker maker = new LuceneQueryMaker(indexTypeStore, analyzer);
                query.Accept(maker);
                Console.WriteLine(maker.Query.ToString());
                IndexSearcher searcher = searcherManager.Acquire();
                SearchCollector collector = new SearchCollector(searcher, handler);
                searcher.Search(maker.Query, collector);
                searcherManager.Release(searcher);
            }

            public bool ReadOnly => readOnly;

            public int NumDocs
            {
                get
                {
                    lock (this)
                    {
                        using DirectoryReader reader = DirectoryReader.Open(directory);
                        return reader.NumDocs;
                    }
                }
            }

            public IIndexInput NewInput(string id)
            {
                if (readOnly)
                    throw new Exception("read only");
                Document doc = new Document();
                doc.Add(new StringField(IIndexStore.ID_FIELD_NAME, id, Field.Store.YES));
                return new IndexInput(doc, indexTypeStore);
            }

            public void Put(IIndexInput input)
            {
                if (readOnly)
                    throw new Exception("read only");
                Writer.AddDocument(input.Doc);
            }

            public void Commit()
            {
                if (readOnly)
                    throw new Exception("read only");
                Writer.Commit();
                searcherManager.MaybeRefresh();
            }

            public void MaybeRefresh()
            {
                if (!readOnly)
                    throw new Exception("must be called on read-only");
                searcherManager.MaybeRefresh();
            }

            public void ForceMerge(int maxNumSegments)
            {
                Writer.ForceMerge(maxNumSegments);
            }

            public void Close()
            {
                Dispose(true);
            }

            private bool disposedValue;

            private void Dispose(bool disposing)
            {
                if (!disposedValue)
                {
                    if (disposing)
                    {
                        // TODO: 관리형 상태(관리형 개체)를 삭제합니다.
                        try
                        {
                            if (!readOnly)
                            {
                                try
                                {
                                    Writer.Commit();
                                    searcherManager.MaybeRefresh();
                                }
                                finally
                                {
                                    Writer.Dispose();
                                }
                            }
                            searcherManager.Dispose();
                        }
                        finally
                        {
                            directory.Dispose();
                        }
                    }

                    // TODO: 비관리형 리소스(비관리형 개체)를 해제하고 종료자를 재정의합니다.
                    // TODO: 큰 필드를 null로 설정합니다.
                    disposedValue = true;
                }
            }

            // // TODO: 비관리형 리소스를 해제하는 코드가 'Dispose(bool disposing)'에 포함된 경우에만 종료자를 재정의합니다.
            // ~IndexStore()
            // {
            //     // 이 코드를 변경하지 마세요. 'Dispose(bool disposing)' 메서드에 정리 코드를 입력합니다.
            //     Dispose(disposing: false);
            // }

            public void Dispose()
            {
                // 이 코드를 변경하지 마세요. 'Dispose(bool disposing)' 메서드에 정리 코드를 입력합니다.
                Dispose(disposing: true);
                GC.SuppressFinalize(this);
            }
        }

        private sealed class IndexInput : IIndexInput
        {
            public IndexInput(Document doc, IDictionaryStore<IndexType> indexTypeStore)
            {
                this.doc = doc;
                this.indexTypeStore = indexTypeStore;
            }

            private readonly Document doc;
            private readonly IDictionaryStore<IndexType> indexTypeStore;

            public Document Doc => doc;

            private bool AddType(string name, IndexType indexType)
            {
                IndexType type = indexTypeStore.Get(name, indexType, true);
                return type.Equals(indexType);
            }

            public void AddDouble(string name, double value)
            {
                if (AddType(name, IndexType.DOUBLE))
                    doc.Add(new DoubleField(name, value, Field.Store.YES));
            }

            public void AddInt32(string name, int value)
            {
                if (AddType(name, IndexType.INT32))
                    doc.Add(new Int32Field(name, value, Field.Store.YES));
            }

            public void AddInt64(string name, long value)
            {
                if (AddType(name, IndexType.INT64))
                    doc.Add(new Int64Field(name, value, Field.Store.YES));
            }

            public void AddString(string name, string value)
            {
                value = value is null ? string.Empty : value;
                if (AddType(name, IndexType.STRING))
                    doc.Add(new StringField(name, value, Field.Store.NO));
            }

            public void AddText(string name, string value)
            {
                value = value is null ? string.Empty : value;
                if (AddType(name, IndexType.TEXT))
                    doc.Add(new TextField(name, value, Field.Store.NO));
            }
        }

        private sealed class SearchCollector : ICollector
        {
            public SearchCollector(IndexSearcher searcher, Action<Document> handler)
            {
                this.searcher = searcher;
                this.handler = handler;
            }

            private readonly IndexSearcher searcher;
            private readonly Action<Document> handler;

            public bool AcceptsDocsOutOfOrder => false;

            public void Collect(int doc)
            {
                Document document = searcher.Doc(doc + docBase);
                handler(document);
            }

            public void SetNextReader(AtomicReaderContext context)
            {
                docBase = context.DocBase;
            }

            private int docBase;

            public void SetScorer(Scorer scorer)
            {
            }
        }
    }
}
