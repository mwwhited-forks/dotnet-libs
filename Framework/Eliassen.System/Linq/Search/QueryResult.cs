using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Eliassen.System.Linq.Search
{
    /// <inheritdoc/>
    public class QueryResult<TModel> : IQueryResult<TModel>
    {
        /// <inheritdoc/>
        public QueryResult(
            IEnumerable<TModel> items
            )
        {
            Rows = (items as List<TModel>) ?? items.ToList();
        }

        /// <inheritdoc/>
        public QueryResult(
            IQueryResult<TModel> toWrap
            ) : this(
                items: toWrap.Rows
                )
        {
        }

        /// <inheritdoc/>
        public QueryResult()
        {
        }

        /// <inheritdoc/>
        public IReadOnlyList<TModel> Rows { get; init; } = new List<TModel>();
        IEnumerable IQueryResult.Rows => Rows;
    }
}
