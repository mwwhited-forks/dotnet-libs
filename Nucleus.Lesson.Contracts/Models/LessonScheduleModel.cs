using Eliassen.System.ComponentModel.Search;
using System;

namespace Nucleus.Lesson.Contracts.Models
{
    [SearchTermDefault(SearchTermDefaults.Contains)]
    public class LessonScheduleModel
    {
        [NotSearchable]
        [IgnoreStringComparisonReplacement]
        public string? LessonId { get; set; }
        public string? Title { get; set; }
        public string? MediaLink { get; set; }
        public string? Preview { get; set; }
        public string? PreviewImage { get; set; }
        [DefaultSort(priority: 1)]

        public string? Slug { get; set; }
        public string? Content { get; set; }
        public Boolean? Enabled { get; set; }
        [DefaultSort(priority: 0)]

        public DateTimeOffset? CreatedOn { get; set; }
        public long CreatedOnUnix { get; set; }

        public string? Teacher { get; set; }
        public int? Duration { get; set; }

        public DateTimeOffset? StartDateTime { get; set; }
        public DateTimeOffset? EndDateTime { get; set; }

        public string[]? Tags { get; set; }

        public double Price { get; set; }

        public string[]? Goals { get; set; }

        public string? Repeat { get; set; }
    }

}
