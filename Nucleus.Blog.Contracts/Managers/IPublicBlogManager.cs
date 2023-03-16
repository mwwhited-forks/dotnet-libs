using Nucleus.Blog.Contracts.Models;
using Nucleus.Blog.Contracts.Models.Filters;
using Nucleus.Core.Contracts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nucleus.Blog.Contracts.Managers
{
    public interface IPublicBlogManager
    {
        Task<List<BlogModel>> GetBlogs();
        Task<BlogModel?> GetBlog(string blogId);
        Task<BlogModel?> GetBlogSlug(string slug);
        Task<List<BlogModel>?> GetRecentBlogs(int i);
        Task<PagedResult<BlogModel>> GetBlogsPagedAsync(BlogsFilter blogsFilter);
    }
}
