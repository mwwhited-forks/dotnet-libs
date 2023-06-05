using Eliassen.System.ComponentModel.Search;
using Eliassen.System.Linq.Expressions;
using Eliassen.System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Eliassen.System.Linq.Search
{
    public static class SortByExtension
    {
        public static IOrderedQueryable<T> DecodeSortBy<T>(this IEnumerable<T> query, string? sortBy, string? direction = default, string delimiter = ",") =>
            query.AsQueryable().DecodeSortBy(sortBy, direction, delimiter);

        public static IOrderedQueryable<T> SortBy<T>(this IEnumerable<T> query, params string[] columns) =>
            query.AsQueryable().SortBy(columns);
        public static IOrderedQueryable<T> SortBy<T>(this IEnumerable<T> query, IEnumerable<string> columns) =>
            query.AsQueryable().SortBy(columns);

        public static IOrderedQueryable<T> SortBy<T>(this IEnumerable<T> query, ISortQuery orderBys,
            (string column, Expression<Func<T, object>> expression)[] remap) =>
            query.SortBy(orderBys.OrderBy, remap.AsEnumerable());
        public static IOrderedQueryable<T> SortBy<T>(this IEnumerable<T> query, ISortQuery orderBys,
            IEnumerable<(string column, Expression<Func<T, object>> expression)> remap) =>
            query.SortBy(orderBys.OrderBy, remap);

        public static IOrderedQueryable<T> SortBy<T>(this IEnumerable<T> query, IDictionary<string, OrderDirections> orderBys,
            params (string column, Expression<Func<T, object>> expression)[] remap) =>
                query.SortBy(orderBys, remap.AsEnumerable());
        public static IOrderedQueryable<T> SortBy<T>(this IEnumerable<T> query, IDictionary<string, OrderDirections> orderBys,
            IEnumerable<(string column, Expression<Func<T, object>> expression)> remap) =>
            query.AsQueryable().SortBy(orderBys, remap);
        public static IOrderedQueryable<T> SortBy<T>(this IEnumerable<T> query, params (string column, OrderDirections direction)[] orderBys) =>
            query.AsQueryable().SortBy(orderBys);
        public static IOrderedQueryable<T> SortBy<T>(this IEnumerable<T> query, IEnumerable<(string column, OrderDirections direction)> orderBys) =>
            query.AsQueryable().SortBy(orderBys);

        public static IOrderedQueryable<T> DecodeSortBy<T>(this IQueryable<T> query, string? sortBy, string? direction = default, string delimiter = ",")
        {
            if (sortBy == null) return query.OrderBy(_ => 0);

            var columns = sortBy.Split(delimiter).Select(s => s.Trim());
            var directions = (direction?.Split(delimiter) ?? Array.Empty<string>())
                .Concat(Enumerable.Range(0, columns.Count()).Select(_ => OrderDirectionsConstants.AscendingShort))
                .Select(v => v?.StartsWith(OrderDirectionsConstants.DescendingShort, StringComparison.InvariantCultureIgnoreCase) ?? false ? OrderDirections.Descending : OrderDirections.Ascending)
                ;
            var orderBys = columns.Zip(directions, (order, direction) => (order, direction));
            return query.SortBy(orderBys);
        }

        public static IOrderedQueryable<T> SortBy<T>(this IQueryable<T> query, params string[] columns) =>
            query.SortBy(columns.AsEnumerable());
        public static IOrderedQueryable<T> SortBy<T>(this IQueryable<T> query, IEnumerable<string> columns) =>
            query.SortBy(columns.Select(c => (c, OrderDirections.Ascending)));

        public static IOrderedQueryable<T> SortBy<T>(this IQueryable<T> query, ISortQuery orderBys,
            params (string column, Expression<Func<T, object>> expression)[] remap) =>
            query.SortBy(orderBys.OrderBy, remap.AsEnumerable());
        public static IOrderedQueryable<T> SortBy<T>(this IQueryable<T> query, ISortQuery orderBys,
            IEnumerable<(string column, Expression<Func<T, object>> expression)> remap) =>
            query.SortBy(orderBys.OrderBy, remap);

        public static IOrderedQueryable<T> SortBy<T>(this IQueryable<T> query, IDictionary<string, OrderDirections> orderBys,
            params (string column, Expression<Func<T, object>> expression)[] remap) =>
                query.SortBy(orderBys, remap.AsEnumerable());
        public static IOrderedQueryable<T> SortBy<T>(this IQueryable<T> query, IDictionary<string, OrderDirections> orderBys,
            IEnumerable<(string column, Expression<Func<T, object>> expression)> remap) =>
            query.SortBy(
                orderBys: orderBys.Select(i => (column: i.Key, direction: i.Value)).AsEnumerable(),
                remap: remap
                );
        public static IOrderedQueryable<T> SortBy<T>(this IQueryable<T> query, params (string column, OrderDirections direction)[] orderBys) =>
            query.SortBy(orderBys.AsEnumerable());
        public static IOrderedQueryable<T> SortBy<T>(
            this IQueryable<T> query,
            IEnumerable<(string column, OrderDirections direction)> orderBys,
            IEnumerable<(string column, Expression<Func<T, object>> expression)> remap
            )
        {
            var sortLookup = ExpressionTreeBuilder.PropertyExpressions<T>();

            var compositeSortMap =
                  (remap ?? Enumerable.Empty<(string column, Expression<Func<T, object>> expression)>()).Select(i => (Key: i.column, Expression: i.expression, Weight: 1))
                  .Concat(sortLookup.Select(kvp => (kvp.Key, Expression: kvp.Value, Weight: 2)))
                  .GroupBy(k => k.Key).Select(i => (i.Key, i.OrderBy(x => x.Weight).First().Expression))
                  .ToDictionary(k => k.Key, v => v.Expression, StringComparer.InvariantCultureIgnoreCase)
                  ;

            if (!orderBys.Any())
                orderBys = DefaultSortOrder<T>();

            IOrderedQueryable<T>? ordered = null;

            foreach (var (column, direction) in orderBys)
            {
                if (!compositeSortMap.TryGetValue(column, out var keySelector)) continue;

                ordered = (ordered, direction) switch
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

        public static IEnumerable<(string column, OrderDirections direction)> DefaultSortOrder(Type modelType) =>
            (IEnumerable<(string column, OrderDirections direction)>)typeof(SortByExtension)
                .GetStaticMethod(nameof(DefaultSortOrder))
                .MakeGenericMethod(modelType)
                .Invoke(null, null);
        public static IEnumerable<(string column, OrderDirections direction)> DefaultSortOrder<T>() =>
            (
                from attribute in typeof(T).GetCustomAttributes<DefaultSortAttribute>()
                where !string.IsNullOrWhiteSpace(attribute.TargetName)
                select (name: attribute.TargetName, attribute.Order, attribute.Priority)
            ).Concat(
                from prop in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty)
                let attribute = prop.GetCustomAttribute<DefaultSortAttribute>()
                where attribute != null
                select (name: attribute.TargetName ?? prop.Name, attribute.Order, attribute.Priority)
            ).OrderBy(p => p.Priority).Select(o => (o.name, o.Order));
    }
}
