using Nucleus.Blog.Contracts.Models;
using Nucleus.Blog.Contracts.Models.Filters;
using Nucleus.Core.Persistence.Models;
using System.Threading.Tasks;

namespace Nucleus.Blog.Contracts.Managers
{
    public interface IBlogManager
    {
        Task<BlogModel?> GetBlog(string blogId);
        Task<ResponseModel<BlogModel?>> SaveBlogAsync(BlogModel blog);


#warning retire this
        Task<PagedResult<BlogModel>> GetBlogsPagedAsync(BlogsFilter blogsFilter);
    }
}
