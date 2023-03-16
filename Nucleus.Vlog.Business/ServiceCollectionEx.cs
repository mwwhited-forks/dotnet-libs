using Microsoft.Extensions.DependencyInjection;

namespace Nucleus.Vlog.Business
{
    public static class ServiceCollectionEx
    {
        public static IServiceCollection AddVlogBusinessServices(this IServiceCollection services)
        {
            new VlogAccessRegistrar().AddServices(services);
            return services;
        }
    }
}
