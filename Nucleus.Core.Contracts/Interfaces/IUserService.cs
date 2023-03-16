using Nucleus.Core.Contracts.Models;
using Nucleus.Core.Contracts.Models.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nucleus.Core.Contracts.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAsync();

        Task<List<User>> GetPagedAsync(PagingModel pagingModel, UserFilterItem filterItems);

        Task<long> GetPagedCountAsync(PagingModel pagingModel, UserFilterItem? filterItems);

        Task<User?> GetAsync(string id);

        Task<User?> GetByEmailAddressAsync(string emailAddress);

        Task<User?> GetByUsernameAsync(string username);

        Task CreateAsync(UserAction user);

        Task UpdateAsync(UserAction user);

        Task RemoveAsync(string id);

        Task<List<Module>> GetModulesAsync();
    }
}
