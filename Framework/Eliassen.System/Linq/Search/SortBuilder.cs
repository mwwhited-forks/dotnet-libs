using Eliassen.System.Internal;
using Eliassen.System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Eliassen.System.Linq.Search
{
    internal class SortBuilder<TModel> : ISortBuilder<TModel>
    {
        private readonly ILogger _logger;

        public SortBuilder(
            ILogger<SortBuilder<TModel>>? logger = null
            )
        {
            _logger = logger ?? new ConsoleLogger<SortBuilder<TModel>>();
        }

        public IOrderedQueryable<TModel> SortBy(
            IQueryable<TModel> query,
            ISortQuery searchRequest,
            IExpressionTreeBuilder<TModel> treeBuilder
            )
        {
            var sortLookup = treeBuilder.PropertyExpressions();

            var orderBys = searchRequest.OrderBy;

            var compositeSortMap =
                  sortLookup.Select(kvp => (kvp.Key, Expression: kvp.Value, Weight: 2))
                  .GroupBy(k => k.Key).Select(i => (i.Key, i.OrderBy(x => x.Weight).First().Expression))
                  .ToDictionary(k => k.Key, v => v.Expression, StringComparer.InvariantCultureIgnoreCase)
                  ;

            if (!orderBys.Any() && treeBuilder.DefaultSortOrder().Any())
            {
                orderBys = treeBuilder.DefaultSortOrder()
                  .ToDictionary(k => k.column, v => v.direction, StringComparer.InvariantCultureIgnoreCase);
                _logger.LogInformation(
                    $"Applying default sort for {{type}}: {{{nameof(orderBys)}}}",
                    typeof(TModel),
                    string.Join("; ", treeBuilder.DefaultSortOrder())
                    );
            }

            IOrderedQueryable<TModel>? ordered = null;

            foreach (var orderBy in orderBys)
            {
                if (!compositeSortMap.TryGetValue(orderBy.Key, out var keySelector)) continue;

                ordered = (ordered, orderBy.Value) switch
                {
                    (null, OrderDirections.Ascending) => query.OrderBy(keySelector),
                    (null, OrderDirections.Descending) => query.OrderByDescending(keySelector),
                    (_, OrderDirections.Ascending) => ordered.ThenBy(keySelector),
                    (_, OrderDirections.Descending) => ordered.ThenByDescending(keySelector),
                    _ => ordered
                };
            }

            if (ordered == null)
            {
                _logger.LogWarning($"No sort applied for {{type}}", typeof(TModel));
                ordered ??= query.OrderBy(_ => 0);
            }

            return ordered;
        }
    }
}
