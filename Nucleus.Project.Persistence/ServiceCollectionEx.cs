using Eliassen.MongoDB.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Nucleus.Project.Contracts.Persistence;
using Nucleus.Project.Persistence.Services;

namespace Nucleus.Project.Persistence
{
    public static class ServiceCollectionEx
    {
        public static IServiceCollection AddProjectPersistenceServices(this IServiceCollection services)
        {
            services.TryAddMongoDatabase<IProjectMongoDatabase>();

            services.TryAddTransient<IProjectService, ProjectService>();
            return services;
        }
    }
}
