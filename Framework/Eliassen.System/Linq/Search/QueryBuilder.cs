using Eliassen.System.Linq.Expressions;
using System;
using System.Linq;

namespace Eliassen.System.Linq.Search
{
    public interface IQueryBuilder<TModel>
    {
        IOrderedQueryable<TModel> BuildFrom(IQueryable<TModel> query, ISearchQuery searchQuery, StringComparison stringComparison);
        IPagedQueryResult<TModel> PageBy(IOrderedQueryable<TModel> query, IPageQuery? pager);
    }
    public class QueryBuilder
    {
        /// <summary>
        /// Default page size when not defined on request
        /// </summary>
        public const int DefaultPageSize = 10;
    }
    public class QueryBuilder<TModel> : QueryBuilder
    {
        private readonly ISortBuilder<TModel> _sortBuilder;
        private readonly IExpressionTreeBuilder<TModel> _expressionBuilder;

        public QueryBuilder(
            ISortBuilder<TModel> sortBuilder,
            IExpressionTreeBuilder<TModel> expressionBuilder
            )
        {
            _sortBuilder = sortBuilder;
            _expressionBuilder = expressionBuilder;
        }

        public IOrderedQueryable<TModel> BuildFrom(IQueryable<TModel> query, ISearchQuery searchQuery, StringComparison stringComparison)
        {
            var searched = SearchBy(query, searchQuery, stringComparison);
            var filtered = FilterBy(searched, searchQuery, stringComparison);
            var sorted = SortBy(filtered, searchQuery);
            return sorted;
        }

        private IQueryable<TModel> SearchBy(IQueryable<TModel> query, ISearchTermQuery? search, StringComparison stringComparison)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));
            if (!string.IsNullOrWhiteSpace(search?.SearchTerm))
            {
                var searchTermExpression = _expressionBuilder.BuildExpression(search.SearchTerm, stringComparison);
                if (searchTermExpression != null)
                    return query.Where(searchTermExpression);
            }
            return query;
        }

        private IQueryable<TModel> FilterBy(IQueryable<TModel> query, IFilterQuery? filter, StringComparison stringComparison)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));
            if (filter?.Filter != null)
            {
                foreach (var item in filter.Filter)
                {
                    var filterExpression = _expressionBuilder.GetPredicateExpression(item.Key, item.Value, stringComparison);
                    if (filterExpression != null)
                        query = query.Where(filterExpression);
                }
            }
            return query;
        }

        private IOrderedQueryable<TModel> SortBy(IQueryable<TModel> query, ISortQuery? sortBy)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));

            query = sortBy != null ? _sortBuilder.SortBy(query, sortBy, _expressionBuilder) : query;
            if (query is IOrderedQueryable<TModel> sorted)
                return sorted;
            return query.OrderBy(_ => 0);
        }

        public IPagedQueryResult<TModel> PageBy(IOrderedQueryable<TModel> query, IPageQuery? pager)
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
    }
}
