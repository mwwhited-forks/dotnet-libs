using Nucleus.Core.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleus.Blog.Contracts.Models.Filters
{
    public class BlogsFilter
    {
        public BlogsFilterItem? BlogFilters { get; set; }
        public PagingModel? PagingModel { get; set; }
    }
    public class BlogsFilterItem
    {
        public string? InputValue { get; set; }
    }
}
