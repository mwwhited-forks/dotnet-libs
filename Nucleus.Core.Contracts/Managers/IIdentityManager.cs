using Nucleus.Core.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nucleus.Core.Persistence.Managers
{
    public interface IIdentityManager
    {
        Task<List<UserIdentityModel>?> GetGraphUsersByEmail(string emailAddress);
        Task<string> CreateIdentityUserAsync(string email, string firstName, string lastName);
        Task<bool> RemoveIdentityUserAsync(string objectId);
    }
}
