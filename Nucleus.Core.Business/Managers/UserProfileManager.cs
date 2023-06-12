using Nucleus.Core.Persistence.Interfaces;
using Nucleus.Core.Persistence.Managers;
using Nucleus.Core.Persistence.Models;
using Nucleus.Core.Persistence.Models.Keys;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nucleus.Core.Business.Managers
{
    public class UserProfileManager : IUserProfileManager
    {
        private readonly IUserService _userService;

        public UserProfileManager(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IEnumerable<string>> GetRightsForUserIdAsync(string userId)
        {
            var user = await _userService.GetByUserIdAsync(userId);

            if (user == null) return new List<string>();

            var query = from module in user.UserModules ?? Enumerable.Empty<UserModule>()
                        from role in module.Roles ?? Enumerable.Empty<Role>()
                        from right in role.Rights ?? Enumerable.Empty<PermissionBase>()
                        select right.Code;

            var rights = new[] { "module_authenticated" }.Concat(query).Distinct().ToList();
            return rights;
        }

        public async Task<string?> GetUserIdForUserNameAsync(string userName) =>
            (await GetUserProfile(userName))?.UserId;

        public async Task<User?> GetUserProfile(string objectId) =>
            await _userService.GetByUserNameAsync(objectId);

        public async Task<ResponseModel<User?>> UpdateUserProfile(string requesterObjectId, User user)
        {
            ResponseModel<User?> response = new ResponseModel<User?>();
            if (requesterObjectId != user.UserName)
            {
                response.IsSuccess = false;
                response.Message = "You are not authorized to update another persons profile";
            }
            else
            {
                User? targetUser = await _userService.GetByUserNameAsync(user.UserName);
                if (targetUser == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Unable to locate user data";
                }
                else
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
