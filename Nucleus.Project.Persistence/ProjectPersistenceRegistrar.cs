using Nucleus.Core.Contracts.Interfaces;
using Nucleus.Project.Contracts.Services;
using Nucleus.Project.Persistence.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Nucleus.Project.Persistence
{
    public class ProjectPersistenceRegistrar : IRegistrar
    {
        public IServiceCollection AddServices(IServiceCollection services)
        {
            services.AddTransient<IProjectService, ProjectService>();
            return services;
        }
    }
}
