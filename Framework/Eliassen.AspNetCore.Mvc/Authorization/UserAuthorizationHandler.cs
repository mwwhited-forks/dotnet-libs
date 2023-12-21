using Eliassen.System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Logging;
using System.Threading.Tasks;

namespace Eliassen.AspNetCore.JwtAuthentication.Authorization;

public class UserAuthorizationHandler : AuthorizationHandler<UserAuthorizationRequirement>
{
    private readonly ILogger _logger;

    public UserAuthorizationHandler(
        ILogger<UserAuthorizationHandler> logger
        )
    {
        _logger = logger;
    }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserAuthorizationRequirement requirement)
    {
#if DEBUG
        IdentityModelEventSource.ShowPII = true;
#endif
        var user = context.User;

        //these should be provided by the authentication provider
        var userName = user.GetClaimValue(CommonClaims.ObjectId, CommonClaims.ObjectIdentifier)?.value;

        // is the application has extended the user id claim than this should be provided as well
        var userId = user.GetClaimValue(CommonClaims.UserId)?.value;

        var isAuthorized = !string.IsNullOrWhiteSpace(userName);

        if (isAuthorized && requirement.RequireApplicationUserId)
            isAuthorized &= !string.IsNullOrWhiteSpace(userId)
            ;

        if (isAuthorized)
        {
            _logger.LogInformation($"{{{nameof(userName)}}} is authorized ({{{nameof(userId)}}})", userName, userId);
            context.Succeed(requirement);
        }
        else
        {
            _logger.LogWarning($"{{{nameof(userName)}}} is not authorized ({{{nameof(userId)}}})", userName, userId);
            context.Fail(new AuthorizationFailureReason(this, "User not authorized"));
        }

        return Task.CompletedTask;
    }
}
