using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleus.Core.Contracts.Interfaces
{
    public interface IPagedResult<TModel>
    {
        public int CurrentPage { get; }

        public int TotalPageCount { get; }
        public long TotalRowCount { get; }

        public IEnumerable<TModel> Rows { get; }
    }
}
