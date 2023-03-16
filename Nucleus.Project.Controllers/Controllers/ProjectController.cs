using Nucleus.Project.Contracts.Managers;
using Nucleus.Project.Contracts.Models.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Nucleus.Project.Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private IPublicProjectManager _publicProjectManager { get; set; }

        public ProjectController(IPublicProjectManager publicProjectManager)
        {
            _publicProjectManager = publicProjectManager;
        }

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
