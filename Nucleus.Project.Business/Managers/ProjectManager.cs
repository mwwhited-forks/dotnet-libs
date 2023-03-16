﻿using Nucleus.Project.Contracts.Managers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nucleus.Project.Contracts.Services;
using Nucleus.Project.Contracts.Models;
using Nucleus.Core.Contracts.Models;
using System;
using Nucleus.Project.Contracts.Models.Filters;

namespace Nucleus.Project.Business.Managers
{
    public class ProjectManager : IProjectManager
    {

        private readonly IProjectService _projectService;

        public ProjectManager(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<List<ProjectModel>> GetProjects()
        {
            return await _projectService.GetAsync(true);
        }
        public async Task<ProjectModel?> GetProject(string ProjectId) =>
           await _projectService.GetAsync(ProjectId, false);

        public async Task<PagedResult<ProjectModel>> GetProjectsPagedAsync(ProjectFilter projectsFilter)
        {
            List<ProjectModel> Projects = await _projectService.GetPagedAsync(projectsFilter.PagingModel, projectsFilter.ProjectFilters, false);
            PagedResult<ProjectModel>  result = new PagedResult<ProjectModel>()
            {
                CurrentPage = projectsFilter.PagingModel.CurrentPage,
                PageSize = projectsFilter.PagingModel.PageSize,
                Results = Projects,
                RowCount = await _projectService.GetPagedCountAsync(projectsFilter.PagingModel, projectsFilter.ProjectFilters, false),
                PageCount = Projects.Count
            };
            return result;
        }

        public async Task<ResponseModel<ProjectModel?>> SaveProjectAsync(ProjectModel project)
        {
            if (project == null || string.IsNullOrEmpty(project.Title) || string.IsNullOrEmpty(project.Content) || string.IsNullOrEmpty(project.Slug))
                return new ResponseModel<ProjectModel?>()
                {
                    IsSuccess = false,
                    Message = "Missing Required Fields"
                };
            ResponseModel<ProjectModel?> result = new ResponseModel<ProjectModel?>() { IsSuccess = true };
            if (String.IsNullOrEmpty(project.ProjectId))
            {
                project.CreatedOn = DateTimeOffset.Now;
                result.Response = await _projectService.CreateAsync(project);
                return result;
            }
            else
            {
                project.CreatedOn = DateTimeOffset.FromUnixTimeMilliseconds(project.CreatedOnUnix);
                await _projectService.UpdateAsync(project);
                result.Response = project;
                return result;
            }
        }
    }
}
