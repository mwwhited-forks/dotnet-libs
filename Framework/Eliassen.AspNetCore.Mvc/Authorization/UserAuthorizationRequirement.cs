using Microsoft.AspNetCore.Authorization;

namespace Eliassen.AspNetCore.JwtAuthentication.Authorization;

public record UserAuthorizationRequirement : IAuthorizationRequirement
{
    public const bool RequireApplicationUserIdDefault = true;
    public const bool RequireAuthenticatedByDefault = true;

    public UserAuthorizationRequirement(
        bool requireApplicationUserId = RequireApplicationUserIdDefault
        )
    {
        RequireApplicationUserId = requireApplicationUserId;
    }

    public bool RequireApplicationUserId { get; init; }
}
