namespace BibleViewer.Store
{
	public interface ISearchQuery
	{
		void Accept<TContext>(ISearchQueryVisitor<TContext> visitor, TContext context) where TContext : ISearchQueryContext;

		public sealed class BooleanAndQuery(ISearchQuery left, ISearchQuery right) : ISearchQuery
		{
			public ISearchQuery Left => left;
			public ISearchQuery Right => right;

			public void Accept<TContext>(ISearchQueryVisitor<TContext> visitor, TContext context) where TContext : ISearchQueryContext
			{
				visitor.Visit(this, context);
			}
		}

		public sealed class BooleanOrQuery(ISearchQuery left, ISearchQuery right) : ISearchQuery
		{
			public ISearchQuery Left => left;
			public ISearchQuery Right => right;

			public void Accept<TContext>(ISearchQueryVisitor<TContext> visitor, TContext context) where TContext : ISearchQueryContext
			{
				visitor.Visit(this, context);
			}
		}

		public sealed class NamedQuery(string name, ValueQuery valueQuery) : ISearchQuery
		{
			public string Name => name;
			public ValueQuery ValueQuery => valueQuery;

			public void Accept<TContext>(ISearchQueryVisitor<TContext> visitor, TContext context) where TContext : ISearchQueryContext
			{
				visitor.Visit(this, context);
			}
		}

		public abstract class ValueQuery : ISearchQuery
		{
			public abstract void Accept<TContext>(ISearchQueryVisitor<TContext> visitor, TContext context) where TContext : ISearchQueryContext;
		}

		public sealed class RangeQuery(int? start, int? end, bool startInclusive, bool endInclusive) : ValueQuery
		{
			public int? Start => start;
			public int? End => end;
			public bool StartInclusive => startInclusive;
			public bool EndInclusive => endInclusive;

			public override void Accept<TContext>(ISearchQueryVisitor<TContext> visitor, TContext context)
			{
				visitor.Visit(this, context);
			}
		}
	}
}
