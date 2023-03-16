using Nucleus.Core.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleus.Project.Contracts.Models.Filters
{
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
