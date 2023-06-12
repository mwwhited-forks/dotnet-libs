using Eliassen.MongoDB.Extensions;
using MongoDB.Driver;
using Nucleus.Project.Contracts.Collections;

namespace Nucleus.Project.Persistence.Sevices
{
    public interface IProjectMongoDatabase
    {
        [CollectionName("projects")]
        IMongoCollection<ProjectCollection> Projects { get; }
    }
}
