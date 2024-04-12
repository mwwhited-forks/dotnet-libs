using Eliassen.AI.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Eliassen.LLMProvider;
public static class ServiceCollectionEx
{
    public static IServiceCollection AddCoreBusinessServices(this IServiceCollection services)
    {
        services.TryAddTransient<IOpenAIManager, OpenAIManager>();
        return services;
    }
}
