using Eliassen.System.ComponentModel.Search;
using Eliassen.System.Internal;
using Eliassen.System.Linq.Expressions;
using Eliassen.System.Reflection;
using Eliassen.System.ResponseModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Eliassen.System.Linq.Search;

/// <inheritdoc/>
public abstract class QueryBuilder
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
    /// 
    /// <param name="query"></param>
    /// <param name="searchQuery"></param>
    /// <returns></returns>
    public static IQueryResult Execute(IQueryable query, ISearchQuery searchQuery)
    {
        var queryType = Type.MakeGenericSignatureType(typeof(IQueryable<>), Type.MakeGenericMethodParameter(0)) ??
            throw new NotSupportedException($"{query.GetType()} is not supported");

        var methodSignature = typeof(QueryBuilder).GetMethod(
            nameof(Execute),
            1,
            new[] { queryType, typeof(ISearchQuery) }
            ) ??
            throw new NotSupportedException($"{query.GetType()} is not supported");

        var method = methodSignature.MakeGenericMethod(query.ElementType);
        var result = method.Invoke(null, new object[] { query, searchQuery }) ??
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
    public static IQueryResult<TModel> Execute<TModel>(IQueryable<TModel> query, ISearchQuery searchQuery) =>
        new QueryBuilder<TModel>(
            new SortBuilder<TModel>(),
            new ExpressionTreeBuilder<TModel>()
            ).ExecuteBy(query, searchQuery);
}
/// <inheritdoc/>
public class QueryBuilder<TModel> : QueryBuilder, IQueryBuilder<TModel>
{
    private readonly ISortBuilder<TModel> _sortBuilder;
    private readonly IExpressionTreeBuilder<TModel> _expressionBuilder;
    private readonly IEnumerable<IPostBuildExpressionVisitor> _postBuildVisitors;
    private readonly ILogger _logger;
    private readonly ICaptureResultMessage _messages;

    /// <inheritdoc/>
    public QueryBuilder(
        ISortBuilder<TModel> sortBuilder,
        IExpressionTreeBuilder<TModel> expressionBuilder,
        IEnumerable<IPostBuildExpressionVisitor>? postBuildVisitors = null,
        ILogger<QueryBuilder>? logger = null,
        ICaptureResultMessage? messages = null
        )
    {
        _sortBuilder = sortBuilder;
        _expressionBuilder = expressionBuilder;
        _postBuildVisitors = postBuildVisitors ?? Enumerable.Empty<IPostBuildExpressionVisitor>();
        _logger = logger ?? new ConsoleLogger<QueryBuilder>();
        _messages = messages ?? CaptureResultMessage.Default;
    }

    /// <inheritdoc/>
    public IQueryResult<TModel> ExecuteBy(
        IQueryable<TModel> query,
        ISearchQuery searchQuery
        )
    {
        var ordered = BuildFrom(query, searchQuery, StringComparison.InvariantCultureIgnoreCase);

        if (searchQuery.PageSize >= 0)
        {
            return PageBy(ordered, searchQuery);
        }
        else
        {
            _logger.LogInformation($"Execute : {{{nameof(query)}}}", ordered.ToString());
            return new QueryResult<TModel>(ordered)
            {
                Messages = _messages.Capture(),
            };
        }
    }

    /// <inheritdoc/>
    public IQueryResult ExecuteBy(IQueryable query, ISearchQuery searchQuery) =>
        ExecuteBy((query as IQueryable<TModel>) ?? throw new NotSupportedException(), searchQuery);

