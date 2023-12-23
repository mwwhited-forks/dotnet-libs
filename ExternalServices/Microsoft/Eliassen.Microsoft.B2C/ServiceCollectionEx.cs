using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Eliassen.Microsoft.B2C.Identity;

namespace Eliassen.Microsoft.B2C;

/// <summary>
/// Extension methods for adding Microsoft B2C services to the service collection.
/// </summary>
public static class ServiceCollectionEx
{
    /// <summary>
    /// Adds Microsoft B2C services to the service collection.
    /// </summary>
    /// <param name="services">The service collection to which Microsoft B2C services should be added.</param>
    /// <returns>The modified service collection.</returns>
    public static IServiceCollection AddMicrosoftB2CServices(this IServiceCollection services)
    {
        services.TryAddTransient<IIdentityManager, ManageGraphUser>();
        services.TryAddTransient<IManageGraphUser, ManageGraphUser>();
        services.TryAddTransient<IUserManagementProvider, UserManagementProvider>();
        return services;
    }
}
