using Nucleus.Core.Contracts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nucleus.Core.Contracts.Managers
{
    public interface IIdentityManager
    {
        Task<List<UserIdentityModel>?> GetGraphUsersByEmail(string emailAddress);
        Task<string> CreateIdentityUserAsync(string email, string firstName, string lastName);
        Task<bool> RemoveIdentityUserAsync(string objectId);
    }
}
