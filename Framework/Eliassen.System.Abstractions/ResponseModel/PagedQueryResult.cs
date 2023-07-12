using System.Collections.Generic;

namespace Eliassen.System.ResponseModel
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
        public int CurrentPage { get; }
        /// <inheritdoc/>
        public int TotalPageCount { get; }
        /// <inheritdoc/>
        public int TotalRowCount { get; }
    }
}
