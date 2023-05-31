using System.Collections.Generic;

namespace Eliassen.System.Linq.Search
{
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

        public int CurrentPage { get; init; }
        public int TotalPageCount { get; init; }
        public int TotalRowCount { get; init; }
    }
}
