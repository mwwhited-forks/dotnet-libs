using Eliassen.AI;
using Eliassen.OpenAI.AI.Services;
using LLMProvider.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace LLMProvider;
public static class ServiceCollectionExtenstions
{
    public static IServiceCollection TryAddAIAbstractions(this IServiceCollection services,IConfiguration configuration,
#if DEBUG
        string openAIConfigurationSection
#endif
        )
    {
        services.TryAddTransient<ILangageModelProvider, OpenAIManager>();
        services.Configure<OpenAIOptions>(options => configuration.Bind(openAIConfigurationSection, options));
        return services;
    }
}
