using Nucleus.Core.Contracts.Models;
using Nucleus.Project.Contracts.Models;
using Nucleus.Project.Contracts.Models.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nucleus.Project.Contracts.Managers
{
    public interface IProjectManager
    {
        Task<List<ProjectModel>> GetProjects();
        Task<ProjectModel?> GetProject(string ProjectId);
        Task<PagedResult<ProjectModel>> GetProjectsPagedAsync(ProjectFilter projectsFilter);
        Task<ResponseModel<ProjectModel?>> SaveProjectAsync(ProjectModel project);
    }
}
