using Nucleus.Core.Contracts.Models;
using Nucleus.Vlog.Contracts.Models;
using Nucleus.Vlog.Contracts.Models.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nucleus.Vlog.Contracts.Managers
{
    public interface ILessonManager
    {
        Task<LessonModel?> GetLesson(string lessonId);

        Task<PagedResult<LessonModel>> GetLessonsPagedAsync(LessonsFilter lessonsFilter);

        Task<ResponseModel<LessonModel?>> SaveLessonAsync(LessonModel lesson);
    }
}