    private IOrderedQueryable<TModel> BuildFrom(
        IQueryable<TModel> query,
        ISearchQuery searchQuery,
        StringComparison stringComparison
        )
    {
        var queryIntercepts = query.ElementType.GetAttributes<ISearchQueryIntercept>();
        foreach (var interceptor in queryIntercepts)
        {
            _logger.LogDebug($"Intercepted by: {{{nameof(interceptor)}}}", interceptor);
            searchQuery = interceptor.Intercept(searchQuery);
        }

        _logger.LogInformation($"Build query for {{{nameof(searchQuery)}}}", searchQuery);

        var searched = SearchBy(query, searchQuery, stringComparison, true);
        var filtered = FilterBy(searched, searchQuery, stringComparison);

        if (query.ToString() == filtered.ToString())
        {
            _messages.Publish(new ResultMessage
            {
                Level = MessageLevels.Warning,
                Message = SearchQuery.Messages.NoSearchQueryFilter,
                MessageCode = SearchQuery.Messages.NoSearchQueryFilterCode,
            });
            _logger.LogWarning(
                $"No filtering detected: {{{nameof(query)}}}: {{{nameof(searchQuery)}}}",
                query.ToString(),
                searchQuery.ToString()
                );
        }

        var sorted = SortBy(filtered, searchQuery, stringComparison);

        if (_postBuildVisitors.Any())
        {
            var toVisit = sorted.Expression;
            foreach (var visitor in _postBuildVisitors)
            {
                _logger.LogDebug($"Visited by: {{{nameof(visitor)}}}", visitor);
                toVisit = visitor.Visit(toVisit);
            }
            sorted = (IOrderedQueryable<TModel>)query.Provider.CreateQuery<TModel>(toVisit);
        }

        return sorted;
    }

    private IPagedQueryResult<TModel> PageBy(
        IOrderedQueryable<TModel> query,
        IPageQuery? pager
        )
    {
        if (query == null) throw new ArgumentNullException(nameof(query));

        var pageLength = (pager?.PageSize ?? 0) <= 0 ? DefaultPageSize : pager?.PageSize ?? DefaultPageSize;
        var page = (pager?.CurrentPage ?? 0) < 0 ? 0 : pager?.CurrentPage ?? 0;
        var excludePageCount = pager?.ExcludePageCount ?? false;

        var totalRows = excludePageCount ? -1 : query.Count();

        var pagedQuery = query.Skip(page * pageLength).Take(pageLength);
        var rows = (pageLength, page) switch
        {
            _ when page < 0 => Array.Empty<TModel>(),
            (int.MaxValue, 0) => query.ToArray(),
            _ => pagedQuery.ToArray()
        };

        _logger.LogInformation($"Execute (paged): {{{nameof(query)}}}", pagedQuery.ToString());

        var result = new PagedQueryResult<TModel>(
            currentPage: page,
            totalPageCount: totalRows == -1 ? totalRows : (int)Math.Ceiling((decimal)totalRows / pageLength),
            totalRowCount: totalRows,
            items: rows
            )
        {
            Messages = _messages.Capture(),
        };
        return result;
    }

    private IQueryable<TModel> SearchBy(
        IQueryable<TModel> query,
        ISearchTermQuery? search,
        StringComparison stringComparison,
        bool isSearchTerm
        )
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

    private IQueryable<TModel> FilterBy(
        IQueryable<TModel> query,
        IFilterQuery? filter,
        StringComparison stringComparison
        )
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
                    _messages.Publish(new ResultMessage
                    {
                        Message = SearchQuery.Messages.NoPropertyFilter,
                        MessageCode = SearchQuery.Messages.NoPropertyFilterCode,
                        Context = item.Key,
                        MetaData = item.Value,
                    });
                    _logger.LogWarning($"No filter mapped for property: {{name}} => {{filter}}", item.Key, item.Value);
                }
            }
        }
        return query;
    }

    private IOrderedQueryable<TModel> SortBy(
        IQueryable<TModel> query,
        ISortQuery? sortBy,
        StringComparison keyStringComparer
        )
    {
        if (query == null) throw new ArgumentNullException(nameof(query));

        query = sortBy != null ? _sortBuilder.SortBy(query, sortBy, _expressionBuilder, keyStringComparer) : query;
        if (query is IOrderedQueryable<TModel> sorted)
            return sorted;
        return query.OrderBy(_ => 0);
    }
}
