using Eliassen.Azure.StorageAccount;
using Eliassen.Keycloak;
using Eliassen.MailKit;
using Eliassen.Microsoft.B2C;
using Eliassen.MongoDB;
using Eliassen.RabbitMQ;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Eliassen.Common.Extensions;

public static class ServiceCollectionExtensions
{
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
