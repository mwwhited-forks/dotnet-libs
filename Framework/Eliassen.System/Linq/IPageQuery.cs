namespace Eliassen.System.Linq
{
    public interface IPageQuery
    {
        int CurrentPage { get; }
        int PageSize { get; }

        bool ExcludePageCount { get; }
    }
}
