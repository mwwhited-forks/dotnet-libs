using Nucleus.Core.Contracts.Models;
using Nucleus.Core.Contracts.Models.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nucleus.Core.Contracts.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAsync();

        //TODO: restore
#warning RESTORE THIS FEATURE
        //Task<List<User>> GetPagedAsync(PagingModel pagingModel, UserFilterItem filterItems);
        //TODO: restore
#warning RESTORE THIS FEATURE
        //Task<long> GetPagedCountAsync(PagingModel pagingModel, UserFilterItem? filterItems);

        Task<User?> GetAsync(string id);

        Task<User?> GetByEmailAddressAsync(string emailAddress);

        Task<User?> GetByUsernameAsync(string username);

        Task CreateAsync(UserAction user);

        Task UpdateAsync(UserAction user);

        Task RemoveAsync(string id);

        Task<List<Module>> GetModulesAsync();
    }
}
