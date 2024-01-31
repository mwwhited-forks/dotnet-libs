using Eliassen.AspNetCore.JwtAuthentication;
using Eliassen.AspNetCore.Mvc;
using Eliassen.Common.AspNetCore;
using Eliassen.Common.Extensions;
using Eliassen.Common.Hosting;
using Eliassen.System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Eliassen.Common;

/// <summary>
/// Provides extension methods for configuring all common extensions in the <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Tries to add all common extensions to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> instance.</param>
    /// <param name="configuration">The configuration containing settings for common extensions.</param>
    /// <param name="systemBuilder">Optional builder for configuring system extensions. Default is <c>null</c>.</param>
    /// <param name="aspNetBuilder">Optional builder for configuring ASP.NET Core extensions. Default is <c>null</c>.</param>
    /// <param name="jwtBuilder">Optional builder for configuring JWT extensions. Default is <c>null</c>.</param>
    /// <param name="identityBuilder">Optional builder for configuring identity extensions. Default is <c>null</c>.</param>
    /// <param name="externalBuilder">Optional builder for configuring external extensions. Default is <c>null</c>.</param>
    /// <param name="hostingBuilder">Optional builder for configuring hosting. Default is <c>null</c>.</param>
    /// <returns>The updated <see cref="IServiceCollection"/> instance.</returns>
    public static IServiceCollection TryAllCommonExtensions(
        this IServiceCollection services,
        IConfiguration configuration,
        SystemExtensionBuilder? systemBuilder = default,
        AspNetCoreExtensionBuilder? aspNetBuilder = default,
        JwtExtensionBuilder? jwtBuilder = default,
        IdentityExtensionBuilder? identityBuilder = default,
        ExternalExtensionBuilder? externalBuilder = default,
        HostingBuilder? hostingBuilder = default
    )
    {
        // Add all common extensions
        services.TryCommonExtensions(configuration, systemBuilder);
        services.TryCommonAspNetCoreExtensions(configuration, aspNetBuilder, jwtBuilder);
        services.TryCommonExternalExtensions(configuration, identityBuilder, externalBuilder);
        services.TryCommonHosting(configuration, hostingBuilder);

        return services;
    }
}
