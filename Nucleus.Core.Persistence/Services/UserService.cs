using Nucleus.Core.Contracts.Interfaces;
using Nucleus.Core.Contracts.Models;
using Nucleus.Core.Contracts.Models.DbSettings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nucleus.Core.Contracts.Models.Filters;
using Nucleus.Core.Shared.Persistence.Services.ServiceHelpers;
using Nucleus.Core.Contracts.Collections;

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
            IOptions<ModuleDatabaseSettings> moduleDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                userDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                userDatabaseSettings.Value.DatabaseName);

            _usersCollection = mongoDatabase.GetCollection<UserCollection>(userDatabaseSettings.Value.UsersCollectionName);
            _moduleCollection = mongoDatabase.GetCollection<ModuleCollection>(moduleDatabaseSettings.Value.ModuleCollectionName);

            _userCollectionBuilder = new BsonCollectionBuilder<UserAction, UserCollection>();
            _moduleCollectionBuilder = new BsonCollectionBuilder<Module, ModuleCollection>();

            BuildProjections();
        }

        private void BuildProjections()
        {
            _userProjection = Builders<UserCollection>.Projection.Expression(item => new User()
            {
                
                UserId = item.UserId,
                UserName = item.UserName,
                EmailAddress = item.EmailAddress,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Active = item.Active,
                UserModules = item.UserModules == null ? null : item.UserModules.Select(m => new UserModule()
                {
                    Code = m.Code,
                    Name = m.Name,
                    Roles = m.Roles == null ? null : m.Roles.ToArray().Select(r => new Role()
                    {
                        Code = r.Code,
                        Name = r.Name,
                        Rights = r.Rights == null ? null : r.Rights.ToArray().Select(ri => new PermissionBase()
                        {
                            Name = ri.Name,
                            Code = ri.Code
                        }).ToList()
                    }).ToList()
                }).ToList(),
                CreatedOn = item.CreatedOn
            });
            _moduleProjection = Builders<ModuleCollection>.Projection.Expression(item => new Module()
            {
                ModuleId = item.ModuleId,
                Roles = item.Roles.Select(r => new Role()
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

        private FilterDefinition<UserCollection> GetUsersPredicateBuilder(UserFilterItem? filterItems)
        {
            // Keeping this business logic in the access layer.  Cannot move it to the business layer yet
            // until I can create an extension that can translate for multiple database.  Moving this to db
            // layer forces you to include mongo drivers which will no longer make this a good solution to be
            // a hybrid database solution just by changing interfaces in the IOC
            var builder = Builders<UserCollection>.Filter;
            var filter = builder.Empty;
            if (!string.IsNullOrWhiteSpace(filterItems.InputValue))
            {
                var textSearch = builder.Text(filterItems.InputValue);
                filter &= textSearch;
            }
            if (!string.IsNullOrEmpty(filterItems.UserStatus) && filterItems.UserStatus != "-1")
            {
                var statusBuilder = builder.Where(e => (filterItems.UserStatus == null || filterItems.UserStatus == "-1" || (filterItems.UserStatus == "1" && e.Active == true) || (filterItems.UserStatus == "0" && e.Active == false)));
                filter &= statusBuilder;
            }
            if (!string.IsNullOrEmpty(filterItems.Module) && filterItems.Module != "module_authenticated")
            {
                var moduleBuilder = builder.Where(e =>  e.UserModules.Any(m => m.Code == filterItems.Module));
                filter &= moduleBuilder;
            }

            return filter;
        }

        public async Task<List<User>> GetPagedAsync(PagingModel pagingModel, UserFilterItem? filterItems)
        {
            // TODO: Make an extension that does all of this pagination plumbing
            string sortDefinition = $"{{ {pagingModel.SortBy}: 1 }}";
            if (pagingModel.SortDirection == "descend")
                sortDefinition = $"{{ {pagingModel.SortBy}: -1 }}";

            return await _usersCollection.Find(GetUsersPredicateBuilder(filterItems))
                .Skip((pagingModel.CurrentPage -1) * pagingModel.PageSize)
                .Limit(pagingModel.PageSize)
                .Sort(sortDefinition)
                .Project(_userProjection)
                .ToListAsync();
        }

        public async Task<long> GetPagedCountAsync(PagingModel pagingModel, UserFilterItem? filterItems) =>
            await _usersCollection.Find(GetUsersPredicateBuilder(filterItems)).CountDocumentsAsync();

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
