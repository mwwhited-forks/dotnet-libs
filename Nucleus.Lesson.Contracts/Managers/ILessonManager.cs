using Nucleus.Core.Persistence.Models;
using Nucleus.Lesson.Contracts.Models;
using Nucleus.Lesson.Contracts.Models.Filters;
using System.Threading.Tasks;

namespace Nucleus.Lesson.Contracts.Managers
{
    public interface ILessonManager
    {
        Task<LessonModel?> GetLesson(string lessonId);

#warning retire this
        Task<PagedResult<LessonModel>> GetLessonsPagedAsync(LessonsFilter lessonsFilter);

        Task<ResponseModel<LessonModel?>> SaveLessonAsync(LessonModel lesson);
    }
}