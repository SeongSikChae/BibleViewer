using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BibleViewer.Query
{
    public interface ISearchQuery
    {
        void Accept(ISearchQueryVisitor visitor);
    }

    public sealed class AllSearchQuery : ISearchQuery
    {
        public void Accept(ISearchQueryVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public sealed class NamedSearchQuery : ISearchQuery
    {
        public NamedSearchQuery(string name, ISearchQuery query)
        {
            this.Name = name;
            this.Query = query;
        }

        public string Name { get; }

        public ISearchQuery Query { get; }

        public void Accept(ISearchQueryVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public sealed class TermSearchQuery : ISearchQuery
    {
        public TermSearchQuery(string term)
        {
            Term = term.Replace('%', '*');
        }

        public string Term { get; }

        public void Accept(ISearchQueryVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public sealed class MultiTermSearchQuery : ISearchQuery
    {
        public MultiTermSearchQuery(List<string> l)
        {
            Terms = new ReadOnlyCollection<string>(l);
        }

        public IReadOnlyList<string> Terms { get; }

        public void Accept(ISearchQueryVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public sealed class RangeSearchQuery : ISearchQuery
    {
        public RangeSearchQuery(string start, string end, bool startInclusive, bool endInclusive)
        {
            this.Start = start;
            this.End = end;
            this.StartInclusive = startInclusive;
            this.EndInclusive = endInclusive;
        }

        public string Start { get; }
        public string End { get; }
        public bool StartInclusive { get; }
        public bool EndInclusive { get; }

        public void Accept(ISearchQueryVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public sealed class OrSearchQuery : ISearchQuery
    {
        public OrSearchQuery(List<ISearchQuery> l)
        {
            this.List = new ReadOnlyCollection<ISearchQuery>(l);
        }

        public IReadOnlyList<ISearchQuery> List { get; }

        public void Accept(ISearchQueryVisitor visitor)
        {
            visitor.Visit(this);
        }

        public static OrSearchQuery Or(ISearchQuery left, ISearchQuery right)
        {
            List<ISearchQuery> list = new List<ISearchQuery>();
            list.Add(left);
            list.Add(right);
            OrSearchQuery q = new OrSearchQuery(list);
            return q;
        }
    }

    public sealed class AndSearchQuery : ISearchQuery
    {
        public AndSearchQuery(ISearchQuery query, List<AndSearchItem> list)
        {
            Query = query;
            List = new ReadOnlyCollection<AndSearchItem>(list);
        }

        public ISearchQuery Query { get; }

        public IReadOnlyList<AndSearchItem> List { get; }

        public void Accept(ISearchQueryVisitor visitor)
        {
            visitor.Visit(this);
        }

        public static AndSearchQuery And(ISearchQuery left, ISearchQuery right)
        {
            ISearchQuery query;
            List<AndSearchItem> list = new List<AndSearchItem>();
            if (left is AndSearchQuery l)
            {
                query = l.Query;
                list.AddRange(l.List);
            }
            else
                query = left;

            if (right is AndSearchQuery r)
            {
                list.Add(new AndSearchItem(false, r.Query));
                list.AddRange(r.List);
            }
            else
                list.Add(new AndSearchItem(false, right));

            AndSearchQuery q = new AndSearchQuery(query, list);
            return q;
        }

        public static AndSearchQuery Not(ISearchQuery left, ISearchQuery right)
        {
            ISearchQuery query;
            List<AndSearchItem> list = new List<AndSearchItem>();
            if (left is AndSearchQuery l)
            {
                query = l.Query;
                list.AddRange(l.List);
            }
            else
                query = left;

            if (right is AndSearchQuery r)
            {
                list.Add(new AndSearchItem(true, r.Query));
                list.AddRange(r.List);
            }
            else
                list.Add(new AndSearchItem(true, right));

            AndSearchQuery q = new AndSearchQuery(query, list);
            return q;
        }

        public sealed class AndSearchItem
        {
            public AndSearchItem(bool isNot, ISearchQuery query)
            {
                IsNot = isNot;
                Query = query;
            }

            public bool IsNot { get; }

            public ISearchQuery Query { get; }
        }
    }
}
