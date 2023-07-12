using Eliassen.MongoDB.Extensions;
using MongoDB.Driver;
using Nucleus.Project.Persistence.Collections;

namespace Nucleus.Project.Persistence.Services
{
    public interface IProjectMongoDatabase
    {
        [CollectionName("projects")]
        IMongoCollection<ProjectCollection> Projects { get; }
    }
}
