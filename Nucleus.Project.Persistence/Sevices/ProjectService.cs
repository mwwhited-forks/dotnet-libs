using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Nucleus.Core.Shared.Persistence.Services.ServiceHelpers;
using Nucleus.Project.Contracts.Collections;
using Nucleus.Project.Contracts.Collections.DbSettings;
using Nucleus.Project.Contracts.Models;
using Nucleus.Project.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nucleus.Project.Persistence.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IMongoCollection<ProjectCollection> _projectsCollection;
        private ProjectionDefinition<ProjectCollection, ProjectModel>? _projectProjection { get; set; }
        private BsonCollectionBuilder<ProjectModel, ProjectCollection> _projectCollectionBuilder { get; set; }

        public ProjectService(IOptions<ProjectDatabaseSettings> projectDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                projectDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                projectDatabaseSettings.Value.DatabaseName);

            _projectsCollection = mongoDatabase.GetCollection<ProjectCollection>(
                projectDatabaseSettings.Value.ProjectsCollectionName);

            _projectCollectionBuilder = new BsonCollectionBuilder<ProjectModel, ProjectCollection>();

            BuildProjections();
        }

        private void BuildProjections()
        {
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
                CreatedOnUnix = item.CreatedOn.ToUnixTimeMilliseconds()
            });
        }

        //TODO: restore
#warning RESTORE THIS FEATURE
        // need to extend/re-work this so I do not pass in multiple parameters to each method, just a proper filter item from the business layer
        //private FilterDefinition<ProjectCollection> GetProjectsPredicateBuilder(bool onlyActive, ProjectsFilterItem? filterItems)
        //{
        //    // Keeping this business logic in the access layer.  Cannot move it to the business layer yet
        //    // until I can create an extension that can translate for multiple database.  Moving this to db
        //    // layer forces you to include mongo drivers which will no longer make this a good solution to be
        //    // a hybrid database solution just by changing interfaces in the IOC
        //    var builder = Builders<ProjectCollection>.Filter;
        //    var filter = builder.Empty;

        //    if (onlyActive)
        //        filter &= builder.AnyEq("enabled", true);

        //    if (filterItems != null && !string.IsNullOrWhiteSpace(filterItems.InputValue))
        //    {
        //        var textSearch = builder.Text(filterItems.InputValue);
        //        filter &= textSearch;
        //    }

        //    return filter;
        //}

        //TODO: restore
#warning RESTORE THIS FEATURE
        //public async Task<List<ProjectModel>> GetPagedAsync(PagingModel pagingModel, ProjectsFilterItem? filterItems, bool onlyActive)
        //{
        //    // TODO: Make an extension that does all of this pagination plumbing
        //    string sortDefinition = $"{{ {renderSortByName(pagingModel.SortBy)}: 1 }}";
        //    if (pagingModel.SortDirection == "descend")
        //        sortDefinition = $"{{ {renderSortByName(pagingModel.SortBy)}: -1 }}";

        //    return await _projectsCollection.Find(GetProjectsPredicateBuilder(onlyActive, filterItems))
        //        .Sort(sortDefinition)
        //        .Skip((pagingModel.CurrentPage - 1) * pagingModel.PageSize)
        //        .Limit(pagingModel.PageSize)
        //        .Project(_projectProjection)
        //        .ToListAsync();
        //}

        //TODO: restore
#warning RESTORE THIS FEATURE
        //public async Task<long> GetPagedCountAsync(PagingModel pagingModel, ProjectsFilterItem? filterItems, bool onlyActive) =>
        //  await _projectsCollection.Find(GetProjectsPredicateBuilder(onlyActive, filterItems)).CountDocumentsAsync();

        public async Task<List<ProjectModel>> GetAsync(bool onlyActive) =>
            await _projectsCollection.Find(x => (onlyActive == false) || (x.Enabled == true && onlyActive == true)).Project(_projectProjection).ToListAsync();

        public async Task<ProjectModel?> GetAsync(string id, bool onlyActive) =>
            await _projectsCollection.Find(x => x.ProjectId == id).Project(_projectProjection).FirstOrDefaultAsync();

        public async Task<ProjectModel?> GetSlugAsync(string slug, bool onlyActive) =>
            await _projectsCollection.Find(x => x.Slug == slug).Project(_projectProjection).FirstOrDefaultAsync();

        public async Task<List<ProjectModel>> GetRecentAsync(int i, bool onlyActive) =>
          await _projectsCollection.Find(_ => true)
              .Sort("{ \"createdOn.0\": -1}")
              .Limit(i)
              .Project(_projectProjection).ToListAsync();

        public async Task<ProjectModel> CreateAsync(ProjectModel newProject)
        {
            ProjectCollection project = _projectCollectionBuilder.BuildCollection(newProject);
            await _projectsCollection.InsertOneAsync(project);
            newProject.ProjectId = project.ProjectId;
            return newProject;
        }

        public async Task UpdateAsync(ProjectModel updatedProject) =>
            await _projectsCollection.ReplaceOneAsync(x => x.ProjectId == updatedProject.ProjectId, _projectCollectionBuilder.BuildCollection(updatedProject));

        public async Task RemoveAsync(string id) =>
            await _projectsCollection.DeleteOneAsync(x => x.ProjectId == id);


        // Need to make this re-usable for all collection repositories  .. mongodb should handle datetimeoffset sorting better
        private string renderSortByName(string column)
        {
            System.Reflection.PropertyInfo pi = new ProjectModel().GetType().GetProperty(column[0].ToString().ToUpper() + column.Substring(1));
            if (pi != null && pi.PropertyType == typeof(DateTimeOffset))
            {
                return "\"" + column + ".0\""; 
            }
            return column;
        }
    }
}
