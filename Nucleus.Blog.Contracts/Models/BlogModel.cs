using Eliassen.System.ComponentModel.Search;
using System;
using System.Collections.Generic;

namespace Nucleus.Blog.Contracts.Models
{
    [SearchTermDefault(SearchTermDefaults.Contains)]
    public class BlogModel
    {
        [IgnoreStringComparisonReplacement]
        [NotSearchable]
        public string? BlogId { get; set; }
        [DefaultSort(priority: 1)]
        public string? Title { get; set; }
        public string? Slug { get; set; }
        public List<string?>? Tags { get; set; }
        public string? Preview { get; set; }
        public string? Content { get; set; }
        public bool? Enabled { get; set; }
        public string? Author { get; set; }
        [DefaultSort(priority: 0)]
        public DateTimeOffset CreatedOn { get; set; }
    }
}
