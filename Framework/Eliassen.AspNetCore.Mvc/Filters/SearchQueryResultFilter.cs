using Eliassen.System.Accessors;
using Eliassen.System.Linq.Search;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace Eliassen.AspNetCore.Mvc.Filters
{
    public class SearchQueryResultFilter : IResultFilter
    {
        private readonly ISearchQuery _searchQuery;

        public SearchQueryResultFilter(
            ISearchQuery searchQuery
            )
        {
            _searchQuery = searchQuery;
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            var search = _searchQuery;
            if (search == null)
                return;

            var result = context.Result;

            if (result is Microsoft.AspNetCore.Mvc.ObjectResult objectResult &&
                objectResult.Value != null)
            {
                objectResult.Value = objectResult.Value switch
                {
                    IQueryable query => query.ExecuteBy(search),
                    _ => objectResult.Value
                };
            }
        }
    }
}
