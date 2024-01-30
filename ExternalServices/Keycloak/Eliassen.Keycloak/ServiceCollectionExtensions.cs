using Eliassen.Identity;
using Eliassen.Keycloak.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Eliassen.Keycloak;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection TryAddKeycloakServices(
        this IServiceCollection services,
        IConfiguration configuration,
        string keycloakIdentityConfigurationSection = nameof(KeycloakIdentityOptions)
        )
    {
        services.TryAddTransient<IIdentityManager, ManageKeycloakUser>();
        services.TryAddTransient<IManageGraphUser, ManageKeycloakUser>();

        services.Configure<KeycloakIdentityOptions>(options => configuration.Bind(keycloakIdentityConfigurationSection, options));

        return services;
    }
}
