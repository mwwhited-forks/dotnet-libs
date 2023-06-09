using System;
using Eliassen.System.Linq.Search;

namespace Eliassen.System.ComponentModel.Search
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SearchTermDefaultAttribute : Attribute, ISearchQueryIntercept
    {
        public SearchTermDefaults Default { get; }

        public SearchTermDefaultAttribute(SearchTermDefaults @default)
        {
            Default = @default;
        }

        public ISearchQuery Intercept(ISearchQuery searchQuery)
        {
            if (searchQuery is SearchQuery query &&
                query.SearchTerm != null
                )
            {
                var searchTerm = query.SearchTerm;
                if (searchTerm.StartsWith('"') && searchTerm.EndsWith('"'))
                {
                    return query with { SearchTerm = searchTerm[1..^1] };
                }

                if (!searchTerm.Contains('*'))
                {
                    return query with
                    {
                        SearchTerm = Default switch
                        {
                            SearchTermDefaults.StartsWith => searchTerm + "*",
                            SearchTermDefaults.EndsWith => "*" + searchTerm,
                            SearchTermDefaults.Contains => "*" + searchTerm + "*",
                            _ => searchTerm,
                        }
                    };
                }
            }
            return searchQuery;
        }
    }
}
