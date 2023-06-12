using Nucleus.Core.Persistence.Models;
using Nucleus.Project.Contracts.Managers;
using Nucleus.Project.Contracts.Models;
using Nucleus.Project.Contracts.Models.Filters;
using Nucleus.Project.Contracts.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nucleus.Project.Business.Managers
{
    public class PublicProjectManager : IPublicProjectManager
    {

        private readonly IProjectService _projectService;

        public PublicProjectManager(IProjectService projectService)
        {
            _projectService = projectService;
        }

#warning retire this
        public async Task<PagedResult<ProjectModel>> GetProjectsPagedAsync(ProjectFilter projectsFilter)
        {
            List<ProjectModel> Projects = await _projectService.GetPagedAsync(projectsFilter.PagingModel, projectsFilter.ProjectFilters, false);
            PagedResult<ProjectModel> result = new PagedResult<ProjectModel>()
            {
                CurrentPage = projectsFilter.PagingModel.CurrentPage,
                PageSize = projectsFilter.PagingModel.PageSize,
                Results = Projects,
                RowCount = await _projectService.GetPagedCountAsync(projectsFilter.PagingModel, projectsFilter.ProjectFilters, false),
                PageCount = Projects.Count
            };
            return result;
        }

        public async Task<List<ProjectModel>> GetProjects() =>
            await _projectService.GetAsync(true);

        public async Task<ProjectModel?> GetProjectSlug(string slug) =>
         await _projectService.GetSlugAsync(slug, true);

        public async Task<List<ProjectModel>?> GetRecentProjects(int i) =>
            await _projectService.GetRecentAsync(i, true);
    }
}
