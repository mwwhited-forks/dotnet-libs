using Eliassen.Identity.Identity;
using Eliassen.Keycloak.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Eliassen.Keycloak;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection TryAddKeycloakServices(this IServiceCollection services)
    {
        services.TryAddTransient<IIdentityManager, ManageKeycloakUser>();
        services.TryAddTransient<IManageGraphUser, ManageKeycloakUser>();
        return services;
    }
}
