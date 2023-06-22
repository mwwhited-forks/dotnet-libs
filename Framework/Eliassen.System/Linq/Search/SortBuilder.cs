using Eliassen.System.Internal;
using Eliassen.System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Eliassen.System.Linq.Search
{
    public class SortBuilder<TModel> : ISortBuilder<TModel>
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
            IExpressionTreeBuilder<TModel> treeBuilder,
            StringComparison stringComparison
            )
        {
            var stringComparer = StringComparer.FromComparison(stringComparison);
            var sortLookup = treeBuilder.PropertyExpressions();

            var orderBys = searchRequest.OrderBy;

            var compositeSortMap =
                  sortLookup.Select(kvp => (kvp.Key, Expression: kvp.Value, Weight: 2))
                  .GroupBy(k => k.Key).Select(i => (i.Key, i.OrderBy(x => x.Weight).First().Expression))
                  .ToDictionary(k => k.Key, v => v.Expression, stringComparer)
                  ;

            var unmatchedKeys = searchRequest.OrderBy.Keys.Except(compositeSortMap.Keys, stringComparer);
            var matchedKeys = searchRequest.OrderBy.Keys.Intersect(compositeSortMap.Keys, stringComparer);

            if (unmatchedKeys.Any())
            {
                _logger.LogWarning(
                    $"Could not use properties: {{{nameof(unmatchedKeys)}}} as they are not on the model",
                    string.Join("; ", unmatchedKeys)
                    );
            }

            if (!matchedKeys.Any() && treeBuilder.DefaultSortOrder().Any())
            {
                orderBys = treeBuilder.DefaultSortOrder()
                  .ToDictionary(k => k.column, v => v.direction, stringComparer);
                _logger.LogInformation(
                    $"Applying default sort for {{type}}: {{{nameof(orderBys)}}}",
                    typeof(TModel),
                    string.Join("; ", treeBuilder.DefaultSortOrder())
                    );
            }

            IOrderedQueryable<TModel>? ordered = null;
            foreach (var orderBy in orderBys)
            {
                if (!compositeSortMap.TryGetValue(orderBy.Key, out var keySelector, stringComparer)) continue;

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
                _logger.LogWarning($"Force sort by 0 applied for {{type}}", typeof(TModel));
                ordered ??= query.OrderBy(_ => 0);
            }

            return ordered;
        }
    }
}
