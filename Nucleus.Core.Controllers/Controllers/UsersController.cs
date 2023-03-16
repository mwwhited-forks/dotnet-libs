using Nucleus.Core.Contracts.Interfaces;
using Nucleus.Core.Contracts.Managers;
using Nucleus.Core.Contracts.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Nucleus.Core.Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserSession _userSession { get; set; }
        private IUserProfileManager _userProfileManager { get; set; }

        public UsersController(IUserSession userSession, IUserProfileManager userProfileManager)
        {
            _userSession = userSession;
            _userProfileManager = userProfileManager;
        }

        [Authorize]
        [HttpGet("UserProfile")]
        public async Task<IActionResult> GetUserProfile()
        {
            return new JsonResult(await _userProfileManager.GetUserProfile(_userSession.Username));
        }

        [Authorize]
        [HttpPost("UserProfile")]
        public async Task<IActionResult> UpdateUserProfile(User user)
        {
            Thread.Sleep(2000);
            return new JsonResult(await _userProfileManager.UpdateUserProfile(_userSession.Username, user));
        }
    }
}
