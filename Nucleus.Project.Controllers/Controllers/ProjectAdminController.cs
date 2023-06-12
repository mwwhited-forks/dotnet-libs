using Eliassen.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nucleus.Core.Persistence;
using Nucleus.Project.Contracts.Managers;
using Nucleus.Project.Contracts.Models;
using Nucleus.Project.Contracts.Models.Filters;

namespace Nucleus.Project.Controllers.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectAdminController : ControllerBase
    {
        private readonly IProjectManager _projectManager;

        public ProjectAdminController(IProjectManager projectManager)
        {
            _projectManager = projectManager;
        }

#warning retire this
        [Obsolete]
        [HttpPost("Projects")]
        [ApplicationRight(Rights.Project.Manager)]
        public async Task<IActionResult> GetAllProjectsPagedAsync(ProjectFilter filter) =>
            new JsonResult(await _projectManager.GetProjectsPagedAsync(filter));

        [HttpGet("Project/{id}")]
        [ApplicationRight(Rights.Project.Manager)]
        public async Task<IActionResult> GetAsync(string id) =>
            new JsonResult(await _projectManager.GetProject(id));

        [HttpPost("Save")]
        [ApplicationRight(Rights.Project.Manager)]
        public async Task<IActionResult> SaveAsync(ProjectModel project) =>
            new JsonResult(await _projectManager.SaveProjectAsync(project));

    }
}
