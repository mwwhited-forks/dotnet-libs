using Eliassen.AI;
using Eliassen.LLMProvider;
using LLMProvider.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace LLMProvider;
public static class ServiceCollectionExtenstions
{
    public static IServiceCollection TryAddAIAbstractions(this IServiceCollection services,IConfiguration configuration,
                string openAIConfigurationSection)
    {
        services.TryAddTransient<ILangageModelProvider, OpenAIManager>();
        services.Configure<OpenAIOptions>(options => configuration.Bind(openAIConfigurationSection, options));
        return services;
    }
}
