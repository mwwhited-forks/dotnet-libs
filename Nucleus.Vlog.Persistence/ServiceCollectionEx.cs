using Nucleus.Vlog.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Nucleus.Vlog.Persistence
{
    public static class ServiceCollectionEx
    {
        public static IServiceCollection AddVlogPersistenceServices(this IServiceCollection services)
        {
            new VlogPersistenceRegistrar().AddServices(services);
            return services;
        }
    }
}
