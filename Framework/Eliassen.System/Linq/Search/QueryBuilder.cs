using Eliassen.System.Internal;
using Eliassen.System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Eliassen.System.Linq.Search
{
    public abstract class QueryBuilder
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
        private readonly ILogger _logger;

        public QueryBuilder(
            ISortBuilder<TModel> sortBuilder,
            IExpressionTreeBuilder<TModel> expressionBuilder,
            ILogger<QueryBuilder>? logger = null
            )
        {
            _sortBuilder = sortBuilder;
            _expressionBuilder = expressionBuilder;
            _logger = logger ?? new ConsoleLogger<QueryBuilder>();
        }

        public IOrderedQueryable<TModel> BuildFrom(IQueryable<TModel> query, ISearchQuery searchQuery, StringComparison stringComparison)
        {
            var searched = SearchBy(query, searchQuery, stringComparison, true);
            var filtered = FilterBy(searched, searchQuery, stringComparison);

            if (query.ToString() == filtered.ToString())
            {
                _logger.LogWarning(
                    $"No filtering detected: {{{nameof(query)}}}: {{{nameof(searchQuery)}}}",
                    query.ToString(),
                    searchQuery.ToString()
                    );
            }

            var sorted = SortBy(filtered, searchQuery);

            return sorted;
        }

        private IQueryable<TModel> SearchBy(IQueryable<TModel> query, ISearchTermQuery? search, StringComparison stringComparison, bool isSearchTerm)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));
            if (!string.IsNullOrWhiteSpace(search?.SearchTerm))
            {
                var searchTermExpression = _expressionBuilder.BuildExpression(search.SearchTerm, stringComparison, isSearchTerm);
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
                    var filterExpression = _expressionBuilder.GetPredicateExpression(item.Key, item.Value, stringComparison, false);
                    if (filterExpression != null)
                    {
                        query = query.Where(filterExpression);
                    }
                    else
                    {
                        _logger.LogWarning($"No filter mapped for property: {{name}} => {{filter}}", item.Key, item.Value);
                    }
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
