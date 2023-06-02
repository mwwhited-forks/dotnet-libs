using Eliassen.AspNetCore.Mvc.Filters;
using Eliassen.System.Linq.Search;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nucleus.Core.Contracts;
using Nucleus.Core.Contracts.Managers;
using Nucleus.Core.Contracts.Models;
using Nucleus.Core.Contracts.Models.Filters;
using System;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<ResponseModel<User>> SaveUser(UserAction? user) =>
            await _usersManager.SaveUserAsync(user);

        [AllowAnonymous]
        [HttpGet("ApplicationPermissions")]
        public IQueryable<Module> GetApplicationPermissions() => _usersManager.QueryModules();

        [Authorize]
        [ApplicationRight(Rights.UserManagement.Manager)]
        [HttpGet("ApplicationPemissions")]
        [Obsolete("Change to the `ApplicationPemissions` /api/UserManagement/ApplicationPermissions")]
        public PagedResult<Module> GetApplicationPermissionsLegacy() =>
             _usersManager.QueryModules().ExecuteBy(new SearchQuery { }).AsLegacy();
    }
}
