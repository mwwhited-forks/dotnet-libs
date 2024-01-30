using Eliassen.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authorization;
using System;

namespace Eliassen.AspNetCore.Mvc;

public record AspNetCoreExtensionBuilder
{

    public bool RequireAuthenticatedByDefault { get; init; } = UserAuthorizationRequirement.RequireAuthenticatedByDefault;
    public bool RequireApplicationUserId { get; init; } = UserAuthorizationRequirement.RequireApplicationUserIdDefault;
    public Action<AuthorizationPolicyBuilder>? AuthorizationPolicyBuilder { get; init; } = default;
}
