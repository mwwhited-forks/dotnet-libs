using Nucleus.Project.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Nucleus.Core.Shared.Persistence
{
    public static class ServiceCollectionEx
    {
        public static IServiceCollection AddProjectPersistenceServices(this IServiceCollection services)
        {
            new ProjectPersistenceRegistrar().AddServices(services);
            return services;
        }
    }
}
