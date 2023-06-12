using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nucleus.AspNetCore.Mvc.IdentityModel;
using Nucleus.Core.Persistence.Managers;
using Nucleus.Core.Persistence.Models;
using System.Threading.Tasks;

namespace Nucleus.Core.Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserSession _userSession;
        private readonly IUserProfileManager _userProfileManager;

        public UserController(
            IUserSession userSession,
            IUserProfileManager userProfileManager
            )
        {
            _userSession = userSession;
            _userProfileManager = userProfileManager;
        }

        /// <summary>
        /// Get user profile for currently logged in user
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public async Task<User?> GetUserProfile()=>
            await _userProfileManager.GetUserProfile(_userSession.UserName);

        /// <summary>
        /// Save user profile for current logged in user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut]
        public async Task<ResponseModel<User?>> UpdateUserProfile(User user)=>
            await _userProfileManager.UpdateUserProfile(_userSession.UserName, user);
    }
}
