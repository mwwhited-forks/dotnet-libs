using System.Collections;
using System.Collections.Generic;

namespace Eliassen.System.ResponseModel
{
    public interface IPagedQueryResult : IQueryResult
    {
        public int CurrentPage { get; }

        public int TotalPageCount { get; }
        public int TotalRowCount { get; }
    }
    public interface IPagedQueryResult<TModel> : IPagedQueryResult, IQueryResult<TModel>
    {
    }
}
