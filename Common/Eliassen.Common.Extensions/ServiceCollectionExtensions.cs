using Eliassen.Apache.Tika;
using Eliassen.Azure.StorageAccount;
using Eliassen.Keycloak;
using Eliassen.MailKit;
using Eliassen.Markdig;
using Eliassen.Microsoft.ApplicationInsights;
using Eliassen.Microsoft.B2C;
using Eliassen.Microsoft.OpenXml;
using Eliassen.MongoDB;
using Eliassen.MysticMind;
using Eliassen.Ollama;
using Eliassen.OpenAI.AI;
using Eliassen.OpenSearch;
using Eliassen.Qdrant;
using Eliassen.RabbitMQ;
using Eliassen.SBert;
using Eliassen.WkHtmlToPdf;
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
    /// <param name="identityBuilder">Optional builder for configuring identity extensions. Default is <c>null</c>.</param>
    /// <param name="externalBuilder">Optional builder for configuring external extensions. Default is <c>null</c>.</param>
    /// <returns>The updated <see cref="IServiceCollection"/> instance.</returns>
    public static IServiceCollection TryCommonExternalExtensions(
        this IServiceCollection services,
        IConfiguration configuration,
#if DEBUG
        IdentityExtensionBuilder? identityBuilder,
        ExternalExtensionBuilder? externalBuilder
#else
        IdentityExtensionBuilder? identityBuilder = default,
        ExternalExtensionBuilder? externalBuilder = default
#endif
    )
    {
        identityBuilder ??= new();
        externalBuilder ??= new();

        services.TryAddMongoServices(configuration, externalBuilder.MongoDatabaseConfigurationSection);
        services.TryAddAzureStorageServices(configuration, externalBuilder.AzureBlobProviderOptionSection);
        services.TryAddRabbitMQServices();
        services.TryAddMailKitExtensions(configuration, externalBuilder.SmtpConfigurationSection, externalBuilder.ImapConfigurationSection);
#if DEBUG
#warning Feature is not complete and should not be used in production.
        services.TryAddApplicationInsightsExtensions();
#endif

        if (identityBuilder.IdentityProvider.HasFlag(IdentityProviders.AzureB2C))
            services.TryAddMicrosoftB2CServices(configuration, identityBuilder.MicrosoftIdentityConfigurationSection);

        if (identityBuilder.IdentityProvider.HasFlag(IdentityProviders.Keycloak))
            services.TryAddKeycloakServices(configuration, identityBuilder.KeycloakIdentityConfigurationSection);

        services.TryAddOpenAIServices(configuration, externalBuilder.OpenAIOptionSection);

        services.TryAddSbertServices(configuration, externalBuilder.SentenceEmbeddingOptionSection);
        services.TryAddQdrantServices(configuration, externalBuilder.QdrantOptionSection);
        services.TryAddOpenSearchServices(configuration, externalBuilder.OpenSearchOptionSection);
        services.TryAddOllamaServices(configuration, externalBuilder.OllamaApiClientOptionSection);

        services.TryAddApacheTikaServices();
        services.TryAddWkHtmlToPdfServices();
        services.TryAddMarkdigServices();
        services.TryAddMysticMindServices();
        services.TryAddMicrosoftOpenXmlServices();

        return services;
    }
}
