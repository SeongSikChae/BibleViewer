using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace BibleViewer.Query.Tests
{
    [TestClass]
    public class SearchQueryParserTests
    {
        [TestMethod]
        public void ParseTest()
        {
            string query = "창 1:1";
            SearchQueryParser parser = new SearchQueryParser();
            ISearchQuery q = parser.Parse(query);
            SearchQueryTracer tracer = new SearchQueryTracer();
            q.Accept(tracer);
        }

        [TestMethod]
        public void ParseTest2()
        {
            string query = "창 1:1-10";
            SearchQueryParser parser = new SearchQueryParser();
            ISearchQuery q = parser.Parse(query);
            SearchQueryTracer tracer = new SearchQueryTracer();
            q.Accept(tracer);
        }

        [TestMethod]
        public void ParseTest3()
        {
            string query = "창세기 1:1-10";
            SearchQueryParser parser = new SearchQueryParser();
            ISearchQuery q = parser.Parse(query);
            SearchQueryTracer tracer = new SearchQueryTracer();
            q.Accept(tracer);
        }

        private sealed class SearchQueryTracer : ISearchQueryVisitor
        {
            public void Visit(AllSearchQuery query)
            {
                Trace.Write("*");
            }

            public void Visit(NamedSearchQuery query)
            {
                Trace.Write($"{query.Name}: ");
                query.Query.Accept(this);
            }

            public void Visit(TermSearchQuery query)
            {
                Trace.Write($"'{query.Term}'");
            }

            public void Visit(MultiTermSearchQuery query)
            {
                Trace.Write($"({string.Join(' ', query.Terms)})");
            }

            public void Visit(RangeSearchQuery query)
            {
                Trace.Write($"{(query.StartInclusive ? '[' : '{')} {query.Start} ~ {query.End} {(query.EndInclusive ? ']' : '}')}");
            }

            public void Visit(OrSearchQuery query)
            {
                if (query.List.Count > 0)
                {
                    Trace.Write('(');
                    ISearchQuery q = query.List.First();
                    q.Accept(this);

                    for (int i = 1; i < query.List.Count; i++)
                    {
                        Trace.Write(" or ");
                        ISearchQuery t = query.List[i];
                        t.Accept(this);
                    }
                    Trace.Write(')');
                }
            }

            public void Visit(AndSearchQuery query)
            {
                query.Query.Accept(this);
                foreach (AndSearchQuery.AndSearchItem t in query.List)
                {
                    Trace.Write(" and ");
                    t.Query.Accept(this);
                }
            }
        }
    }
}