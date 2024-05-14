using Eliassen.CosmosDb.Services;
using Eliassen.MongoDB.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Eliassen.CosmosDb;

/// <summary>
/// Provides extension methods for configuring OpenAI services.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Tries to add OpenAI-related services to the specified service collection.
    /// </summary>
    /// <param name="services">The service collection to which OpenAI services should be added.</param>
    /// <param name="configuration">The configuration used to bind options.</param>
    /// <param name="cosmosDatabaseConfigurationSection">The name of the configuration section containing OpenAI options. Defaults to "OpenAIClientOptions".</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection TryAddCosmosDbServices(
        this IServiceCollection services,
        IConfiguration configuration,
#if DEBUG
        string cosmosDatabaseConfigurationSection
#else
        string openAIOptionSection = nameof(OpenAIClientOptions)
#endif
        )
    {
        services.Configure<CosmosDbClientOptions>(options => configuration.Bind(cosmosDatabaseConfigurationSection, options));
        services.TryAddSingleton<IMongoDatabaseFactory, MongoDatabaseFactory>();
        return services;
    }
}
