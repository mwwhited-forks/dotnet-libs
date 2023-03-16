using Nucleus.Core.Contracts.Interfaces;
using System;
using System.Collections.Generic;

namespace Nucleus.Core.Contracts.Models
{
    public class PagedResult<T> : PagedResult, IPagedResult<T> where T : class
    {
        public IList<T> Results { get; set; }

        int IPagedResult<T>.TotalPageCount => PageCount;
        long IPagedResult<T>.TotalRowCount => RowCount;
        IEnumerable<T> IPagedResult<T>.Rows => Results;

        public PagedResult()
        {
            Results = new List<T>();
        }
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
