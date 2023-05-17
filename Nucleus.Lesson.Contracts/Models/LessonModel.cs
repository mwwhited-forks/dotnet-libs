using System;

namespace Nucleus.Lesson.Contracts.Models
{
    public class LessonModel
    {
        public string? LessonId { get; set; }
        public string? Title { get; set; }
        public string? MediaLink { get; set; }
        public string? Preview { get; set; }
        public string? PreviewImage { get; set; }
        public string? Slug { get; set; }
        public string? Content { get; set; }
        public Boolean? Enabled { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public long CreatedOnUnix { get; set; }
    }
}
