using MongoDB.Driver;
using Nucleus.Core.Persistence.Interfaces;
using Nucleus.Core.Persistence.Models;
using Nucleus.Core.Persistence.Collections;
using Nucleus.Core.Shared.Persistence.Services.ServiceHelpers;
using System.Linq;
using System.Threading.Tasks;

namespace Nucleus.Core.Persistence.Services
{

    public class UserService : IUserService
    {
        private readonly ICoreMongoDatabase _db;
        private readonly ProjectionDefinition<UserCollection, User>? _userProjection;
        private readonly BsonCollectionBuilder<UserAction, UserCollection> _userCollectionBuilder;

        public UserService(
            ICoreMongoDatabase db
            )
        {
            _db = db;

            _userCollectionBuilder = new BsonCollectionBuilder<UserAction, UserCollection>();
            _userProjection = Builders<UserCollection>.Projection.Expression(Projections.Users);
        }

        public IQueryable<User> Query() => _db.Users.AsQueryable().Select(Projections.Users);
        //        {
        //            var collection = _usersCollection;
        //            var bson = BsonDocument.Parse(@"{
        //      ""CreatedOn-Built"": {
        //          $add: [
        //            { $toLong: {$multiply:[ { $arrayElemAt: [""$createdOn"",1] }, 60, 1000 ]}},
        //            { $toLong: [{ $arrayElemAt: [""$createdOn"",0] }]}
        //          ]
        //      }
        //}");
        //            var projection = Builders<UserCollection>.Projection
        //                .Combine(bson)
        //                .Include(u => u.UserId)
        //                .Include(u => u.CreatedOn)
        //                ;
        //            var aggregate = _usersCollection.Aggregate().Project(projection);
        //            var items = aggregate.ToList();
        //            var x = 1;
        //            return _usersCollection.AsQueryable().Select(Projections.Users);
        //        }

        public Task<User?> GetByUserIdAsync(string userId) =>
            Task.FromResult(Query().FirstOrDefault(u => u.UserId == userId));
        public Task<User?> GetByUserNameAsync(string userName) =>
            Task.FromResult(Query().FirstOrDefault(u => u.UserName.ToLower() == userName.ToLower()));
        public Task<User?> GetByEmailAddressAsync(string emailAddress) =>
            Task.FromResult(Query().FirstOrDefault(u => u.EmailAddress.ToLower() == emailAddress.ToLower()));

        public async Task CreateAsync(UserAction user) =>
            await _db.Users.InsertOneAsync(_userCollectionBuilder.BuildCollection(user));

        public async Task UpdateAsync(UserAction user) =>
            await _db.Users.ReplaceOneAsync(x => x.UserId == user.UserId, _userCollectionBuilder.BuildCollection(user));

        public async Task RemoveAsync(string id) =>
            await _db.Users.DeleteOneAsync(x => x.UserId == id);

    }
}
