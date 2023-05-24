using System.Collections;
using System.Collections.Generic;

namespace Eliassen.System.Linq
{
    public interface IPagedResult
    {
        public int CurrentPage { get; }

        public int TotalPageCount { get; }
        public int TotalRowCount { get; }

        public IEnumerable Rows { get; }
    }
    public interface IPagedResult<TModel> : IPagedResult
    {
        public new IEnumerable<TModel> Rows { get; }
    }
}
