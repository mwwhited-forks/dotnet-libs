using Nucleus.Core.Contracts.Models;
using Nucleus.Lesson.Contracts.Models;
using Nucleus.Lesson.Contracts.Models.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nucleus.Lesson.Contracts.Persistence
{
    public interface ILessonAdminService
    {
#warning retire this

        Task<List<LessonAdminModel>> GetPagedAsync(PagingModel pagingModel, LessonsFilterItem? filterItems, bool onlyActive);

#warning retire this
        Task<long> GetPagedCountAsync(PagingModel pagingModel, LessonsFilterItem? filterItems, bool onlyActive);

        Task<List<LessonAdminModel>> GetAsync();

        Task<List<LessonAdminModel>> GetRecentAsync(int i, bool onlyActive);

        //Task<LessonAdminModel?> GetSlugAsync(string slug, bool onlyActive);

        Task<LessonAdminModel?> GetAsync(string id);

        Task<LessonAdminModel> CreateAsync(LessonAdminModel newBlog);

        Task UpdateAsync(LessonAdminModel updatedBlog);

        Task RemoveAsync(string id);
        IQueryable<LessonAdminModel> Query();
    }
}
