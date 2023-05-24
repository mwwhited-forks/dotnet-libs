using Nucleus.Core.Contracts.Interfaces;
using Nucleus.Core.Contracts.Models;
using Nucleus.Core.Contracts.Models.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nucleus.Core.Contracts.Managers
{
    public interface IUserManagementManager
    {
        Task<ResponseModel<User>> SaveUserAsync(UserAction user);
        //TODO: restore
#warning RESTORE THIS FEATURE
        //Task<PagedResult<User>> GetUsers(UsersFilter userFilter);
        Task<List<Module>> GetApplicationPermissionsAsync();
    }
}
