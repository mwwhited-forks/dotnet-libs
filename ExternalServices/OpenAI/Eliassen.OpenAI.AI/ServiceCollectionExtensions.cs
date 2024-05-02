using Eliassen.AI;
using Eliassen.OpenAI.AI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Eliassen.OpenAI.AI;

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
    /// <param name="openAIOptionSection">The name of the configuration section containing OpenAI options. Defaults to "OpenAIOptions".</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection TryAddOpenAIServices(
        this IServiceCollection services,
        IConfiguration configuration,
#if DEBUG
        string openAIOptionSection
#else
        string openAIOptionSection = nameof(OpenAIOptions)
#endif
        )
    {
        services.TryAddTransient<ILanguageModelProvider, OpenAIManager>();
        services.TryAddKeyedTransient<ILanguageModelProvider, OpenAIManager>("OPENAPI");

        services.Configure<OpenAIOptions>(options => configuration.Bind(openAIOptionSection, options));
        return services;
    }
}
