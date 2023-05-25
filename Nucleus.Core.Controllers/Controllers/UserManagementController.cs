using Eliassen.System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nucleus.AspNetCore.Mvc.Attributes;
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
        public async Task<ResponseModel<User>> SaveUser(UserAction user) =>
            await _usersManager.SaveUserAsync(user);

        [Authorize]
        [ApplicationRight(Rights.UserManagement.Manager)]
        [HttpPost("UserList")]
        [HttpGet("UserList")]
        public IQueryable<User> ListUsers() =>
            _usersManager.Query();

        [Authorize]
        [HttpPost("Search")]
        [HttpGet("Search")]
        public SearchResult<User> EXP(SearchQuery<User> model) => throw new NotSupportedException();

        [Authorize]
        [HttpPost("EXP")]
        [HttpGet("EXP")]
        public async Task<List<Module>> EXP( User model) => throw new NotSupportedException();

        [Authorize]
        [ApplicationRight(Rights.UserManagement.Manager)]
        [HttpGet("ApplicationPermissions")]
        public async Task<List<Module>> GetApplicationPermissions() =>
            await _usersManager.GetApplicationPermissionsAsync();

    }
}
