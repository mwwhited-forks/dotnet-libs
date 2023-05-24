using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Eliassen.System.Linq
{
    public class SearchResult<TModel> : IPagedResult<TModel>
    {
        public SearchResult(
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

        public SearchResult(
            IPagedResult<TModel> toWrap
            )
        {
            CurrentPage = toWrap.CurrentPage;
            TotalPageCount = toWrap.TotalPageCount;
            TotalRowCount = toWrap.TotalRowCount;
            Rows = toWrap.Rows;
        }

        public SearchResult()
        {
            Rows = Enumerable.Empty<TModel>();
        }

        public virtual int CurrentPage { get; set; }
        public virtual int TotalPageCount { get; set; }
        public virtual int TotalRowCount { get; set; }
        public virtual IEnumerable<TModel> Rows { get; set; }
        IEnumerable IPagedResult.Rows => this.Rows;
    }
}
