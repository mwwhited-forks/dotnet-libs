namespace Eliassen.System.ResponseModel;

public class PagedQueryResult<TModel> : QueryResult<TModel>, IPagedQueryResult<TModel>
{
    public PagedQueryResult(
        int currentPage,
        int totalPageCount,
        int totalRowCount,
        IEnumerable<TModel> items
        ) : base(items)
    {
        CurrentPage = currentPage;
        TotalPageCount = totalPageCount;
        TotalRowCount = totalRowCount;
    }

    public PagedQueryResult(
        IPagedQueryResult<TModel> toWrap
        ) : this(
            currentPage: toWrap.CurrentPage,
            totalPageCount: toWrap.TotalPageCount,
            totalRowCount: toWrap.TotalRowCount,
            items: toWrap.Rows
            )
    {
    }

    public PagedQueryResult()
    {
    }

    public int CurrentPage { get; }
    public int TotalPageCount { get; }
    public int TotalRowCount { get; }
}
