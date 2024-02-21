namespace BibleViewer.Query
{
    public interface ISearchQueryVisitor
    {
        void Visit(AllSearchQuery query);

        void Visit(NamedSearchQuery query);

        void Visit(TermSearchQuery query);

        void Visit(MultiTermSearchQuery query);

        void Visit(RangeSearchQuery query);

        void Visit(OrSearchQuery query);

        void Visit(AndSearchQuery query);
    }
}
