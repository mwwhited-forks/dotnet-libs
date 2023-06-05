using Eliassen.System.Accessors;
using Eliassen.System.Linq.Search;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Eliassen.AspNetCore.Mvc.Filters
{
    public class SearchQueryResultFilter : IResultFilter
    {
        private readonly ISearchQueryAccessor _searchQuery;
        private readonly ILogger _logger;
        private readonly ILoggerFactory _loggerFactory;

        public SearchQueryResultFilter(
            ISearchQueryAccessor searchQuery,
            ILogger<SearchQueryResultFilter> logger,
            ILoggerFactory loggerFactory
            )
        {
            _searchQuery = searchQuery;
            _logger = logger;
            _loggerFactory = loggerFactory;
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is Microsoft.AspNetCore.Mvc.ObjectResult objectResult &&
                objectResult.Value is IQueryable query)
            {

                _logger.LogInformation($"Base Query: {{{nameof(query)}}}", query.ToString());
                if (_searchQuery.SearchQuery != null)
                {
                    objectResult.Value = query.ExecuteBy(_searchQuery.SearchQuery);
                }
                else
                {
                    _logger.LogWarning($"No {nameof(_searchQuery.SearchQuery)} found, results will not be filtered");
                }
            }
        }
    }
}
