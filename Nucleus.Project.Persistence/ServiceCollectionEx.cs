using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Nucleus.Project.Contracts.Services;
using Nucleus.Project.Persistence.Services;

namespace Nucleus.Core.Shared.Persistence
{
    public static class ServiceCollectionEx
    {
        public static IServiceCollection AddProjectPersistenceServices(this IServiceCollection services)
        {
            services.TryAddTransient<IProjectService, ProjectService>();
            return services;
        }
    }
}
