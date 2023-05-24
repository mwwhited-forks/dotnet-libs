using Nucleus.Core.Contracts.Interfaces;
using Nucleus.Core.Contracts.Managers;
using Nucleus.Core.Contracts.Models;
using Nucleus.Core.Contracts.Models.Keys;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nucleus.Core.Business.Managers
{
    public class UserProfileManager : IUserProfileManager
    {
        private IUserService _userService { get; set; }

        public UserProfileManager(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IEnumerable<string>> GetRightsForUserIdAsync(string userId)
        {
            User? user = await _userService.GetAsync(userId);

            if (user == null)
                return new List<string>();

            List<string> rights = new List<string>() { "module_authenticated" };
            if (user.UserModules != null)
                foreach (UserModule m in user.UserModules)
                    if (m.Roles != null)
                        foreach (Role role in m.Roles)
                            if (role.Rights != null && role.Rights.Count > 0)
                                rights.AddRange(role.Rights.Select(r => r.Code));
            
            return rights;
        }

        public async Task<string?> GetUserIdForUserNameAsync(string userName) =>
            (await GetUserProfile(userName))?.UserId;

        public async Task<User?> GetUserProfile(string objectId) =>
            await _userService.GetByUsernameAsync(objectId);

        public async Task<ResponseModel<User?>> UpdateUserProfile(string requesterObjectId, User user)
        {
            ResponseModel<User?> response = new ResponseModel<User?>();
            if (requesterObjectId != user.UserName)
            {
                response.IsSuccess = false;
                response.Message = "You are not authorized to update another persons profile";
            } else {
                User? targetUser = await _userService.GetByUsernameAsync(user.UserName);
                if (targetUser == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Unable to locate user data";
                } else
                {
                    UserAction action = new UserAction()
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        EmailAddress = user.EmailAddress,
                        Active = user.Active,
                        CreatedOn = user.CreatedOn,
                        UserId = user.UserId,
                        UserModules = user.UserModules,
                        UserName = user.UserName,
                        IdentityAction = UserActionsConst.IdentityActions.NoAction

                    };
                    await _userService.UpdateAsync(action);
                    response.IsSuccess = true;
                    response.Response = targetUser;
                }
            }
            return response;
        }
    }
}
