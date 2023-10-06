using Nucleus.Core.Contracts.Models;
using Nucleus.Lesson.Contracts.Models;
using System.Threading.Tasks;

namespace Nucleus.Lesson.Contracts.Managers
{
    public interface ILessonScheduleManager
    {
        Task<LessonScheduleModel?> GetLesson(string lessonId);
        Task<ResponseModel<LessonScheduleModel?>> SaveLessonAsync(LessonScheduleModel lesson);
    }
}
