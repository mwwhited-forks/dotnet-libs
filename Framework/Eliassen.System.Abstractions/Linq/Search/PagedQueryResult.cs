using System.Collections.Generic;

namespace Eliassen.System.Linq.Search
{
    /// <inheritdoc/>
    public class PagedQueryResult<TModel> : QueryResult<TModel>, IPagedQueryResult<TModel>
    {
        /// <inheritdoc/>
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

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public PagedQueryResult()
        {
        }

        /// <inheritdoc/>
        public int CurrentPage { get; init; }
        /// <inheritdoc/>
        public int TotalPageCount { get; init; }
        /// <inheritdoc/>
        public int TotalRowCount { get; init; }
    }
}
