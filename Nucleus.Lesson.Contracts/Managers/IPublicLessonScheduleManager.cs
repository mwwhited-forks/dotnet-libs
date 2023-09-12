using Nucleus.Core.Contracts.Models;
using Nucleus.Lesson.Contracts.Models;
using Nucleus.Lesson.Contracts.Models.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nucleus.Lesson.Contracts.Managers
{
    public interface IPublicLessonScheduleManager
    {
#warning retire this
        Task<PagedResult<LessonScheduleModel>> GetLessonsPagedAsync(LessonsFilter lessonsFilter);
        Task<List<LessonScheduleModel>> GetLessons();
        //Task<LessonScheduleModel?> GetLessonSlug(string slug);
        Task<List<LessonScheduleModel>?> GetRecentLessons(int i);
        IQueryable<LessonScheduleModel> QueryLessons();
    }
}
