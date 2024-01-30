using Eliassen.Identity.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Eliassen.Identity;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection TryAddIdentityServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.TryAddTransient<IUserManagementProvider, UserManagementProvider>();
        return services;
    }
}
