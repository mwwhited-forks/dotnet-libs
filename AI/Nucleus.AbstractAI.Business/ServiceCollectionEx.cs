using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Nucleus.AbstractAI.Business.Managers;
using Nucleus.AbstractAI.Contracts.Managers;


namespace Nucleus.AbstractAI.Business;

public static class ServiceCollectionEx
{
    public static IServiceCollection AddCoreBusinessServices(this IServiceCollection services)
    {
        services.TryAddTransient<IOpenAIManager, OpenAIManager>();
        return services;
    }
}
