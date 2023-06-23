using Nucleus.Blog.Contracts.Managers;
using Nucleus.Blog.Contracts.Models;
using Nucleus.Blog.Contracts.Models.Filters;
using Nucleus.Blog.Contracts.Persistence;
using Nucleus.Core.Contracts.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nucleus.Blog.Business.Managers
{
    public class PublicBlogManager : IPublicBlogManager
    {

        private readonly IBlogService _blogService;

        public PublicBlogManager(IBlogService blogService)
        {
            _blogService = blogService;
        }

#warning retire this
        public async Task<PagedResult<BlogModel>> GetBlogsPagedAsync(BlogsFilter blogsFilter)
        {
            blogsFilter.PagingModel ??= PagingModel.Default;
            List<BlogModel> blogs = await _blogService.GetPagedAsync(blogsFilter.PagingModel, blogsFilter.BlogFilters, true);
            PagedResult<BlogModel> result = new PagedResult<BlogModel>()
            {
                CurrentPage = blogsFilter.PagingModel.CurrentPage,
                PageSize = blogsFilter.PagingModel.PageSize,
                Results = blogs,
                RowCount = await _blogService.GetPagedCountAsync(blogsFilter.PagingModel, blogsFilter.BlogFilters, true),
                PageCount = blogs.Count
            };
            return result;
        }

        public async Task<List<BlogModel>> GetBlogs() =>
            await _blogService.GetAsync(true);

        public async Task<BlogModel?> GetBlog(string blogId) =>
            await _blogService.GetAsync(blogId, true);

        public async Task<BlogModel?> GetBlogSlug(string slug) =>
           await _blogService.GetSlugAsync(slug, true);

        public async Task<List<BlogModel>?> GetRecentBlogs(int i) =>
            await _blogService.GetRecentAsync(i, true);

        public IQueryable<BlogModel> QueryBlogs() => _blogService.Query();
    }
}
