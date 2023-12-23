using Microsoft.AspNetCore.Authorization;

namespace Eliassen.AspNetCore.JwtAuthentication.Authorization;

/// <summary>
/// Represents an authorization requirement for user-specific authorization.
/// </summary>
public record UserAuthorizationRequirement : IAuthorizationRequirement
{
    /// <summary>
    /// The default value indicating whether the application user ID is required for authorization.
    /// </summary>
    public const bool RequireApplicationUserIdDefault = true;

    /// <summary>
    /// The default value indicating whether authentication is required for authorization.
    /// </summary>
    public const bool RequireAuthenticatedByDefault = true;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserAuthorizationRequirement"/> class.
    /// </summary>
    /// <param name="requireApplicationUserId">Specifies whether the application user ID is required for authorization.</param>
    public UserAuthorizationRequirement(bool requireApplicationUserId = RequireApplicationUserIdDefault)
    {
        RequireApplicationUserId = requireApplicationUserId;
    }

    /// <summary>
    /// Gets a value indicating whether the application user ID is required for authorization.
    /// </summary>
    public bool RequireApplicationUserId { get; init; }
}