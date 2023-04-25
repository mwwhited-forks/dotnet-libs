using Nucleus.Core.Busines.Attributes;
using Nucleus.Core.Contracts;
using Nucleus.Core.Contracts.Interfaces;
using Nucleus.Core.Contracts.Managers;
using Nucleus.Core.Contracts.Models;
using Nucleus.Core.Contracts.Models.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Nucleus.Core.Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        private IUserSession _userSession { get; set; }
        private IUserManagementManager _usersManager { get; set; }

        public UserManagementController(IUserSession userSession, IUserManagementManager usersManager)
        {
            _userSession = userSession;
            _usersManager = usersManager;
        }

        [Authorize]
        [ApplicationRight(Rights.UserManagement.Manager)]
        [HttpPost]
        public async Task<IActionResult> SaveUser(UserAction? user) =>
            new JsonResult(await _usersManager.SaveUserAsync(user));

        [Authorize]
        [ApplicationRight(Rights.UserManagement.Manager)]
        [HttpPost("UserList")]
        public async Task<IActionResult> GetUserProfile(UsersFilter userFilter) =>
            new JsonResult(await _usersManager.GetUsers(userFilter));

        [Authorize]
        [ApplicationRight(Rights.UserManagement.Manager)]
        [HttpGet("ApplicationPemissions")]
        public async Task<IActionResult> GetApplicationPermissions() =>
            new JsonResult(await _usersManager.GetApplicationPermissionsAsync());

    }
}
