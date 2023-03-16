using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Nucleus.Core.Shared.Persistence.Services.ServiceHelpers;
using Nucleus.Vlog.Contracts.Services;
using Nucleus.Vlog.Contracts.Collections;
using Nucleus.Vlog.Contracts.Models;
using Nucleus.Vlog.Contracts.Models.Filters;
using Nucleus.Core.Contracts.Models;
using Nucleus.Vlog.Contracts.Collections.DbSettings;

namespace Nucleus.Vlog.Persistence.Services
{
    public class VlogService : IVlogService
    {
        private readonly IMongoCollection<VlogCollection> _vlogsCollection;
        private ProjectionDefinition<VlogCollection, VlogModel>? _vlogProjection { get; set; }
        private BsonCollectionBuilder<VlogModel, VlogCollection> _vlogCollectionBuilder { get; set; }

        public VlogService(IOptions<VlogDatabaseSettings> vlogDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                vlogDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                vlogDatabaseSettings.Value.DatabaseName);

            _vlogsCollection = mongoDatabase.GetCollection<VlogCollection>(
                vlogDatabaseSettings.Value.VlogsCollectionName);

            _vlogCollectionBuilder = new BsonCollectionBuilder<VlogModel, VlogCollection>();

            BuildProjections();
        }

        private void BuildProjections()
        {
            _vlogProjection = Builders<VlogCollection>.Projection.Expression(item => new VlogModel()
            {
                VlogId = item.VlogId,
                Content = item.Content,
                Slug = item.Slug,
                MediaLink = item.MediaLink,
                PreviewImage= item.PreviewImage,
                Preview = item.Preview,
                Title = item.Title,
                CreatedOn = item.CreatedOn,
                Enabled = item.Enabled,
                CreatedOnUnix = item.CreatedOn.ToUnixTimeMilliseconds()
            });
        }

        // need to extend/re-work this so I do not pass in multiple parameters to each method, just a proper filter item from the business layer
        private FilterDefinition<VlogCollection> GetVlogsPredicateBuilder(bool onlyActive, VlogsFilterItem? filterItems)
        {
            // Keeping this business logic in the access layer.  Cannot move it to the business layer yet
            // until I can create an extension that can translate for multiple database.  Moving this to db
            // layer forces you to include mongo drivers which will no longer make this a good solution to be
            // a hybrid database solution just by changing interfaces in the IOC
            var builder = Builders<VlogCollection>.Filter;
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

        public async Task<List<VlogModel>> GetPagedAsync(PagingModel pagingModel, VlogsFilterItem? filterItems, bool onlyActive)
        {
            // TODO: Make an extension that does all of this pagination plumbing
            string sortDefinition = $"{{ {pagingModel.SortBy}: 1 }}";
            if (pagingModel.SortDirection == "descend")
                sortDefinition = $"{{ {pagingModel.SortBy}: -1 }}";

            return await _vlogsCollection.Find(GetVlogsPredicateBuilder(onlyActive, filterItems))
                .Skip((pagingModel.CurrentPage - 1) * pagingModel.PageSize)
                .Limit(pagingModel.PageSize)
                .Sort(sortDefinition)
                .Project(_vlogProjection)
                .ToListAsync();
        }

        public async Task<long> GetPagedCountAsync(PagingModel pagingModel, VlogsFilterItem? filterItems, bool onlyActive) =>
           await _vlogsCollection.Find(GetVlogsPredicateBuilder(onlyActive, filterItems)).CountDocumentsAsync();

        public async Task<List<VlogModel>> GetAsync() =>
            await _vlogsCollection.Find(_ => true).Project(_vlogProjection).ToListAsync();

        public async Task<List<VlogModel>> GetRecentAsync(int i, bool onlyActive) =>
           await _vlogsCollection.Find(_ => true)
               .Sort("{ \"createdOn\": -1}")
               .Limit(i)
               .Project(_vlogProjection).ToListAsync();

        public async Task<VlogModel?> GetSlugAsync(string slug, bool onlyActive) =>
            await _vlogsCollection.Find(x => x.Slug == slug).Project(_vlogProjection).FirstOrDefaultAsync();

        public async Task<VlogModel?> GetAsync(string id) =>
            await _vlogsCollection.Find(x => x.VlogId == id).Project(_vlogProjection).FirstOrDefaultAsync();

        public async Task<VlogModel> CreateAsync(VlogModel newVlog)
        {
            VlogCollection vlog = _vlogCollectionBuilder.BuildCollection(newVlog);
            await _vlogsCollection.InsertOneAsync(vlog);
            newVlog.VlogId = vlog.VlogId;
            return newVlog;
        }

        public async Task UpdateAsync(VlogModel updatedVlog) =>
            await _vlogsCollection.ReplaceOneAsync(x => x.VlogId == updatedVlog.VlogId, _vlogCollectionBuilder.BuildCollection(updatedVlog));

        public async Task RemoveAsync(string id) =>
            await _vlogsCollection.DeleteOneAsync(x => x.VlogId == id);

    }
}
