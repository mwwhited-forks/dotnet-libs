using Nucleus.Core.Busines.Attributes;
using Nucleus.Core.Contracts;
using Nucleus.Project.Contracts.Managers;
using Nucleus.Project.Contracts.Models;
using Nucleus.Project.Contracts.Models.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Nucleus.Project.Controllers.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectAdminController : ControllerBase
    {
        private IProjectManager _projectManager { get; set; }

        public ProjectAdminController(IProjectManager projectManager)
        {
            _projectManager = projectManager;
        }

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
