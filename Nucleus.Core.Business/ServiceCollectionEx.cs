using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Nucleus.Core.Business.Managers;
using Nucleus.Core.Business.Managers.Identity;
using Nucleus.Core.Contracts.Managers;
using Nucleus.Core.Contracts.Providers;
using Nucleus.External.Azure.StorageAccount.Providers;

namespace Nucleus.Core.Business
{
    public static class ServiceCollectionEx
    {
        public static IServiceCollection AddCoreBusinessServices(this IServiceCollection services)
        {
            services.TryAddTransient<IDocumentProvider, BlobContainerProvider>();
            services.TryAddTransient<IDocumentManager, DocumentManager>();
            services.TryAddTransient<IUserProfileManager, UserProfileManager>();
            services.TryAddTransient<IUserManagementManager, UserManagementManager>();
            // Identity Server (Change Implementation to use other Identity Servers on the line below)
            services.TryAddTransient<IIdentityManager, B2CIdentityManager>();
            return services;
        }
    }
}
