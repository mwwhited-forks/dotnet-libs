using Nucleus.Core.Contracts.Models;
using Nucleus.Lesson.Contracts.Models;
using Nucleus.Lesson.Contracts.Models.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nucleus.Lesson.Contracts.Managers
{
    public interface ILessonManager
    {
        Task<LessonModel?> GetLesson(string lessonId);
        Task<ResponseModel<LessonModel?>> SaveLessonAsync(LessonModel lesson);
    }
}