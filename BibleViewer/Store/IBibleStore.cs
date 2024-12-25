using BibleViewer.Entity;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Search;
using Lucene.Net.Store;
using System;
using System.Collections.Generic;
using System.IO;

namespace BibleViewer.Store
{
	public interface IBibleStore : IDisposable
	{
		const string STORE_PATH = "Store";
		const string CHAPTER_FIELD_NAME = "CHAPTER";
		const string LINE_FIELD_NAME = "LINE";
		const string BODY_FIELD_NAME = "BODY";

		IEnumerable<BibleChapter> GetChaters();
		SortedSet<BibleBody> Search(ISearchQuery query);

		public sealed class BibleStore : IBibleStore
		{
			public BibleStore(DirectoryInfo storeDir, string typeCode, string subjectCode)
			{
				this.subjectCode = subjectCode;
				fsDirectory = FSDirectory.Open(storeDir.GetChildDirectoryInfo(typeCode).GetChildDirectoryInfo(subjectCode));
				analyzer = new StandardAnalyzer(Lucene.Net.Util.LuceneVersion.LUCENE_48);
				searcherManager = new SearcherManager(fsDirectory, null);
			}

			private readonly string subjectCode;
			private readonly FSDirectory fsDirectory;
			private readonly Analyzer analyzer;
			private readonly SearcherManager searcherManager;
			private bool disposed = false;

			public IEnumerable<BibleChapter> GetChaters()
			{
				IndexSearcher indexSearcher = searcherManager.Acquire();

				Query q = NumericRangeQuery.NewInt32Range(CHAPTER_FIELD_NAME, 1, int.MaxValue, true, false);
				ChapterCollector collector = new ChapterCollector(indexSearcher);
				indexSearcher.Search(q, collector);

				searcherManager.Release(indexSearcher);
				return collector.GetChapters();
			}

			internal sealed class ChapterCollector(IndexSearcher indexSearcher) : ICollector
			{
				private readonly SortedSet<BibleChapter> chatpers = new SortedSet<BibleChapter>();

				public bool AcceptsDocsOutOfOrder => false;

				public void Collect(int doc)
				{
					Document document = indexSearcher.Doc(doc);
					int? chapter = document.GetField(CHAPTER_FIELD_NAME).GetInt32Value();
					int? line = document.GetField(LINE_FIELD_NAME).GetInt32Value();
					if (chapter.HasValue)
					{
						BibleChapter ch = new BibleChapter(chapter.Value);
						if (!chatpers.TryGetValue(ch, out BibleChapter ch2))
							chatpers.Add(ch);
						else
							ch = ch2;
						if (line.HasValue)
							ch.Lines.Add(line.Value);
					}
				}

				public void SetNextReader(AtomicReaderContext context)
				{
				}

				public void SetScorer(Scorer scorer)
				{
				}

				public IEnumerable<BibleChapter> GetChapters()
				{
					return chatpers;
				}
			}

			public SortedSet<BibleBody> Search(ISearchQuery query)
			{
				LuceneQueryCompiler compiler = new LuceneQueryCompiler();
				Query q = compiler.Compile(query);

				SortedSet<BibleBody> bibleBodies = new SortedSet<BibleBody>();
				IndexSearcher indexSearcher = searcherManager.Acquire();
				BibleBodyCollector collector = new BibleBodyCollector(indexSearcher, bibleBodies);
				
				indexSearcher.Search(q, collector);
				searcherManager.Release(indexSearcher);
				return bibleBodies;
			}

			internal sealed class LuceneQueryCompileContext : ISearchQueryContext
			{
				public readonly Stack<string> NameStack = new Stack<string>();
				public readonly Stack<Query> QueryStack = new Stack<Query>();
			}

			internal sealed class LuceneQueryCompiler : ISearchQueryVisitor<LuceneQueryCompileContext>
			{
				public Query Compile(ISearchQuery searchQuery)
				{
					LuceneQueryCompileContext context = new LuceneQueryCompileContext();
					context.NameStack.Push(BODY_FIELD_NAME);
					context.QueryStack.Push(new MatchAllDocsQuery());
					searchQuery.Accept(this, context);
					return context.QueryStack.Pop();
				}

				public void Visit(ISearchQuery.BooleanAndQuery query, LuceneQueryCompileContext context)
				{
					query.Left.Accept(this, context);
					Query l = context.QueryStack.Pop();
					query.Right.Accept(this, context);
					Query r = context.QueryStack.Pop();
					BooleanQuery q = new BooleanQuery();
					q.Add(l, Occur.MUST);
					q.Add(r, Occur.MUST);
					context.QueryStack.Push(q);
				}

				public void Visit(ISearchQuery.BooleanOrQuery query, LuceneQueryCompileContext context)
				{
					query.Left.Accept(this, context);
					Query l = context.QueryStack.Pop();
					query.Right.Accept(this, context);
					Query r = context.QueryStack.Pop();
					BooleanQuery q = new BooleanQuery();
					q.Add(l, Occur.SHOULD);
					q.Add(r, Occur.SHOULD);
					context.QueryStack.Push(q);
				}

				public void Visit(ISearchQuery.NamedQuery query, LuceneQueryCompileContext context)
				{
					context.NameStack.Push(query.Name);
					query.ValueQuery.Accept(this, context);
					context.NameStack.Pop();
				}

				public void Visit(ISearchQuery.RangeQuery query, LuceneQueryCompileContext context)
				{
					string fieldName = context.NameStack.Pop();
					context.QueryStack.Push(NumericRangeQuery.NewInt32Range(fieldName, query.Start, query.End, query.StartInclusive, query.EndInclusive));
					context.NameStack.Push(fieldName);
				}
			}

			internal sealed class BibleBodyCollector(IndexSearcher indexSearcher, SortedSet<BibleBody> bibleBodies) : ICollector
			{
				public bool AcceptsDocsOutOfOrder => false;

				public void Collect(int doc)
				{
					Document document = indexSearcher.Doc(doc);
					int? chapter = document.GetField(CHAPTER_FIELD_NAME).GetInt32Value();
					int? line = document.GetField(LINE_FIELD_NAME).GetInt32Value();
					string body = document.GetField(BODY_FIELD_NAME).GetStringValue();
					if (chapter.HasValue && line.HasValue && body is not null)
						bibleBodies.Add(new BibleBody(chapter.Value, line.Value, body));
				}

				public void SetNextReader(AtomicReaderContext context)
				{
				}

				public void SetScorer(Scorer scorer)
				{
				}
			}

			public void Dispose()
			{
				if (!disposed)
				{
					disposed = true;
					searcherManager.Dispose();
					analyzer.Dispose();
					fsDirectory.Dispose();
					GC.SuppressFinalize(this);
				}
			}
		}
	}
}
