using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Nucleus.Project.Business.Managers;
using Nucleus.Project.Contracts.Managers;

namespace Nucleus.Project.Business
{
    public static class ServiceCollectionEx
    {
        public static IServiceCollection AddProjectBusinessServices(this IServiceCollection services)
        {
            services.TryAddTransient<IProjectManager, ProjectManager>();
            services.TryAddTransient<IPublicProjectManager, PublicProjectManager>();
            return services;
        }
    }
}
