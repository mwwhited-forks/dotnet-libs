using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Nucleus.Core.Contracts.Collections;
using Nucleus.Core.Contracts.Interfaces;
using Nucleus.Core.Contracts.Models;
using Nucleus.Core.Contracts.Models.DbSettings;
using Nucleus.Core.Shared.Persistence.Services.ServiceHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Nucleus.Core.Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<UserCollection> _usersCollection;
        private readonly IMongoCollection<ModuleCollection> _moduleCollection;
        private ProjectionDefinition<UserCollection, User>? _userProjection { get; set; }
        private BsonCollectionBuilder<UserAction, UserCollection> _userCollectionBuilder { get; set; }
        private ProjectionDefinition<ModuleCollection, Module>? _moduleProjection { get; set; }
        private BsonCollectionBuilder<Module, ModuleCollection> _moduleCollectionBuilder { get; set; }

        public UserService(
            IOptions<UserDatabaseSettings> userDatabaseSettings,
            IOptions<ModuleDatabaseSettings> moduleDatabaseSettings,
            ILoggerFactory loggerFactory)
        {
            var clientSettings = MongoClientSettings.FromConnectionString(userDatabaseSettings.Value.ConnectionString);
            clientSettings.LoggingSettings = new MongoDB.Driver.Core.Configuration.LoggingSettings(loggerFactory);
            var mongoClient = new MongoClient(clientSettings);
            var mongoDatabase = mongoClient.GetDatabase(userDatabaseSettings.Value.DatabaseName);

            _usersCollection = mongoDatabase.GetCollection<UserCollection>(userDatabaseSettings.Value.UsersCollectionName);
            _moduleCollection = mongoDatabase.GetCollection<ModuleCollection>(moduleDatabaseSettings.Value.ModuleCollectionName);

            _userCollectionBuilder = new BsonCollectionBuilder<UserAction, UserCollection>();
            _moduleCollectionBuilder = new BsonCollectionBuilder<Module, ModuleCollection>();

            BuildProjections();
        }

        internal Expression<Func<UserCollection, User>> UserProjectionExpression => user => new User()
        {
            UserId = user.UserId,
            UserName = user.UserName,
            EmailAddress = user.EmailAddress,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Active = user.Active,
            UserModules = user.UserModules == null ? null : user.UserModules.Select(module => new UserModule()
            {
                Code = module.Code,
                Name = module.Name,
                Roles = module.Roles == null ? null : module.Roles.Select(role => new Role()
                {
                    Code = role.Code,
                    Name = role.Name,
                    Rights = role.Rights == null ? null : role.Rights.Select(right => new PermissionBase()
                    {
                        Name = right.Name,
                        Code = right.Code
                    }).ToList()
                }).ToList()
            }).ToList(),
            CreatedOn = user.CreatedOn
        };


        private void BuildProjections()
        {
            _userProjection = Builders<UserCollection>.Projection.Expression(UserProjectionExpression);
            _moduleProjection = Builders<ModuleCollection>.Projection.Expression(item => new Module()
            {
                ModuleId = item.ModuleId,
                Roles = item.Roles == null ? null : item.Roles.Select(r => new Role()
                {
                    Code = r.Code,
                    Name = r.Name,
                    Rights = r.Rights == null ? null : r.Rights.ToArray().Select(ri => new PermissionBase()
                    {
                        Name = ri.Name,
                        Code = ri.Code
                    }).ToList()
                }).ToList(),
                Name = item.Name,
                Code = item.Code
            });
        }

        public async Task<List<User>> GetAsync() =>
            await _usersCollection.Find(_ => true).Project(_userProjection).ToListAsync();

        public IQueryable<User> Query() =>
            _usersCollection.AsQueryable().Select(UserProjectionExpression);

        public async Task<User?> GetAsync(string id) =>
            await _usersCollection.Find(x => x.UserId == id).Project(_userProjection).FirstOrDefaultAsync();

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _usersCollection.Find(x => x.UserName == username).Project(_userProjection).FirstOrDefaultAsync();
        }

        public async Task<User?> GetByEmailAddressAsync(string emailAddress) =>
            await _usersCollection.Find(x => x.EmailAddress == emailAddress).SortByDescending(x => x.CreatedOn).Project(_userProjection).FirstOrDefaultAsync();

        public async Task CreateAsync(UserAction user) =>
            await _usersCollection.InsertOneAsync(_userCollectionBuilder.BuildCollection(user));

        public async Task UpdateAsync(UserAction user) =>
            await _usersCollection.ReplaceOneAsync(x => x.UserId == user.UserId, _userCollectionBuilder.BuildCollection(user));

        public async Task RemoveAsync(string id) =>
            await _usersCollection.DeleteOneAsync(x => x.UserId == id);

        public async Task<List<Module>> GetModulesAsync() =>
            await _moduleCollection.Find(_ => true).Project(_moduleProjection).ToListAsync();

    }
}
