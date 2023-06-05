using System.Collections;
using System.Collections.Generic;

namespace Eliassen.System.Linq.Search
{
    public interface IQueryResult
    {
        public IEnumerable Rows { get; }
    }
    public interface IQueryResult<TModel> : IQueryResult
    {
        public new IReadOnlyList<TModel> Rows { get; }
    }
}
