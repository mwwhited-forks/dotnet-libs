using Microsoft.Extensions.DependencyInjection;

namespace Nucleus.Core.Persistence
{
    public static class ServiceCollectionEx
    {
        public static IServiceCollection AddCorePersistenceServices(this IServiceCollection services)
        {
            new CorePersistenceRegistrar().AddServices(services);
            return services;
        }
    }
}
