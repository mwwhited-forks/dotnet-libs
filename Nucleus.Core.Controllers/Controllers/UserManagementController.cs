using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using Nucleus.AspNetCore.Mvc.Attributes;
using Nucleus.AspNetCore.Mvc.IdentityModel;
using Nucleus.Core.Contracts;
using Nucleus.Core.Contracts.Managers;
using Nucleus.Core.Contracts.Models;

namespace Nucleus.Core.Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        private readonly IUserManagementManager _usersManager;

        public UserManagementController(IUserManagementManager usersManager)
        {
            _usersManager = usersManager;
        }

        [Authorize]
        [ApplicationRight(Rights.UserManagement.Manager)]
        [HttpPost]
        public async Task<ResponseModel<Contracts.Models.User>> SaveUser(UserAction? user) =>
            await _usersManager.SaveUserAsync(user);

        //TODO: restore
#warning RESTORE THIS FEATURE
        //[Authorize]
        //[ApplicationRight(Rights.UserManagement.Manager)]
        //[HttpPost("UserList")]
        //public async Task<IActionResult> GetUserProfile(UsersFilter userFilter) =>
        //    new JsonResult(await _usersManager.GetUsers(userFilter));

        [Authorize]
        [ApplicationRight(Rights.UserManagement.Manager)]
        [HttpGet("ApplicationPemissions")]
        public async Task<List<Module>> GetApplicationPermissions() =>
            await _usersManager.GetApplicationPermissionsAsync();

    }
}
