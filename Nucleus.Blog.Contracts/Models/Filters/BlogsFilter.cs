using Nucleus.Core.Persistence.Models;
using Nucleus.Core.Persistence.Models.Filters;
using System;
using System.Collections.Generic;
using System.Text;

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
