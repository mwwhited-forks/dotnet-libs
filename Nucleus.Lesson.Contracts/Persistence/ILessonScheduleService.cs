using Nucleus.Core.Contracts.Models;
using Nucleus.Lesson.Contracts.Models;
using Nucleus.Lesson.Contracts.Models.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nucleus.Lesson.Contracts.Persistence
{
    public interface ILessonScheduleService
    {
#warning retire this

        Task<List<LessonScheduleModel>> GetPagedAsync(PagingModel pagingModel, LessonsFilterItem? filterItems, bool onlyActive);

#warning retire this
        Task<long> GetPagedCountAsync(PagingModel pagingModel, LessonsFilterItem? filterItems, bool onlyActive);

        Task<List<LessonScheduleModel>> GetAsync();

        Task<List<LessonScheduleModel>> GetRecentAsync(int i, bool onlyActive);

        Task<LessonScheduleModel?> GetAsync(string id);

        Task<LessonScheduleModel> CreateAsync(LessonScheduleModel newBlog);

        Task UpdateAsync(LessonScheduleModel updatedBlog);

        Task RemoveAsync(string id);
        IQueryable<LessonScheduleModel> Query();
    }
}
