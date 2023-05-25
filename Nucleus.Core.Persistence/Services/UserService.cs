using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Nucleus.Core.Contracts.Collections;
using Nucleus.Core.Contracts.Interfaces;
using Nucleus.Core.Contracts.Models;
using Nucleus.Core.Contracts.Models.DbSettings;
using Nucleus.Core.Shared.Persistence.Services.ServiceHelpers;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Nucleus.Core.Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<UserCollection> _usersCollection;
        private readonly ProjectionDefinition<UserCollection, User>? _userProjection;
        private readonly BsonCollectionBuilder<UserAction, UserCollection> _userCollectionBuilder;

        public UserService(
            IOptions<UserDatabaseSettings> userDatabaseSettings,
            ILoggerFactory loggerFactory)
        {
            var clientSettings = MongoClientSettings.FromConnectionString(userDatabaseSettings.Value.ConnectionString);
            clientSettings.LoggingSettings = new MongoDB.Driver.Core.Configuration.LoggingSettings(loggerFactory);
            var mongoClient = new MongoClient(clientSettings);
            var mongoDatabase = mongoClient.GetDatabase(userDatabaseSettings.Value.DatabaseName);

            _usersCollection = mongoDatabase.GetCollection<UserCollection>(userDatabaseSettings.Value.UsersCollectionName);
            _userCollectionBuilder = new BsonCollectionBuilder<UserAction, UserCollection>();
            _userProjection = Builders<UserCollection>.Projection.Expression(Projections.Users);
        }

        public IQueryable<User> Query() =>
            _usersCollection.AsQueryable().Select(Projections.Users);

        public Task<User?> GetByUserIdAsync(string userId) =>
            Task.FromResult(Query().FirstOrDefault(u => u.UserId == userId));
        public Task<User?> GetByUserNameAsync(string userName) =>
            Task.FromResult(Query().FirstOrDefault(u => u.UserName.ToLower() == userName.ToLower()));
        public Task<User?> GetByEmailAddressAsync(string emailAddress) =>
            Task.FromResult(Query().FirstOrDefault(u => u.EmailAddress.ToLower() == emailAddress.ToLower()));

        public async Task CreateAsync(UserAction user) =>
            await _usersCollection.InsertOneAsync(_userCollectionBuilder.BuildCollection(user));

        public async Task UpdateAsync(UserAction user) =>
            await _usersCollection.ReplaceOneAsync(x => x.UserId == user.UserId, _userCollectionBuilder.BuildCollection(user));

        public async Task RemoveAsync(string id) =>
            await _usersCollection.DeleteOneAsync(x => x.UserId == id);

    }
}
