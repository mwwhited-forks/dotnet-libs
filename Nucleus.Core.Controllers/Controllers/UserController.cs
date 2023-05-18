using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nucleus.Core.Contracts.Interfaces;
using Nucleus.Core.Contracts.Managers;
using Nucleus.Core.Contracts.Models;

namespace Nucleus.Core.Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserSession _userSession { get; set; }
        private IUserProfileManager _userProfileManager { get; set; }

        public UserController(IUserSession userSession, IUserProfileManager userProfileManager)
        {
            _userSession = userSession;
            _userProfileManager = userProfileManager;
        }

        [Authorize]
        [HttpGet]
        public async Task<User?> GetUserProfile()=>
            await _userProfileManager.GetUserProfile(_userSession.Username);

        [Authorize]
        [HttpPut]
        public async Task<ResponseModel<User?>> UpdateUserProfile(User user)=>
            await _userProfileManager.UpdateUserProfile(_userSession.Username, user);
    }
}
