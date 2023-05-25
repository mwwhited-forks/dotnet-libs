using Eliassen.System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nucleus.Core.Contracts.Models.Filters
{
#warning Retire this
    public class PagedResult<T>
    {
        private readonly IPagedResult<T> _pagedResult;

        public PagedResult(IPagedResult<T> pagedResult)
        {
            _pagedResult = pagedResult;
        }

        public IEnumerable<T> Results => _pagedResult.Rows;

        public int CurrentPage => _pagedResult.CurrentPage;
        public int PageCount => _pagedResult.TotalPageCount;
        public int PageSize => _pagedResult.Rows.Count();
        public long RowCount => _pagedResult.TotalRowCount;


        public int FirstRowOnPage => (CurrentPage - 1) * PageSize + 1;
        public int LastRowOnPage => Convert.ToInt32(Math.Min(CurrentPage * PageSize, RowCount));
    }
}
