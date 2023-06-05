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
    public class UserManagementController : ControllerBase
    {
        private readonly IUserManagementManager _usersManager;

#warning retire this
        //NOTE: DO NOT IMPORT THESE... Use the IQueryable pattern
        private readonly IQueryBuilder<User> _userQuery;
        private readonly IQueryBuilder<Module> _moduleQuery;

        public UserManagementController(
            IUserManagementManager usersManager,
            IQueryBuilder<User> userQuery,
            IQueryBuilder<Module> moduleQuery
            )
        {
            _usersManager = usersManager;
            _userQuery = userQuery;
            _moduleQuery = moduleQuery;
        }

        [Authorize]
        [ApplicationRight(Rights.UserManagement.Manager)]
        [HttpPost]
        public async Task<ResponseModel<User>> SaveUser(UserAction user) =>
            await _usersManager.SaveUserAsync(user);

        /// <summary>
        /// Query all user accounts
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [ApplicationRight(Rights.UserManagement.Manager)]
        [HttpPost("Query")]
        public IQueryable<User> ListUsers() => _usersManager.QueryUsers();

        /// <summary>
        /// Query all modules
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [ApplicationRight(Rights.UserManagement.Manager)]
        [HttpGet("ApplicationPermissions")]
        public IQueryable<Module> GetApplicationPermissions() => _usersManager.QueryModules();

        //[Authorize]
        //[HttpPost(nameof(SearchUserExample) + "Json")]
        //public PagedQueryResult<User> SearchUserExample(SearchQuery<User> model) => throw new NotSupportedException();

        //[Authorize]
        //[HttpPost(nameof(SearchUserExample) + "Form")]
        //public PagedQueryResult<User> SearchUserExampleForm([FromForm] SearchQuery<User> model) => throw new NotSupportedException();

        //[HttpGet(nameof(SearchUserExample) + "Get")]
        //public PagedQueryResult<User> SearchUserExampleGet([FromQuery] SearchQuery<User> model) => throw new NotSupportedException();


        [Authorize]
        [ApplicationRight(Rights.UserManagement.Manager)]
        [HttpPost("UserList")]
        [Obsolete("Change to the `ListUsers` /api/UserManagement/Query")]
        public PagedResult<User> GetUserProfile(UsersFilter userFilter) =>
          _userQuery.ExecuteBy(_usersManager.QueryUsers(), new SearchQuery
          {
              CurrentPage = userFilter.PagingModel.CurrentPage - 1,
              PageSize = userFilter.PagingModel.PageSize,
              ExcludePageCount = userFilter.PagingModel.ExcludePageCount,
              SearchTerm = userFilter.UserFilters.InputValue,
              Filter = {
                     {nameof(userFilter.UserFilters.Module), new FilterParameter{ EqualTo= userFilter.UserFilters.Module } },
                     {nameof(userFilter.UserFilters.UserStatus), new FilterParameter{ EqualTo= userFilter.UserFilters.UserStatus } },
                 },
          }).AsLegacy(userFilter.PagingModel);

        [Authorize]
        [ApplicationRight(Rights.UserManagement.Manager)]
        [HttpGet("ApplicationPemissions")]
        [Obsolete("Change to the `ApplicationPemissions` /api/UserManagement/ApplicationPermissions")]
        public PagedResult<Module> GetApplicationPermissionsLegacy() =>
             _moduleQuery.ExecuteBy(_usersManager.QueryModules(), new SearchQuery { }).AsLegacy();

    }
}
