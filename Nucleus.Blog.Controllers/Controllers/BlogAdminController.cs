using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nucleus.AspNetCore.Mvc.Attributes;
using Nucleus.Blog.Contracts.Managers;
using Nucleus.Blog.Contracts.Models;
using Nucleus.Core.Contracts;

namespace Nucleus.Blog.Controllers.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BlogAdminController : ControllerBase
    {
        private IBlogManager _blogManager { get; set; }

        public BlogAdminController(IBlogManager blogManager)
        {
            _blogManager = blogManager;
        }

        //TODO: restore
#warning RESTORE THIS FEATURE
        //[HttpPost("Blogs")]
        //[ApplicationRight(Rights.Blog.Manager)]
        //public async Task<IActionResult> GetAllBlogsPagedAsync(BlogsFilter filter) =>
        //    new JsonResult(await _blogManager.GetBlogsPagedAsync(filter));

        [HttpGet("Blog/{id}")]
        [ApplicationRight(Rights.Blog.Manager)]
        public async Task<IActionResult> GetAsync(string id) =>
            new JsonResult(await _blogManager.GetBlog(id));

        [HttpPost("Save")]
        [ApplicationRight(Rights.Blog.Manager)]
        public async Task<IActionResult> SaveAsync(BlogModel blog) =>
            new JsonResult(await _blogManager.SaveBlogAsync(blog));

    }
}
