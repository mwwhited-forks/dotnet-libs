using Eliassen.System.ComponentModel.Search;
using System;
using System.Collections.Generic;

namespace Nucleus.Blog.Contracts.Models
{
    public class BlogModel
    {
        public string? BlogId { get; set; }
        public string? Title { get; set; }
        [DefaultSort(priority: 1)]
        public string? Slug { get; set; }
        public List<string?>? Tags { get; set; }
        public string? Preview { get; set; }
        public string? Content { get; set; }
        public bool? Enabled { get; set; }
        public string? Author { get; set; }
        [DefaultSort(priority: 0)]
        public DateTimeOffset CreatedOn { get; set; }
        public long CreatedOnUnix { get; set; }
    }
}
