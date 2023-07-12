using Eliassen.MongoDB.Extensions;
using MongoDB.Driver;
using Nucleus.Blog.Persistence.Collections;

namespace Nucleus.Blog.Persistence.Services
{
    public interface IBlogMongoDatabase
    {
        [CollectionName("blogs")]
        IMongoCollection<BlogCollection> Blogs { get; }
    }
}
