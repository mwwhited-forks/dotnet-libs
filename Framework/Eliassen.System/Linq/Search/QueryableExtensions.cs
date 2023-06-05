using Eliassen.System.Linq.Expressions;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Eliassen.System.Linq.Search
{
    /// <summary>
    /// This is a collection of operations for extending IQueryable{T} 
    /// </summary>
    public static class QueryableExtensions
    {
        /// <summary>
        /// Default page size when not defined on request
        /// </summary>
        public const int DefaultPageSize = 10;

        /// <summary>
        /// this method will compose and execute a query build from ISearchTermQuery, IFilterQuery, ISortQuery, IPageQuery
        /// <seealso cref="ISearchTermQuery"/>
        /// <seealso cref="IFilterQuery"/>
        /// <seealso cref="ISortQuery"/>
        /// <seealso cref="IPageQuery"/>
        /// </summary>
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

        /// <summary>
        /// this method will compose and execute a query build from ISearchTermQuery, IFilterQuery, ISortQuery, IPageQuery
        /// <seealso cref="ISearchTermQuery"/>
        /// <seealso cref="IFilterQuery"/>
        /// <seealso cref="ISortQuery"/>
        /// <seealso cref="IPageQuery"/>
        /// </summary>
        /// 
        /// <param name="query"></param>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        public static IQueryResult ExecuteBy(this IQueryable query, object searchQuery)
        {
            var interfaces = from inf in query.GetType().GetInterfaces()
                             where inf.IsGenericType
                             where inf.GetGenericTypeDefinition() == typeof(IQueryable<>)
                             select inf;

            var @interface = interfaces.FirstOrDefault() ??
                throw new NotSupportedException($"{query.GetType()} is not supported");
            var elementType = @interface.GetGenericArguments()[0];

            var queryType = Type.MakeGenericSignatureType(typeof(IQueryable<>), Type.MakeGenericMethodParameter(0)) ??
                throw new NotSupportedException($"{query.GetType()} is not supported");

            var methodSignature = typeof(QueryableExtensions).GetMethod(
                nameof(ExecuteBy),
                1,
                new[] { queryType, typeof(object) }
                ) ??
                throw new NotSupportedException($"{query.GetType()} is not supported");

            var method = methodSignature.MakeGenericMethod(elementType);
            var result = method.Invoke(null, new[] { query, searchQuery }) ??
                throw new NotSupportedException($"{query.GetType()} is not supported");
            var paged = (IQueryResult)result;
            return paged;
        }

        /// <summary>
        /// this method will compose and execute a query build from ISearchTermQuery, IFilterQuery, ISortQuery, IPageQuery
        /// <seealso cref="ISearchTermQuery"/>
        /// <seealso cref="IFilterQuery"/>
        /// <seealso cref="ISortQuery"/>
        /// <seealso cref="IPageQuery"/>
        /// </summary>
        /// 
        /// <param name="query"></param>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        public static IQueryResult<TModel> ExecuteBy<TModel>(this IQueryable<TModel> query, object searchQuery) =>
            (searchQuery, query.BuildFrom(searchQuery)) switch
            {
                (IPageQuery pager, IOrderedQueryable<TModel> ordered) when pager.PageSize >= 0 => ordered.PageBy(pager),
                (_, IOrderedQueryable<TModel> ordered) => new QueryResult<TModel>(ordered)
            };

        /// <summary>
        /// this method will compose and execute a query build from ISearchTermQuery, IFilterQuery, ISortQuery, IPageQuery
        /// <seealso cref="ISearchTermQuery"/>
        /// <seealso cref="IFilterQuery"/>
        /// <seealso cref="ISortQuery"/>
        /// <seealso cref="IPageQuery"/>
        /// </summary>
        /// 
        /// <param name="query"></param>
        /// <param name="searchQuery"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<IQueryResult<TModel>> ExecuteByAsync<TModel>(
            this IQueryable<TModel> query,
            object searchQuery,
            CancellationToken cancellationToken = default
            ) =>
            (searchQuery, query.BuildFrom(searchQuery)) switch
            {
                (IPageQuery pager, IOrderedQueryable<TModel> ordered) when pager.PageSize >= 0 => await ordered.PageByAsync(pager, cancellationToken),
                (_, IOrderedQueryable<TModel> ordered) => new QueryResult<TModel>(await ordered.ToListAsync(cancellationToken))
            };

        /// <summary>
        /// this method will compose and execute a query build from ISearchTermQuery
        /// <seealso cref="ISearchTermQuery"/>
        /// </summary>
        /// 
        /// <param name="query"></param>
        /// <param name="search"></param>
        /// <returns></returns>
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

        /// <summary>
        /// this method will compose and execute a query build from IFilterQuery
        /// <seealso cref="IFilterQuery"/>
        /// </summary>
        /// 
        /// <param name="query"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static IQueryable<TModel> FilterBy<TModel>(this IQueryable<TModel> query, IFilterQuery? filter)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));
            if (filter?.Filter != null)
            {
                foreach (var item in filter.Filter)
                {
                    var filterExpression = ExpressionTreeBuilder.GetPredicateExpression<TModel>(item.Key, item.Value);
                    if (filterExpression != null)
                        query = query.Where(filterExpression);
                }
            }
            return query;
        }

        /// <summary>
        /// this method will compose and execute a query build from ISortQuery
        /// <seealso cref="ISortQuery"/>
        /// </summary>
        /// 
        /// <param name="query"></param>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        public static IOrderedQueryable<TModel> SortBy<TModel>(this IQueryable<TModel> query, ISortQuery? sortBy)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));
            query = sortBy != null ? SortByExtension.SortBy(query, sortBy) : query;
            if (query is IOrderedQueryable<TModel> sorted)
                return sorted;
            return query.OrderBy(_ => 0);
        }

        /// <summary>
        /// this method will compose and execute a query build from IPageQuery
        /// <seealso cref="IPageQuery"/>
        /// </summary>
        /// 
        /// <param name="query"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        public static IPagedQueryResult<TModel> PageBy<TModel>(this IOrderedQueryable<TModel> query, IPageQuery? pager)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));

            var pageLength = (pager?.PageSize ?? 0) <= 0 ? DefaultPageSize : pager?.PageSize ?? DefaultPageSize;
            var page = (pager?.CurrentPage ?? 0) < 0 ? 0 : pager?.CurrentPage ?? 0;
            var excludePageCount = pager?.ExcludePageCount ?? false;

            var totalRows = excludePageCount ? -1 : query.Count();
            var rows = (pageLength, page) switch
            {
                _ when page < 0 => Array.Empty<TModel>(),
                (int.MaxValue, 0) => query.ToArray(),
                _ => query.Skip(page * pageLength).Take(pageLength).ToArray()
            };

            var result = new PagedQueryResult<TModel>(
                currentPage: page,
                totalPageCount: totalRows == -1 ? totalRows : (int)Math.Ceiling((decimal)totalRows / pageLength),
                totalRowCount: totalRows,
                items: rows
                );
            return result;
        }


        /// <summary>
        /// this method will compose and execute a query build from IPageQuery
        /// <seealso cref="IPageQuery"/>
        /// </summary>
        /// 
        /// <param name="query"></param>
        /// <param name="pager"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<IPagedQueryResult<TModel>> PageByAsync<TModel>(
            this IOrderedQueryable<TModel> query,
            IPageQuery? pager,
            CancellationToken cancellationToken = default
            )
        {
            if (query == null) throw new ArgumentNullException(nameof(query));

            var pageLength = (pager?.PageSize ?? 0) <= 0 ? DefaultPageSize : pager?.PageSize ?? DefaultPageSize;
            var page = (pager?.CurrentPage ?? 0) < 0 ? 0 : pager?.CurrentPage ?? 0;
            var excludePageCount = pager?.ExcludePageCount ?? false;

            var totalRows = excludePageCount ? int.MaxValue : query.Count();
            var rows = (pageLength, page) switch
            {
                _ when page < 0 => Enumerable.Empty<TModel>(),
                (int.MaxValue, 0) => await query.ToListAsync(cancellationToken),
                _ => await query.Skip(page * pageLength).Take(pageLength).ToListAsync(cancellationToken)
            };

            var result = new PagedQueryResult<TModel>(
                currentPage: page,
                totalPageCount: (int)Math.Ceiling((decimal)totalRows / pageLength),
                totalRowCount: totalRows,
                items: rows
                );
            return result;
        }
    }
}
