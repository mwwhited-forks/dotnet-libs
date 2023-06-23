using Eliassen.System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Logging;
using System.Threading.Tasks;

namespace Nucleus.AspNetCore.Mvc.Authorization
{
    public class NucleusUserAuthorizationHandler : AuthorizationHandler<NucleusUserAuthorizationRequirement>
    {
        private readonly ILogger _logger;

        public NucleusUserAuthorizationHandler(
            ILogger<NucleusUserAuthorizationHandler> logger
            )
        {
            _logger = logger;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, NucleusUserAuthorizationRequirement requirement)
        {
#if DEBUG
            IdentityModelEventSource.ShowPII = true;
#endif
            var user = context.User;

            var userId = user.GetClaimValue(CommonClaims.UserId)?.value;
            var userName = user.GetClaimValue(CommonClaims.ObjectId, CommonClaims.ObjectIdentifier)?.value;

            var isAuthorized =
                !string.IsNullOrWhiteSpace(userId) &&
                !string.IsNullOrWhiteSpace(userName)
                //TODO: consider active check here
                ;

            if (isAuthorized)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail(new AuthorizationFailureReason(this, $"User not found"));
            }

            return Task.CompletedTask;
        }
    }
}
