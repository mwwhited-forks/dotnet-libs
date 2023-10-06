using System;

namespace Nucleus.Project.Contracts.Models
{
    public class ProjectModel
    {
        public string? ProjectId { get; set; }
        public string? Title { get; set; }
        public string? ProjectLink { get; set; }
        public string? ProjectImage { get; set; }
        public string? Slug { get; set; }
        public string? Preview { get; set; }
        public string? Content { get; set; }
        public string? Page { get; set; }
        public Boolean? Enabled { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        //public long CreatedOnUnix { get; set; }
    }
}
