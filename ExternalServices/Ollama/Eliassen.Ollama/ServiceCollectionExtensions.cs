using Eliassen.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Eliassen.Ollama;

/// <summary>
/// Provides extension methods for configuring services related to Ollama.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Configures services for Ollama.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <returns>The modified <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection TryAddOllamaServices(this IServiceCollection services)
    {
        services.TryAddTransient<IOllamaApiClientFactory, OllamaApiClientFactory>();
        services.TryAddTransient(sp => ActivatorUtilities.CreateInstance<MessageCompletion>(sp));
        services.TryAddTransient(sp => sp.GetRequiredService<IOllamaApiClientFactory>().Build(""));
        services.TryAddTransient<IMessageCompletion, MessageCompletion>();

        return services;
    }
}
