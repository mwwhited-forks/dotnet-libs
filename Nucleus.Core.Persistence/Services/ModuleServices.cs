using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Nucleus.Core.Contracts.Collections;
using Nucleus.Core.Contracts.Interfaces;
using Nucleus.Core.Contracts.Models;
using Nucleus.Core.Contracts.Models.DbSettings;
using System.Linq;

namespace Nucleus.Core.Persistence.Services
{
    public class ModuleServices : IModuleService
    {
        private readonly IMongoCollection<ModuleCollection> _moduleCollection;
        //private readonly ProjectionDefinition<ModuleCollection, Module>? _moduleProjection;
        //private readonly BsonCollectionBuilder<Module, ModuleCollection> _moduleCollectionBuilder;

        public ModuleServices(
            IOptions<UserDatabaseSettings> userDatabaseSettings,
            IOptions<ModuleDatabaseSettings> moduleDatabaseSettings,
            ILoggerFactory loggerFactory)
        {
            var clientSettings = MongoClientSettings.FromConnectionString(userDatabaseSettings.Value.ConnectionString);
            clientSettings.LoggingSettings = new MongoDB.Driver.Core.Configuration.LoggingSettings(loggerFactory);
            var mongoClient = new MongoClient(clientSettings);
            var mongoDatabase = mongoClient.GetDatabase(userDatabaseSettings.Value.DatabaseName);

            _moduleCollection = mongoDatabase.GetCollection<ModuleCollection>(moduleDatabaseSettings.Value.ModuleCollectionName);
            //_moduleCollectionBuilder = new BsonCollectionBuilder<Module, ModuleCollection>();
            //_moduleProjection = Builders<ModuleCollection>.Projection.Expression(Projections.Modules);
        }

        public IQueryable<Module> Query() =>
            _moduleCollection.AsQueryable().Select(Projections.Modules);
    }
}
