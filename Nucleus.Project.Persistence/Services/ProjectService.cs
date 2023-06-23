using MongoDB.Driver;
using Nucleus.Core.Contracts.Models;
using Nucleus.Core.Shared.Persistence.Services.ServiceHelpers;
using Nucleus.Project.Contracts.Models;
using Nucleus.Project.Contracts.Models.Filters;
using Nucleus.Project.Contracts.Persistence;
using Nucleus.Project.Persistence.Collections;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using ZstdSharp;

namespace Nucleus.Project.Persistence.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectMongoDatabase _db;

        private readonly ProjectionDefinition<ProjectCollection, ProjectModel>? _projectProjection;
        private readonly BsonCollectionBuilder<ProjectModel, ProjectCollection> _projectCollectionBuilder;

        public ProjectService(
            IProjectMongoDatabase db
            )
        {
            _db = db;

            _projectCollectionBuilder = new BsonCollectionBuilder<ProjectModel, ProjectCollection>();

            _projectProjection = Builders<ProjectCollection>.Projection.Expression(item => new ProjectModel()
            {
                ProjectId = item.ProjectId,
                Preview = item.Preview,
                Content = item.Content,
                ProjectLink = item.ProjectLink,
                ProjectImage = item.ProjectImage,
                Page = item.Page,
                Slug = item.Slug,
                Title = item.Title,
                Enabled = item.Enabled,
                CreatedOn = item.CreatedOn,
            });
        }

#warning retire this
        // need to extend/re-work this so I do not pass in multiple parameters to each method, just a proper filter item from the business layer
        private FilterDefinition<ProjectCollection> GetProjectsPredicateBuilder(bool onlyActive, ProjectsFilterItem? filterItems)
        {
            // Keeping this business logic in the access layer.  Cannot move it to the business layer yet
            // until I can create an extension that can translate for multiple database.  Moving this to db
            // layer forces you to include mongo drivers which will no longer make this a good solution to be
            // a hybrid database solution just by changing interfaces in the IOC
            var builder = Builders<ProjectCollection>.Filter;
            var filter = builder.Empty;

            if (onlyActive)
                filter &= builder.AnyEq("enabled", true);

            if (filterItems != null && !string.IsNullOrWhiteSpace(filterItems.InputValue))
            {
                var textSearch = builder.Text(filterItems.InputValue);
                filter &= textSearch;
            }

            return filter;
        }

#warning retire this
        public async Task<List<ProjectModel>> GetPagedAsync(PagingModel pagingModel, ProjectsFilterItem? filterItems, bool onlyActive)
        {
            // TODO: Make an extension that does all of this pagination plumbing
            string sortDefinition = $"{{ {RenderSortByName(pagingModel.SortBy)}: 1 }}";
            if (pagingModel.SortDirection == "descend")
                sortDefinition = $"{{ {RenderSortByName(pagingModel.SortBy)}: -1 }}";

            return await _db.Projects.Find(GetProjectsPredicateBuilder(onlyActive, filterItems))
                .Sort(sortDefinition)
                .Skip((pagingModel.CurrentPage - 1) * pagingModel.PageSize)
                .Limit(pagingModel.PageSize)
                .Project(_projectProjection)
                .ToListAsync();
        }

#warning retire this
        public async Task<long> GetPagedCountAsync(PagingModel pagingModel, ProjectsFilterItem? filterItems, bool onlyActive) =>

         await _db.Projects.Find(GetProjectsPredicateBuilder(onlyActive, filterItems)).CountDocumentsAsync();

        public async Task<List<ProjectModel>> GetAsync(bool onlyActive) =>
            await _db.Projects.Find(x => (onlyActive == false) || (x.Enabled == true && onlyActive == true)).Project(_projectProjection).ToListAsync();

        public async Task<ProjectModel?> GetAsync(string id, bool onlyActive) =>
            await _db.Projects.Find(x => x.ProjectId == id).Project(_projectProjection).FirstOrDefaultAsync();

        public async Task<ProjectModel?> GetSlugAsync(string slug, bool onlyActive) =>
            await _db.Projects.Find(x => x.Slug == slug).Project(_projectProjection).FirstOrDefaultAsync();

        public async Task<List<ProjectModel>> GetRecentAsync(int i, bool onlyActive) =>
          await _db.Projects.Find(_ => true)
              .Sort("{ \"createdOn.0\": -1}")
              .Limit(i)
              .Project(_projectProjection).ToListAsync();

        public async Task<ProjectModel> CreateAsync(ProjectModel newProject)
        {
            ProjectCollection project = _projectCollectionBuilder.BuildCollection(newProject);
            await _db.Projects.InsertOneAsync(project);
            newProject.ProjectId = project.ProjectId;
            return newProject;
        }

        public async Task UpdateAsync(ProjectModel updatedProject) =>
            await _db.Projects.ReplaceOneAsync(x => x.ProjectId == updatedProject.ProjectId, _projectCollectionBuilder.BuildCollection(updatedProject));

        public async Task RemoveAsync(string id) =>
            await _db.Projects.DeleteOneAsync(x => x.ProjectId == id);


        // Need to make this re-usable for all collection repositories  .. mongodb should handle datetimeoffset sorting better
        private static string? RenderSortByName(string? column)
        {
            if (column == null) return null;

            var pi = typeof(ProjectModel).GetProperty(column, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            if (pi != null && pi.PropertyType == typeof(DateTimeOffset))
            {
                return "\"" + column + ".0\"";
            }
            return column;
        }
    }
}
