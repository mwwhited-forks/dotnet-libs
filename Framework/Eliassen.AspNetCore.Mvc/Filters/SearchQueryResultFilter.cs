using Eliassen.System.Accessors;
using Eliassen.System.Linq.Search;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Eliassen.AspNetCore.Mvc.Filters
{
    public class SearchQueryResultFilter : IResultFilter
    {
        private readonly ISearchQueryAccessor _searchQuery;
        private readonly ILogger _logger;
        private readonly IServiceProvider _serviceProvider;

        public SearchQueryResultFilter(
            ISearchQueryAccessor searchQuery,
            ILogger<SearchQueryResultFilter> logger,
            IServiceProvider serviceProvider
            )
        {
            _searchQuery = searchQuery;
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is Microsoft.AspNetCore.Mvc.ObjectResult objectResult &&
                objectResult.Value is IQueryable query)
            {
                var elementType = QueryBuilder.GetElementType(query);

                _logger.LogInformation($"Base Query: {{{nameof(query)}}} ({{{nameof(elementType)}}})", query.ToString(), elementType);

                if (elementType != null && _searchQuery.SearchQuery != null)
                {
                    var queryBuilder = (IQueryBuilder)_serviceProvider.GetRequiredService(typeof(IQueryBuilder<>).MakeGenericType(elementType));
                    objectResult.Value = queryBuilder.ExecuteBy(query, _searchQuery.SearchQuery);
                }
                else
                {
                    _logger.LogWarning(
                        $"No {nameof(_searchQuery.SearchQuery)} ({{{nameof(elementType)}}}) found, results will not be filtered",
                        elementType
                        );
                }
            }
        }
    }
}
