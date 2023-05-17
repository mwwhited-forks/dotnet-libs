using Nucleus.Core.Contracts.Models;
using Nucleus.Vlog.Contracts.Models;
using Nucleus.Vlog.Contracts.Models.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nucleus.Vlog.Contracts.Managers
{
    public interface IPublicLessonManager
    {
        Task<PagedResult<LessonModel>> GetLessonsPagedAsync(LessonsFilter lessonsFilter);
        Task<List<LessonModel>> GetLessons();
        Task<LessonModel?> GetLessonSlug(string slug);
        Task<List<LessonModel>?> GetRecentLessons(int i);
    }
}
