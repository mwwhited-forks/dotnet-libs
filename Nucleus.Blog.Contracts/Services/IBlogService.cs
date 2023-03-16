using Nucleus.Blog.Contracts.Models;
using Nucleus.Blog.Contracts.Models.Filters;
using Nucleus.Core.Contracts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nucleus.Blog.Contracts.Services
{
    public interface IBlogService
    {
        Task<List<BlogModel>> GetPagedAsync(PagingModel pagingModel, BlogsFilterItem? filterItems, bool onlyActive);

        Task<long> GetPagedCountAsync(PagingModel pagingModel, BlogsFilterItem? filterItems, bool onlyActive);

        Task<List<BlogModel>> GetAsync(bool onlyActive);

        Task<BlogModel?> GetSlugAsync(string slug, bool onlyActive);

        Task<List<BlogModel>> GetRecentAsync(int i, bool onlyActive);

        Task<BlogModel?> GetAsync(string id, bool onlyActive);

        Task<BlogModel> CreateAsync(BlogModel newBlog);

        Task UpdateAsync(BlogModel updatedBlog);

        Task RemoveAsync(string id);
    }
}
