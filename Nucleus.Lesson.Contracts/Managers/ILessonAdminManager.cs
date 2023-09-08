using Nucleus.Core.Contracts.Models;
using Nucleus.Lesson.Contracts.Models.Filters;
using Nucleus.Lesson.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleus.Lesson.Contracts.Managers
{
    public interface ILessonAdminManager
    {
        Task<LessonAdminModel?> GetLesson(string lessonId);

        #warning retire this
        Task<PagedResult<LessonAdminModel>> GetLessonsPagedAsync(LessonsFilter lessonsFilter);

        Task<ResponseModel<LessonAdminModel?>> SaveLessonAsync(LessonAdminModel lesson);
    }
}
