using Eliassen.System.Linq.Search;

namespace Eliassen.System.Accessors
{
    public interface ISearchQueryAccessor
    {
        SearchQuery? SearchQuery { get; set; }
    }
}
