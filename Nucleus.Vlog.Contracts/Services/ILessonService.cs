using Nucleus.Core.Contracts.Models;
using Nucleus.Vlog.Contracts.Collections;
using Nucleus.Vlog.Contracts.Models;
using Nucleus.Vlog.Contracts.Models.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nucleus.Vlog.Contracts.Services
{
    public interface ILessonService
    {

        Task<List<LessonModel>> GetPagedAsync(PagingModel pagingModel, LessonsFilterItem? filterItems, bool onlyActive);

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
