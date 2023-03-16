using Nucleus.Core.Contracts.Models;
using Nucleus.Project.Contracts.Models;
using Nucleus.Project.Contracts.Models.Filters;
using Nucleus.Project.Contracts.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nucleus.Project.Contracts.Managers
{
    public interface IPublicProjectManager
    {
        Task<PagedResult<ProjectModel>> GetProjectsPagedAsync(ProjectFilter projectsFilter);
        Task<List<ProjectModel>> GetProjects();
        Task<ProjectModel?> GetProjectSlug(string slug);
        Task<List<ProjectModel>?> GetRecentProjects(int i);
    }
}
