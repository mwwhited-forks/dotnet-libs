using Eliassen.System.Linq.Search;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Nucleus.Core.Contracts.Models
{
    public class PagedResult<T> : PagedResult, IPagedQueryResult<T> where T : class
    {
#warning retire this
        public List<T> Results { get; set; } = new List<T>();

        public IEnumerable<T> Rows => Results;
        IReadOnlyList<T> IQueryResult<T>.Rows => Results;
        IEnumerable IQueryResult.Rows => Rows;

        public int TotalPageCount => this.PageCount;
        public int TotalRowCount => Convert.ToInt32(this.RowCount);
    }
    public abstract class PagedResult
    {
#warning retire this
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public long RowCount { get; set; }

        public int FirstRowOnPage => (CurrentPage - 1) * PageSize + 1;
        public int LastRowOnPage => Convert.ToInt32(Math.Min(CurrentPage * PageSize, RowCount));
    }
}
