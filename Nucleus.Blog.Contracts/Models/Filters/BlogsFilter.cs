using Nucleus.Core.Contracts.Models;

namespace Nucleus.Blog.Contracts.Models.Filters
{
#warning retire this
    public class BlogsFilter
    {
        public BlogsFilterItem? BlogFilters { get; set; }
        public PagingModel? PagingModel { get; set; }
    }
#warning retire this
    public class BlogsFilterItem
    {
        public string? InputValue { get; set; }
    }
}
