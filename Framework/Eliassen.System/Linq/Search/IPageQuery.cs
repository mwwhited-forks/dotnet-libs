namespace Eliassen.System.Linq.Search
{
    public interface IPageQuery
    {
        int CurrentPage { get; }
        int PageSize { get; }

        bool ExcludePageCount { get; }
    }
}
