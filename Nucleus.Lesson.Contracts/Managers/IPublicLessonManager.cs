using Nucleus.Core.Contracts.Models;
using Nucleus.Lesson.Contracts.Models;
using Nucleus.Lesson.Contracts.Models.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nucleus.Lesson.Contracts.Managers
{
    public interface IPublicLessonManager
    {
#warning retire this
        Task<PagedResult<LessonModel>> GetLessonsPagedAsync(LessonsFilter lessonsFilter);
        Task<List<LessonModel>> GetLessons();
        Task<List<LessonModel>?> GetLessonsByLessonScheduleId(string scheduleId);
        Task<List<LessonModel>?> GetRecentLessons(int i);
        IQueryable<LessonModel> QueryLessons();
        void UpdateLesson(LessonModel lesson);
        void UpdateLessons(LessonModel[] lessons);
    }
}
