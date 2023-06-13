using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Linq;

namespace Eliassen.System.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection GetSingletonInstance<TService, TInstance>(this IServiceCollection services, out TInstance instance)
            where TService : class
            where TInstance : class, TService, new()
        {
            instance = (services.FirstOrDefault(i => i.ServiceType == typeof(TService))?.ImplementationInstance as TInstance) ?? new TInstance();
            services.Replace(ServiceDescriptor.Singleton<TService>(instance));
            return services;
        }
    }
}
