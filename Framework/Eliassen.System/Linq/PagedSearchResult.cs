using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Eliassen.System.Linq
{
    public class PagedSearchResult<TModel> : IPagedQueryResult<TModel>
    {
        public PagedSearchResult(
            int currentPage,
            int totalPageCount,
            int totalRowCount,
            IEnumerable<TModel> rows
            )
        {
            CurrentPage = currentPage;
            TotalPageCount = totalPageCount;
            TotalRowCount = totalRowCount;
            Rows = rows;
        }

        public PagedSearchResult(
            IPagedQueryResult<TModel> toWrap
            ): this(
                currentPage: toWrap.CurrentPage,
                totalPageCount: toWrap.TotalPageCount,
                totalRowCount: toWrap.TotalRowCount,
                rows: toWrap.Rows
                )
        {
        }

        public PagedSearchResult()
        {
            Rows = Enumerable.Empty<TModel>();
        }

        public int CurrentPage { get; init; }
        public int TotalPageCount { get; init; }
        public int TotalRowCount { get; init; }
        public IEnumerable<TModel> Rows { get; init; }

        IEnumerable IPagedQueryResult.Rows => this.Rows;
    }
}
