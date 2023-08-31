using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Nucleus.External.Microsoft.B2C.Identity;

namespace Nucleus.External.Microsoft.B2C;

public static class ServiceCollectionEx
{
    public static IServiceCollection AddMicrosoftB2CServices(this IServiceCollection services)
    {
        services.TryAddTransient<IIdentityManager, B2CIdentityManager>();
        services.TryAddTransient<IManageGraphUser, ManageGraphUser>();
        services.TryAddTransient<IUserManagementProvider, UserManagementProvider>();
        return services;
    }
}
