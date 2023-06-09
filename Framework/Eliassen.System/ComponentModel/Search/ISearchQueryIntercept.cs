using Eliassen.System.Linq.Search;

namespace Eliassen.System.ComponentModel.Search
{
    public interface ISearchQueryIntercept
    {
        ISearchQuery Intercept(ISearchQuery searchQuery);
    }
}
