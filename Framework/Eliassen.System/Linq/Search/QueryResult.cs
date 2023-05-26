using System.Collections.Generic;

namespace Eliassen.System.Linq.Search
{
    public class QueryResult<TModel> : List<TModel>, IQueryResult<TModel>
    {
        public QueryResult(IEnumerable<TModel> items) : base(items)
        {
        }
    }
}
