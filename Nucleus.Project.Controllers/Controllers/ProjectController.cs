using Microsoft.AspNetCore.Mvc;
using Nucleus.Project.Contracts.Managers;
using Nucleus.Project.Contracts.Models.Filters;

namespace Nucleus.Project.Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IPublicProjectManager _publicProjectManager;

        public ProjectController(IPublicProjectManager publicProjectManager)
        {
            _publicProjectManager = publicProjectManager;
        }

#warning retire this
        [HttpPost("Projects")]
        public async Task<IActionResult> GetAllBlogsPagedAsync(ProjectFilter filter) =>
            new JsonResult(await _publicProjectManager.GetProjectsPagedAsync(filter));

        [HttpGet("Slug/{id}")]
        public async Task<IActionResult> GetProjectSlug(string id) =>
            new JsonResult(await _publicProjectManager.GetProjectSlug(id));

        [HttpGet("RecentProjects/{id}")]
        public async Task<IActionResult> GetRecentProjects(int id) =>
            new JsonResult(await _publicProjectManager.GetRecentProjects(id));

    }
}
