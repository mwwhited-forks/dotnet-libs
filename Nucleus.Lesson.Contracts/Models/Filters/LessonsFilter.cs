using Nucleus.Core.Persistence.Models;

namespace Nucleus.Lesson.Contracts.Models.Filters
{
#warning retire this
    public class LessonsFilter
    {
        public LessonsFilterItem? LessonFilters { get; set; }
        public PagingModel? PagingModel { get; set; }
    }
#warning retire this
    public class LessonsFilterItem
    {
        public string? InputValue { get; set; }
    }
}
