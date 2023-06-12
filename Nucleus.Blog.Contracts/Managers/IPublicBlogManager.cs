using Nucleus.Blog.Contracts.Models;
using Nucleus.Blog.Contracts.Models.Filters;
using Nucleus.Core.Persistence.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nucleus.Blog.Contracts.Managers
{
    public interface IPublicBlogManager
    {
        Task<List<BlogModel>> GetBlogs();
        Task<BlogModel?> GetBlog(string blogId);
        Task<BlogModel?> GetBlogSlug(string slug);
        Task<List<BlogModel>?> GetRecentBlogs(int i);
        IQueryable<BlogModel> QueryBlogs();

#warning retire this
        Task<PagedResult<BlogModel>> GetBlogsPagedAsync(BlogsFilter blogsFilter);
    }
}
