using Eliassen.Extensions.Accessors;
using Eliassen.System.Accessors;
using Eliassen.System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.ComponentModel;
using System.Linq;

namespace Eliassen.Extensions;

/// <summary>
/// Suggested IOC configurations
/// </summary>
public static class ServiceCollectionExtensions
{ 
    /// <summary>
    /// Register accessor type that is scoped to as AsyncLocal
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddAccessor<TService>(this IServiceCollection services)
        where TService : class
    {
        services.TryAddSingleton(typeof(IAccessor<>), typeof(Accessor<>));
        return services;
    }

    /// <summary>
    /// Extend configuration options
    /// </summary>
    /// <typeparam name="TConfig"></typeparam>
    /// <param name="services"></param>
    /// <param name="config"></param>
    /// <returns></returns>
    public static IServiceCollection AddConfiguration<TConfig>(
        this IServiceCollection services,
        IConfiguration config
        )
        where TConfig : class
    {
        var section = TypeDescriptor.GetAttributes(typeof(TConfig))
            .OfType<ConfigurationSectionAttribute>()
            .FirstOrDefault()?.ConfigurationSection ?? typeof(TConfig).Name;
        services.Configure<TConfig>(config.GetSection(section));
        return services;
    }

    /// <summary>
    /// Get singleton instance from IOC container
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    /// <typeparam name="TInstance"></typeparam>
    /// <param name="services"></param>
    /// <param name="instance"></param>
    /// <returns></returns>
    public static IServiceCollection GetSingletonInstance<TService, TInstance>(this IServiceCollection services, out TInstance instance)
        where TService : class
        where TInstance : class, TService, new()
    {
        instance = services.FirstOrDefault(i => i.ServiceType == typeof(TService))?.ImplementationInstance as TInstance ?? new TInstance();
        services.Replace(ServiceDescriptor.Singleton<TService>(instance));
        return services;
    }
}
