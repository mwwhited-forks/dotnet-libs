using Nucleus.Core.Contracts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nucleus.Core.Contracts.Managers
{
    public interface IUserProfileManager
    {
        Task<IEnumerable<string>> GetRightsForUserIdAsync(string userId);
        Task<string?> GetUserIdForUserNameAsync(string userName);
        Task<User?> GetUserProfile(string objectId);
        Task<ResponseModel<User?>> UpdateUserProfile(string requesterObjectId, User user);
    }
}
