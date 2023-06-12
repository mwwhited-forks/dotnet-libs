using Nucleus.Core.Persistence.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Nucleus.Core.Persistence.Managers
{
    public interface IUserManagementManager
    {
        Task<ResponseModel<User>> SaveUserAsync(UserAction user);
        IQueryable<User> QueryUsers();
        IQueryable<Module> QueryModules();
    }
}
