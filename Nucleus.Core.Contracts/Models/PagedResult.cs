using Eliassen.System.Linq;
using Nucleus.Core.Contracts.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Nucleus.Core.Contracts.Models
{
    public class PagedResult<T> : PagedResult, IPagedQueryResult<T> where T : class
    {
        public IList<T> Results { get; set; } = new List<T>();

        public IEnumerable<T> Rows => Results;
        public int TotalPageCount => this.PageCount;
        public int TotalRowCount => Convert.ToInt32(this.RowCount);

        IEnumerable IPagedQueryResult.Rows => Rows;
    }

    public abstract class PagedResult
    {
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public long RowCount { get; set; }

        public int FirstRowOnPage => (CurrentPage - 1) * PageSize + 1;
        public int LastRowOnPage => Convert.ToInt32(Math.Min(CurrentPage * PageSize, RowCount));
    }
}
