using Nucleus.Core.Contracts.Models;
using Nucleus.Project.Contracts.Collections;
using Nucleus.Project.Contracts.Models;
using Nucleus.Project.Contracts.Models.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nucleus.Project.Contracts.Services
{
    public interface IProjectService
    {
        //TODO: restore
#warning RESTORE THIS FEATURE
        //Task<List<ProjectModel>> GetPagedAsync(PagingModel pagingModel, ProjectsFilterItem? filterItems, bool onlyActive);
        //TODO: restore
#warning RESTORE THIS FEATURE
        //Task<long> GetPagedCountAsync(PagingModel pagingModel, ProjectsFilterItem? filterItems, bool onlyActive);

        Task<List<ProjectModel>> GetAsync(bool onlyActive);

        Task<ProjectModel?> GetAsync(string id, bool onlyActive);

        Task<ProjectModel> CreateAsync(ProjectModel newProject);

        Task UpdateAsync(ProjectModel updatedProject);

        Task RemoveAsync(string id);

        Task<ProjectModel?> GetSlugAsync(string slug, bool onlyActive);

        Task<List<ProjectModel>> GetRecentAsync(int i, bool onlyActive);
    }
}
