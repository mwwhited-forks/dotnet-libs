using Nucleus.Core.Contracts.Models;
using Nucleus.Lesson.Contracts.Models;
using Nucleus.Lesson.Contracts.Models.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nucleus.Lesson.Contracts.Managers
{
    public interface IPublicLessonAdminManager
    {
#warning retire this
        Task<PagedResult<LessonAdminModel>> GetLessonsPagedAsync(LessonsFilter lessonsFilter);
        Task<List<LessonAdminModel>> GetLessons();
        //Task<LessonAdminModel?> GetLessonSlug(string slug);
        Task<List<LessonAdminModel>?> GetRecentLessons(int i);
        IQueryable<LessonAdminModel> QueryLessons();
    }
}
