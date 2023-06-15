using MongoDB.Driver;
using Nucleus.Blog.Contracts.Models;
using Nucleus.Blog.Contracts.Models.Filters;
using Nucleus.Blog.Contracts.Services;
using Nucleus.Blog.Persistence.Collections;
using Nucleus.Core.Contracts.Models;
using Nucleus.Core.Shared.Persistence.Services.ServiceHelpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nucleus.Blog.Persistence.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogMongoDatabase _db;

        // Projection for a single blog (getting all fields)
        private ProjectionDefinition<BlogCollection, BlogModel>? _blogProjection { get; set; }
        // Projection for a multiple blogs (getting most fields)
        private ProjectionDefinition<BlogCollection, BlogModel>? _blogsProjection { get; set; }
        private BsonCollectionBuilder<BlogModel, BlogCollection> _blogCollectionBuilder { get; set; }


        public BlogService(
            IBlogMongoDatabase db
            )
        {
            _db = db;

            _blogCollectionBuilder = new BsonCollectionBuilder<BlogModel, BlogCollection>();

            BuildProjections();
        }

#warning retire this
        // need to extend/re-work this so I do not pass in multiple parameters to each method, just a proper filter item from the business layer
        private FilterDefinition<BlogCollection> GetBlogsPredicateBuilder(bool onlyActive, BlogsFilterItem? filterItems)
        {
            // Keeping this business logic in the access layer.  Cannot move it to the business layer yet
            // until I can create an extension that can translate for multiple database.  Moving this to db
            // layer forces you to include mongo drivers which will no longer make this a good solution to be
            // a hybrid database solution just by changing interfaces in the IOC
            var builder = Builders<BlogCollection>.Filter;
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

        private void BuildProjections()
        {
            // Need to find a better way to manage these mappings
            _blogProjection = Builders<BlogCollection>.Projection.Expression(item => new BlogModel()
            {
                BlogId = item.BlogId,
                Content = item.Content,
                Tags = item.Tags,
                Preview = item.Preview,
                Slug = item.Slug,
                Title = item.Title,
                Enabled = item.Enabled,
                Author = item.Author,
                CreatedOn = item.CreatedOn,
                //CreatedOnUnix = item.CreatedOn.ToUnixTimeMilliseconds()
            });
            _blogsProjection = Builders<BlogCollection>.Projection.Expression(item => new BlogModel()
            {
                BlogId = item.BlogId,
                Content = null,
                Tags = item.Tags,
                Preview = item.Preview,
                Slug = item.Slug,
                Title = item.Title,
                Enabled = item.Enabled,
                Author = item.Author,
                CreatedOn = item.CreatedOn,
                //CreatedOnUnix = item.CreatedOn.ToUnixTimeMilliseconds()
            });
        }

#warning retire this
        public async Task<List<BlogModel>> GetPagedAsync(PagingModel pagingModel, BlogsFilterItem? filterItems, bool onlyActive)
        {
            // TODO: Make an extension that does all of this pagination plumbing
            string sortDefinition = $"{{ {pagingModel.SortBy}: 1 }}";
            if (pagingModel.SortDirection == "descend")
                sortDefinition = $"{{ {pagingModel.SortBy}: -1 }}";

            return await _db.Blogs.Find(GetBlogsPredicateBuilder(onlyActive, filterItems))
                .Skip((pagingModel.CurrentPage - 1) * pagingModel.PageSize)
                .Limit(pagingModel.PageSize)
                .Sort(sortDefinition)
                .Project(_blogsProjection)
                .ToListAsync();
        }

#warning retire this
        public async Task<long> GetPagedCountAsync(PagingModel pagingModel, BlogsFilterItem? filterItems, bool onlyActive) =>
           await _db.Blogs.Find(GetBlogsPredicateBuilder(onlyActive, filterItems)).CountDocumentsAsync();

        public async Task<List<BlogModel>> GetRecentAsync(int i, bool onlyActive) =>
            await _db.Blogs.Find(_ => true)
                .Sort("{ \"createdOn\": -1}")
                .Limit(i)
                .Project(_blogsProjection).ToListAsync();

        public async Task<List<BlogModel>> GetAsync(bool onlyActive) =>
            await _db.Blogs.Find(x => (onlyActive == false) || (x.Enabled == true && onlyActive == true)).Project(_blogsProjection).ToListAsync();

        public async Task<BlogModel?> GetAsync(string id, bool onlyActive) =>
            await _db.Blogs.Find(x => x.BlogId == id).Project(_blogProjection).FirstOrDefaultAsync();

        public async Task<BlogModel?> GetSlugAsync(string slug, bool onlyActive) =>
            await _db.Blogs.Find(x => x.Slug == slug).Project(_blogProjection).FirstOrDefaultAsync();

        public async Task<BlogModel> CreateAsync(BlogModel newBlog)
        {
            BlogCollection blog = _blogCollectionBuilder.BuildCollection(newBlog);
            await _db.Blogs.InsertOneAsync(blog);
            newBlog.BlogId = blog.BlogId;
            return newBlog;
        }

        public async Task UpdateAsync(BlogModel updatedBlog) =>
            await _db.Blogs.ReplaceOneAsync(x => x.BlogId == updatedBlog.BlogId, _blogCollectionBuilder.BuildCollection(updatedBlog));

        public async Task RemoveAsync(string id) =>
            await _db.Blogs.DeleteOneAsync(x => x.BlogId == id);
        public IQueryable<BlogModel> Query() =>
            _db.Blogs.AsQueryable().Select(Projections.Blogs);

    }
}
