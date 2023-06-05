using Eliassen.System.Linq.Expressions;
using System;
using System.Linq;

namespace Eliassen.System.Linq.Search
{
    public interface ISortBuilder<TModel>
    {
        IOrderedQueryable<TModel> SortBy(IQueryable<TModel> query, ISortQuery searchRequest, IExpressionTreeBuilder<TModel> treeBuilder);
    }
    internal class SortBuilder<TModel> : ISortBuilder<TModel>
    {
        public IOrderedQueryable<TModel> SortBy(IQueryable<TModel> query, ISortQuery searchRequest, IExpressionTreeBuilder<TModel> treeBuilder)
        {
            var sortLookup = treeBuilder.PropertyExpressions();

            var orderBys = searchRequest.OrderBy;

            var compositeSortMap =
                  sortLookup.Select(kvp => (kvp.Key, Expression: kvp.Value, Weight: 2))
                  .GroupBy(k => k.Key).Select(i => (i.Key, i.OrderBy(x => x.Weight).First().Expression))
                  .ToDictionary(k => k.Key, v => v.Expression, StringComparer.InvariantCultureIgnoreCase)
                  ;

            if (!orderBys.Any())
                orderBys = treeBuilder.DefaultSortOrder()
                  .ToDictionary(k => k.column, v => v.direction, StringComparer.InvariantCultureIgnoreCase);

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

            return ordered ?? query.OrderBy(_ => 0);
        }
    }
}
