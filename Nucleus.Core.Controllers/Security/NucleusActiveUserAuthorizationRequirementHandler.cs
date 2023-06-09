//using Microsoft.AspNetCore.Authorization;
//using Microsoft.Extensions.Logging;
//using Microsoft.IdentityModel.Logging;
//using Nucleus.AspNetCore.Mvc.IdentityModel;
//using Nucleus.Core.Contracts.Managers;
//using System.Threading.Tasks;

//namespace Nucleus.AspNetCore.Mvc.Authorization
//{
//    public class NucleusActiveUserAuthorizationRequirementHandler : AuthorizationHandler<NucleusActiveUserAuthorizationRequirement>
//    {
//        private readonly ILogger _logger;
//        private readonly IUserSession _user;
//        private readonly IUserProfileManager _manager;

//        public NucleusActiveUserAuthorizationRequirementHandler(
//            ILogger<NucleusActiveUserAuthorizationRequirementHandler> logger,
//            IUserSession user,
//            IUserProfileManager manager
//            )
//        {
//            _logger = logger;
//            _user = user;
//            _manager = manager;
//        }

//        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, NucleusActiveUserAuthorizationRequirement requirement)
//        {
//#if DEBUG
//            IdentityModelEventSource.ShowPII = true;
//#endif
//            bool isActive = await _manager.IsActveAsync(_user.UserId); //TODO: make an async and less expensive active check
//            if (isActive)
//            {
//                _logger.LogDebug("User {user} is active", _user.UserId);
//                context.Succeed(requirement);
//            }
//            else
//            {
//                _logger.LogDebug("User {user} is NOT active", _user.UserId);
//                context.Fail();
//            }
//        }
//    }
//}
