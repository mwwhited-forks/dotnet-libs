using Nucleus.Core.Contracts.Models;

namespace Nucleus.Vlog.Contracts.Models.Filters
{
    public class VlogsFilter
    {
        public VlogsFilterItem? VlogFilters { get; set; }
        public PagingModel? PagingModel { get; set; }
    }
    public class VlogsFilterItem
    {
        public string? InputValue { get; set; }
    }
}
