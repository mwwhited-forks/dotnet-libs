using Eliassen.AspNetCore.Mvc.Filters;
using Eliassen.System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nucleus.Core.Contracts;
using Nucleus.Core.Contracts.Managers;
using Nucleus.Core.Contracts.Models;
using Nucleus.Core.Contracts.Models.Filters;

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
        [Obsolete("Change to the `ListUsers` /api/UserManagement/Query")]
        public IPagedResult<User> GetUserProfile(UsersFilter userFilter) =>
             _usersManager.QueryUsers().ExecuteBy(new SearchQuery
             {
                 CurrentPage = userFilter.PagingModel.CurrentPage,
                 PageSize = userFilter.PagingModel.PageSize,
                 ExcludePageCount = userFilter.PagingModel.ExcludePageCount,
                 SearchTerm = userFilter.UserFilters.InputValue,
                 Filter = {
                     {nameof(userFilter.UserFilters.Module), new Eliassen.System.Linq.SearchOption{ EqualTo= userFilter.UserFilters.Module } },
                     {nameof(userFilter.UserFilters.UserStatus), new Eliassen.System.Linq.SearchOption{ EqualTo= userFilter.UserFilters.UserStatus } },
                 },
             });


        //[Authorize]
        //[ApplicationRight(Rights.UserManagement.Manager)]
        [HttpPost("Query")]
        public IQueryable<User> ListUsers() => _usersManager.QueryUsers();

        [Authorize]
        [ApplicationRight(Rights.UserManagement.Manager)]
        [HttpGet("ApplicationPermissions")]
        public IQueryable<Module> GetApplicationPermissions() => _usersManager.QueryModules();


        [Authorize]
        [HttpPost(nameof(SearchUserExample))]
        public SearchResult<User> SearchUserExample(SearchQuery<User> model) => throw new NotSupportedException();

        [Authorize]
        [HttpPost(nameof(SearchModuleExample))]
        public SearchResult<Module> SearchModuleExample(SearchQuery<Module> model) => throw new NotSupportedException();

    }
}
