using Microsoft.Extensions.DependencyInjection;

namespace Nucleus.Core.Shared.Business
{
    public static class ServiceCollectionEx
    {
        public static IServiceCollection AddSharedBusinessServices(this IServiceCollection services)
        {
            new SharedAccessRegistrar().AddServices(services);
            return services;
        }
    }
}
