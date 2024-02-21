using BibleViewer.Store;
using BibleViewer.Store.Dic;
using Lucene.Net.Analysis;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Search;
using Lucene.Net.Util;
using System;
using System.Collections.Generic;

namespace BibleViewer.Query
{
    public sealed class LuceneQueryMaker : ISearchQueryVisitor
    {
        public LuceneQueryMaker(IDictionaryStore<IndexType> indexTypeStore, Analyzer analyzer)
        {
            this.indexTypeStore = indexTypeStore;
            this.analyzer = analyzer;
        }

        private readonly IDictionaryStore<IndexType> indexTypeStore;
        private readonly Analyzer analyzer;
        private Lucene.Net.Search.Query q;
        private Stack<IndexField> stack = new Stack<IndexField>();
        private IndexField f = new IndexField("Body", IndexType.TEXT);

        public Lucene.Net.Search.Query Query => q;

        public void Visit(AllSearchQuery query)
        {
            q = new MatchAllDocsQuery();
        }

        public void Visit(NamedSearchQuery query)
        {
            IndexType type = indexTypeStore.GetIfPresent(query.Name);
            if (type == IndexType.NONE)
                type = IndexType.STRING;
            stack.Push(f);
            f = new IndexField(query.Name, type);
            query.Query.Accept(this);
            f = stack.Pop();
        }

        public void Visit(TermSearchQuery query)
        {
            switch (f.Type)
            {
                case IndexType.TEXT:
                    QueryParser parser = new QueryParser(LuceneVersion.LUCENE_48, f.Name, analyzer);
                    parser.AllowLeadingWildcard = true;
                    q = parser.Parse(query.Term);
                    break;
                case IndexType.STRING:
                    Term term = new Term(f.Name, query.Term);
                    q = query.Term.Contains("*") ? new WildcardQuery(term) : new TermQuery(term);
                    break;
                case IndexType.INT32:
                    {
                        int v = int.Parse(query.Term);
                        q = NumericRangeQuery.NewInt32Range(f.Name, v, v, true, true);
                    }
                    break;
                case IndexType.INT64:
                    {
                        long v = long.Parse(query.Term);
                        q = NumericRangeQuery.NewInt64Range(f.Name, v, v, true, true);
                    }
                    break;
                case IndexType.DOUBLE:
                    {
                        double v = double.Parse(query.Term);
                        q = NumericRangeQuery.NewDoubleRange(f.Name, v, v, true, true);
                    }
                    break;
            }
        }

        public void Visit(MultiTermSearchQuery query)
        {
            BooleanQuery qq = new BooleanQuery();
            qq.MinimumNumberShouldMatch = 1;
            foreach(string t in query.Terms)
            {
                TermSearchQuery termSearchQuery = new TermSearchQuery(t);
                termSearchQuery.Accept(this);
                qq.Add(q, Occur.SHOULD);
            }
            q = qq;
        }

        public void Visit(RangeSearchQuery query)
        {
            switch (f.Type)
            {
                case IndexType.INT32:
                    {
                        int min = int.Parse(query.Start);
                        int max = int.Parse(query.End);
                        q = NumericRangeQuery.NewInt32Range(f.Name, min, max, query.StartInclusive, query.EndInclusive);
                    }
                    break;
                case IndexType.INT64:
                    {
                        long min = long.Parse(query.Start);
                        long max = long.Parse(query.End);
                        q = NumericRangeQuery.NewInt64Range(f.Name, min, max, query.StartInclusive, query.EndInclusive);
                    }
                    break;
                case IndexType.DOUBLE:
                    {
                        double min = double.Parse(query.Start);
                        double max = double.Parse(query.End);
                        q = NumericRangeQuery.NewDoubleRange(f.Name, min, max, query.StartInclusive, query.EndInclusive);
                    }
                    break;
                default:
                    throw new ArgumentException($"{f.Name} not a numeric");
            }
        }

        public void Visit(OrSearchQuery query)
        {
            BooleanQuery qq = new BooleanQuery();
            qq.MinimumNumberShouldMatch = 1;
            foreach(ISearchQuery t in query.List)
            {
                t.Accept(this);
                qq.Add(q, Occur.SHOULD);
            }
            q = qq;
        }

        public void Visit(AndSearchQuery query)
        {
            BooleanQuery qq = new BooleanQuery();
            query.Query.Accept(this);
            qq.Add(q, Occur.MUST);
            foreach (AndSearchQuery.AndSearchItem item in query.List)
            {
                item.Query.Accept(this);
                qq.Add(q, item.IsNot ? Occur.MUST_NOT : Occur.MUST);
            }
            q = qq;
        }

        private sealed class IndexField
        {
            public IndexField(string name, IndexType type)
            {
                Name = name;
                Type = type;
            }

            public string Name { get; }

            public IndexType Type { get; }
        }
    }
}
