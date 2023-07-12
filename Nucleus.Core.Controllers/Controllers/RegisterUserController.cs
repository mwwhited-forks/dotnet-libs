using Eliassen.AspNetCore.Mvc.Filters;
using Eliassen.System.Linq.Search;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nucleus.Core.Contracts;
using Nucleus.Core.Contracts.Managers;
using Nucleus.Core.Contracts.Models;
using Nucleus.Core.Persistence.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Nucleus.Core.Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterUserController : ControllerBase
    {
        private readonly IUserManagementManager _usersManager;
        private readonly IQueryBuilder<Module> _queryBuilder;

        public RegisterUserController(
            IUserManagementManager usersManager,
            IQueryBuilder<Module> queryBuilder
            )
        {
            _usersManager = usersManager;
            _queryBuilder = queryBuilder;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ResponseModel<User>> SaveUser(UserAction? user) =>
            await _usersManager.SaveUserAsync(user);

        [AllowAnonymous]
        [HttpGet("ApplicationPermissions")]
        public IQueryable<Module> GetApplicationPermissions() => _usersManager.QueryModules();

        [AllowAnonymous]
        [ApplicationRight(Rights.UserManagement.Manager)]
        [HttpGet("ApplicationPemissions")]
        [Obsolete("Change to the `ApplicationPemissions` /api/UserManagement/ApplicationPermissions")]
        public PagedResult<Module> GetApplicationPermissionsLegacy() =>
           _queryBuilder.ExecuteBy(_usersManager.QueryModules(), new SearchQuery { }).AsLegacy();
    }
}
