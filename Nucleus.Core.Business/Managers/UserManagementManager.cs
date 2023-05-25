using Nucleus.Core.Contracts.Interfaces;
using Nucleus.Core.Contracts.Managers;
using Nucleus.Core.Contracts.Models;
using Nucleus.Core.Contracts.Models.Filters;
using Nucleus.Core.Contracts.Models.Keys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nucleus.Core.Business.Managers
{
    public class UserManagementManager : IUserManagementManager
    {
        private IIdentityManager _identityManager { get; set; }
        private IUserService _userService { get; set; }

        public UserManagementManager(
            IIdentityManager identityManager,
            IUserService userService)
        {
            _identityManager = identityManager;
            _userService = userService;
        }

        public async Task<PagedResult<User>> GetUsers(UsersFilter userFilter)
        {
            PagedResult<User> result = new PagedResult<User>();
            // Get all users
            List<User> users = await _userService.GetPagedAsync(userFilter.PagingModel, userFilter.UserFilters);
            result = new PagedResult<User>()
            {
                 CurrentPage = userFilter.PagingModel.CurrentPage,
                 PageSize = userFilter.PagingModel.PageSize,
                 Results = users,
                 RowCount = await _userService.GetPagedCountAsync(userFilter.PagingModel, userFilter.UserFilters),
                 PageCount = users.Count()
            };
            
            return result;
        }

        public async Task<List<Module>> GetApplicationPermissionsAsync() =>
             await _userService.GetModulesAsync();

        public async Task<ResponseModel<User>> SaveUserAsync(UserAction user)
        {
            
            if (user == null || string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName) || string.IsNullOrEmpty(user.EmailAddress))
                return new ResponseModel<User>()
                {
                    IsSuccess = false,
                    Message = "Missing Required Fields"
                };

            if (user.IdentityAction == UserActionsConst.IdentityActions.RetainIdentity && user.UserName == null)
            {
                // Need to add/assign an account to this user
                string newId = await _identityManager.CreateIdentityUserAsync(user.EmailAddress, user.FirstName, user.LastName);
                user.UserName = newId;
            }

            if ((user.IdentityAction == UserActionsConst.IdentityActions.RemoveIdentity 
                || user.IdentityAction == UserActionsConst.IdentityActions.RemoveAccount)
                && user.UserName != null)
            {
                bool removed = await _identityManager.RemoveIdentityUserAsync(user.UserName);
                if (removed == true)
                    user.UserName = null;
            }

            ResponseModel<User?> result = new ResponseModel<User?>();
            if (user.IdentityAction == UserActionsConst.IdentityActions.RemoveAccount)
            {
                await _userService.RemoveAsync(user.UserId);
            } 
            else if (String.IsNullOrEmpty(user.UserId))
            {
                var userExists = await _userService.GetByEmailAddressAsync(user.EmailAddress);
                if (userExists != null)
                {
                    return new ResponseModel<User>()
                    {
                        IsSuccess = false,
                        Message = "Duplicate Email Address"
                    };
                }
                else
                {
                    user.CreatedOn = DateTimeOffset.Now;
                    await _userService.CreateAsync(user);
                    result.Response = await _userService.GetByEmailAddressAsync(user.EmailAddress);
                }
            }
            else
            {
                await _userService.UpdateAsync(user);
                result.Response = await _userService.GetAsync(user.UserId);
            }

            return new ResponseModel<User>()
            {
                IsSuccess = true,
                Response = user
            };
        }
    }
}
