using Nucleus.Core.Business.Claims;
using Nucleus.Core.Business.Claims.Enhancers;
using Nucleus.Core.Business.Managers;
using Nucleus.Core.Business.Managers.Identity;
using Nucleus.Core.Contracts.Interfaces;
using Nucleus.Core.Contracts.Managers;
using Nucleus.Core.Contracts.Providers;
using Microsoft.Extensions.DependencyInjection;
using Nucleus.External.Azure.StorageAccount.Providers;

namespace Nucleus.Core.Business
{
    public class CoreBusinessRegistrar : IRegistrar
    {
        public IServiceCollection AddServices(IServiceCollection services)
        {
            services.AddTransient<IDocumentProvider, BlobContainerProvider>();
            services.AddTransient<IDocumentManager, DocumentManager>();
            services.AddTransient<IUserSession, ApplicationUser>();
            services.AddTransient<IUserProfileManager, UserProfileManager>();
            services.AddTransient<IUserManagementManager, UserManagementManager>();
            // Claims management services
            services.AddTransient<IClaimsEnhancer, RightsClaimsEnhancer>();
            services.AddTransient<IClaimsEnhancer, UserIdClaimsEnhancer>();
            services.AddTransient<IClaimsProvider, ClaimsProvider>();
            services.AddTransient<IClaimsEnhancerPipeline, ClaimsEnhancerPipeline>();
            services.AddTransient<IClaimsEnhancerFactory, ClaimsEnhancerFactory>();
            // Identity Server (Change Implementation to use other Identity Servers on the line below)
            services.AddTransient<IIdentityManager, B2CIdentityManager>();
            return services;
        }
    }
}
