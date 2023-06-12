using Nucleus.Core.Persistence.Models;

namespace Nucleus.Project.Contracts.Models.Filters
{
#warning retire this
    public class ProjectFilter
    {
        public ProjectsFilterItem? ProjectFilters { get; set; }
        public PagingModel? PagingModel { get; set; }
    }
    public class ProjectsFilterItem
    {
        public string? InputValue { get; set; }
    }
}
