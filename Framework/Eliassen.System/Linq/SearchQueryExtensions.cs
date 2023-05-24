using Eliassen.System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Eliassen.System.Linq;

namespace Eliassen.System.Linq
{
    public static class SearchQueryExtensions
    {
        public static IEnumerable<string> SearchableProperties<TModel>() =>
            ExpressionTreeBuilder.GetSearchablePropertyNames<TModel>();
        public static IEnumerable<string> SortableProperties<TModel>() =>
            ExpressionTreeBuilder.GetSortablePropertyNames<TModel>();
        public static IEnumerable<string> FilterableProperties<TModel>() =>
            ExpressionTreeBuilder.GetFilterablePropertyNames<TModel>();

        /// <summary>
        /// this method will compose and execute a query build from IHaveSearchTerm, IHaveSearchFilter
        /// <seealso cref="ISearchTermQuery"/>
        /// <seealso cref="IFilterQuery"/>
        /// <seealso cref="ISortQuery"/>
        /// </summary>
        /// 
        /// <typeparam name="TModel"></typeparam>
        /// <param name="query"></param>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        public static IOrderedQueryable<TModel> BuildFrom<TModel>(this IQueryable<TModel> query, object searchQuery) =>
            query
            .SearchBy(searchQuery as ISearchTermQuery)
            .FilterBy(searchQuery as IFilterQuery)
            .SortBy(searchQuery as ISortQuery)
            ;

        public static IPagedResult ExecuteBy(this IQueryable query, object searchQuery)
        {
            var interfaces = from inf in query.GetType().GetInterfaces()
                             where inf.IsGenericType
                             where inf.GetGenericTypeDefinition() == typeof(IQueryable<>)
                             select inf;

            var @interface = interfaces.FirstOrDefault() ?? throw new NotSupportedException($"{query.GetType()} is not supported");
            var elementType = @interface.GetGenericArguments()[0];

            var queryType = Type.MakeGenericSignatureType(typeof(IQueryable<>), Type.MakeGenericMethodParameter(0));

            var methodSignature = typeof(SearchQueryExtensions).GetMethod(
                nameof(SearchQueryExtensions.ExecuteBy),
                1,
                new[] { queryType, typeof(object) }
                );

            var method = methodSignature.MakeGenericMethod(elementType);

            var result = method.Invoke(null, new[] { query, searchQuery });
            var paged = (IPagedResult)result;
            return paged;
        }

        /// <summary>
        /// this method will compose and execute a query build from IHaveSearchTerm, IHaveSearchFilter
        /// <seealso cref="ISearchTermQuery"/>
        /// <seealso cref="IFilterQuery"/>
        /// <seealso cref="ISortQuery"/>
        /// <seealso cref="IPageQuery"/>
        /// </summary>
        /// 
        /// <typeparam name="TModel"></typeparam>
        /// <param name="query"></param>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        public static IPagedResult<TModel> ExecuteBy<TModel>(this IQueryable<TModel> query, object searchQuery) =>
            query.BuildFrom(searchQuery).PageBy(searchQuery as IPageQuery);

        /// <summary>
        /// this method will compose and execute a query build from IHaveSearchTerm, IHaveSearchFilter
        /// <seealso cref="ISearchTermQuery"/>
        /// <seealso cref="IFilterQuery"/>
        /// <seealso cref="ISortQuery"/>
        /// <seealso cref="IPageQuery"/>
        /// </summary>
        /// 
        /// <typeparam name="TModel"></typeparam>
        /// <param name="query"></param>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        public static async Task<IPagedResult<TModel>> ExecuteByAsync<TModel>(
            this IQueryable<TModel> query,
            object searchQuery,
            CancellationToken cancellationToken = default
            ) =>
            await query.BuildFrom(searchQuery).PageByAsync(searchQuery as IPageQuery, cancellationToken);

        public static IQueryable<TModel> SearchBy<TModel>(this IQueryable<TModel> query, ISearchTermQuery? search)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));
            if (!string.IsNullOrWhiteSpace(search?.SearchTerm))
            {
                var searchTermExpression = ExpressionTreeBuilder.BuildExpression<TModel>(search.SearchTerm);
                if (searchTermExpression != null)
                    return query.Where(searchTermExpression);
            }
            return query;
        }

        public static IQueryable<TModel> FilterBy<TModel>(this IQueryable<TModel> query, IFilterQuery? filter)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));
            if (filter?.Filter != null)
            {
                foreach (var item in filter.Filter)
                {
                    var filterExpression = ExpressionTreeBuilder.GetExpression<TModel>(item.Key)?.BuildPredicate(item.Value);
                    if (filterExpression != null)
                        query = query.Where(filterExpression);
                }
            }
            return query;
        }

        public static IOrderedQueryable<TModel> SortBy<TModel>(this IQueryable<TModel> query, ISortQuery? sortBy)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));
            query = sortBy != null ? SortByExtension.SortBy(query, sortBy) : query;
            if (query is IOrderedQueryable<TModel> sorted)
                return sorted;
            return query.OrderBy(_ => 0);
        }

        public const int DefaultPageSize = 10;
        public static IPagedResult<TModel> PageBy<TModel>(this IOrderedQueryable<TModel> query, IPageQuery? pager)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));

            var pageLength = (pager?.PageSize ?? 0) <= 0 ? DefaultPageSize : (pager?.PageSize ?? DefaultPageSize);
            var page = (pager?.CurrentPage ?? 0) < 0 ? 0 : (pager?.CurrentPage ?? 0);
            var excludePageCount = pager?.ExcludePageCount ?? false;

            var totalRows = excludePageCount ? -1 : query.Count();
            var rows = (pageLength, page) switch
            {
                _ when page < 0 => Array.Empty<TModel>(),
                (int.MaxValue, 0) => query.ToArray(),
                _ => query.Skip(page * pageLength).Take(pageLength).ToArray()
            };

            var result = new SearchResult<TModel>(
                currentPage: page,
                totalPageCount: totalRows == -1 ? totalRows : (int)Math.Ceiling((decimal)totalRows / pageLength),
                totalRowCount: totalRows,
                rows: rows
                );
            return result;
        }

        public static async Task<IPagedResult<TModel>> PageByAsync<TModel>(
            this IOrderedQueryable<TModel> query,
            IPageQuery? pager,
            CancellationToken cancellationToken = default
            )
        {
            if (query == null) throw new ArgumentNullException(nameof(query));

            var pageLength = (pager?.PageSize ?? 0) <= 0 ? DefaultPageSize : (pager?.PageSize ?? DefaultPageSize);
            var page = (pager?.CurrentPage ?? 0) < 0 ? 0 : (pager?.CurrentPage ?? 0);
            var excludePageCount = pager?.ExcludePageCount ?? false;

            var totalRows = excludePageCount ? int.MaxValue : query.Count();
            var rows = (pageLength, page) switch
            {
                _ when page < 0 => Enumerable.Empty<TModel>(),
                (int.MaxValue, 0) => await query.ToListAsync(cancellationToken),
                _ => await query.Skip(page * pageLength).Take(pageLength).ToListAsync(cancellationToken)
            };

            var result = new SearchResult<TModel>(
                currentPage: page,
                totalPageCount: (int)Math.Ceiling((decimal)totalRows / pageLength),
                totalRowCount: totalRows,
                rows: rows
                );
            return result;
        }
    }
}
