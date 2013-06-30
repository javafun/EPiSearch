namespace EPiSearch
{
    public interface ISearchService
    {
        SearchResults Search(string query, int skip, int take);
    }
}