using Eliassen.Azure.StorageAccount;
using Eliassen.Keycloak;
using Eliassen.MailKit;
using Eliassen.Microsoft.B2C;
using Eliassen.MongoDB;
using Eliassen.RabbitMQ;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Eliassen.Common.Extensions;

/// <summary>
/// Provides extension methods for configuring common external services in the <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Tries to add common external services to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> instance.</param>
    /// <param name="configuration">The configuration containing settings for external services.</param>
    /// <param name="builder">Optional builder for configuring identity extensions. Default is <c>null</c>.</param>
    /// <returns>The updated <see cref="IServiceCollection"/> instance.</returns>
    public static IServiceCollection TryCommonExternalExtensions(
        this IServiceCollection services,
        IConfiguration configuration,
        IdentityExtensionBuilder? builder = default
    )
    {
        builder ??= new();

        services.TryAddMongoServices(configuration);
        services.TryAddAzureStorageServices(configuration);
        services.TryAddRabbitMQServices();
        services.TryAddMailKitExtensions(configuration);

        switch (builder.IdentityProvider)
        {
            default:
            case IdentityProviders.None:
                break;

            case IdentityProviders.AzureB2C:
                services.TryAddMicrosoftB2CServices(configuration);
                break;

            case IdentityProviders.Keycloak:
                services.TryAddKeycloakServices(configuration);
                break;
        }

        return services;
    }
}
