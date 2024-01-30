using Eliassen.AspNetCore.JwtAuthentication;
using Eliassen.AspNetCore.Mvc;
using Eliassen.System;
using Eliassen.Common.Extensions;
using Eliassen.Common.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Eliassen.Common.AspNetCore;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection TryAllCommonExtensions(
        this IServiceCollection services,
        IConfiguration configuration,

        SystemExtensionBuilder? systemBuilder = default,
        AspNetCoreExtensionBuilder? aspNetBuilder = default,
        JwtExtensionBuilder? jwtBuilder = default,
        IdentityExtensionBuilder? identityBuilder = default,
        HostingExtensionsBuilder? hostingBuilder = default
    )
    {
        services.TryCommonExtensions(configuration, systemBuilder);
        services.TryCommonAspNetCoreExtensions(configuration, aspNetBuilder, jwtBuilder);
        services.TryCommonExternalExtensions(configuration, identityBuilder);
        services.TryCommonHostingExtensions(configuration, hostingBuilder);

        return services;
    }
}
