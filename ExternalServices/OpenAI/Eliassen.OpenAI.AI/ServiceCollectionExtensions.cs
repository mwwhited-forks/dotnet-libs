using Eliassen.AI;
using Eliassen.OpenAI.AI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Eliassen.OpenAI.AI;

public static class ServiceCollectionExtensions
{
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
        services.TryAddKeyedTransient<ILanguageModelProvider, OpenAIManager>("OpenAIOptions");

        services.Configure<OpenAIOptions>(options => configuration.Bind(openAIOptionSection, options));
        return services;
    }
}
