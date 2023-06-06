using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Eliassen.System.Accessors
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAccessor<TService>(this IServiceCollection services)
            where TService : class
        {
            services.TryAddSingleton(typeof(IAccessor<>), typeof(Accessor<>));
            services.TryAddTransient(sp => sp.GetRequiredService<IAccessor<TService>>().Value);

            return services;
        }
    }
}
