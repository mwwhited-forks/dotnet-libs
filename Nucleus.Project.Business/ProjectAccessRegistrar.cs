using Nucleus.Core.Contracts.Interfaces;
using Nucleus.Project.Business.Managers;
using Nucleus.Project.Contracts.Managers;
using Microsoft.Extensions.DependencyInjection;

namespace Nucleus.Project.Business
{
    public class ProjectAccessRegistrar : IRegistrar
    {
        public IServiceCollection AddServices(IServiceCollection services)
        {
            services.AddTransient<IProjectManager, ProjectManager>();
            services.AddTransient<IPublicProjectManager, PublicProjectManager>();
            return services;
        }
    }
}
