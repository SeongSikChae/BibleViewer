namespace BibleViewer.Store
{
	public interface ISearchQueryContext
	{
	}

	public interface ISearchQueryVisitor<TContext> where TContext : ISearchQueryContext
	{
		void Visit(ISearchQuery.BooleanAndQuery query, TContext context);
		void Visit(ISearchQuery.BooleanOrQuery query, TContext context);
		void Visit(ISearchQuery.NamedQuery query, TContext context);
		void Visit(ISearchQuery.RangeQuery query, TContext context);
	}
}
