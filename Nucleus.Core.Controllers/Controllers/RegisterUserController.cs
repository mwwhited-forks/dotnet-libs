using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nucleus.Core.Contracts.Managers;
using Nucleus.Core.Contracts.Models;

namespace Nucleus.Core.Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterUserController : ControllerBase
    {
        private IUserManagementManager _usersManager { get; set; }

        public RegisterUserController(IUserManagementManager usersManager)
        {
            _usersManager = usersManager;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SaveUser(UserAction? user) =>
            new JsonResult(await _usersManager.SaveUserAsync(user));

        [AllowAnonymous]
        [HttpGet("ApplicationPemissions")]
        public async Task<IActionResult> GetApplicationPermissions() =>
           new JsonResult(await _usersManager.GetApplicationPermissionsAsync());
    }
}
