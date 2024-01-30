using Eliassen.AspNetCore.JwtAuthentication;
using Eliassen.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Eliassen.Common.AspNetCore;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection TryCommonAspNetCoreExtensions(
        this IServiceCollection services,
        IConfiguration configuration,

        AspNetCoreExtensionBuilder? aspNetBuilder = default,
        JwtExtensionBuilder? jwtBuilder = default
    )
    {
        services.TryAddAspNetCoreExtensions(aspNetBuilder);
        services.TryAddJwtBearerServices(configuration, jwtBuilder);
        return services;
    }
}
