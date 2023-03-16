using Nucleus.Project.Business;
using Microsoft.Extensions.DependencyInjection;

namespace Nucleus.Project.Business
{
    public static class ServiceCollectionEx
    {
        public static IServiceCollection AddProjectBusinessServices(this IServiceCollection services)
        {
            new ProjectAccessRegistrar().AddServices(services);
            return services;
        }
    }
}
