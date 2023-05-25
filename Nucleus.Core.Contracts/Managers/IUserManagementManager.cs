using Nucleus.Core.Contracts.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nucleus.Core.Contracts.Managers
{
    public interface IUserManagementManager
    {
        Task<ResponseModel<User>> SaveUserAsync(UserAction user);
        IQueryable<User> Query();
        Task<List<Module>> GetApplicationPermissionsAsync();
    }
}
