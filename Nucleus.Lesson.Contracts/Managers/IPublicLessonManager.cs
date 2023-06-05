using Nucleus.Core.Contracts.Models;
using Nucleus.Lesson.Contracts.Models;
using Nucleus.Lesson.Contracts.Models.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nucleus.Lesson.Contracts.Managers
{
    public interface IPublicLessonManager
    {
#warning retire this
        Task<PagedResult<LessonModel>> GetLessonsPagedAsync(LessonsFilter lessonsFilter);
        Task<List<LessonModel>> GetLessons();
        Task<LessonModel?> GetLessonSlug(string slug);
        Task<List<LessonModel>?> GetRecentLessons(int i);
    }
}
