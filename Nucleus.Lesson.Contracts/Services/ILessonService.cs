using Nucleus.Core.Contracts.Models;
using Nucleus.Lesson.Contracts.Models;
using Nucleus.Lesson.Contracts.Models.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nucleus.Lesson.Contracts.Services
{
    public interface ILessonService
    {
#warning retire this

        Task<List<LessonModel>> GetPagedAsync(PagingModel pagingModel, LessonsFilterItem? filterItems, bool onlyActive);

#warning retire this
        Task<long> GetPagedCountAsync(PagingModel pagingModel, LessonsFilterItem? filterItems, bool onlyActive);

        Task<List<LessonModel>> GetAsync();

        Task<List<LessonModel>> GetRecentAsync(int i, bool onlyActive);

        Task<LessonModel?> GetSlugAsync(string slug, bool onlyActive);

        Task<LessonModel?> GetAsync(string id);

        Task<LessonModel> CreateAsync(LessonModel newBlog);

        Task UpdateAsync(LessonModel updatedBlog);

        Task RemoveAsync(string id);
    }
}
