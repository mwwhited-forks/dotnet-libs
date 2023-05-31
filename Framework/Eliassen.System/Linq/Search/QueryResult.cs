using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Eliassen.System.Linq.Search
{
    public class QueryResult<TModel> : IQueryResult<TModel>
    {
        private readonly IReadOnlyList<TModel> _items;

        public QueryResult(
            IEnumerable<TModel> items
            )
        {
            _items = (items as List<TModel>) ?? items.ToList();
        }

        public QueryResult(
            IQueryResult<TModel> toWrap
            ) : this(
                items: toWrap.Rows
                )
        {
        }

        public QueryResult()
        {
        }

        public IReadOnlyList<TModel> Rows { get; init; } = new List<TModel>();
        IEnumerable IQueryResult.Rows => _items;
    }
}
