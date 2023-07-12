using Eliassen.MongoDB.Extensions;
using MongoDB.Driver;
using Nucleus.Core.Persistence.Collections;

namespace Nucleus.Core.Persistence.Services
{
    public interface ICoreMongoDatabase
    {
        [CollectionName("users")]
        IMongoCollection<UserCollection> Users { get; }
        [CollectionName("documents")]
        IMongoCollection<DocumentCollection> Documents { get; }
        [CollectionName("modules")]
        IMongoCollection<ModuleCollection> Modules { get; }
    }
}
