using Eliassen.MongoDB.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Nucleus.Project.Contracts.Services;
using Nucleus.Project.Persistence.Services;
using Nucleus.Project.Persistence.Sevices;

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
