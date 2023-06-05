using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Nucleus.AspNetCore.Mvc.Claims.Enhancers;
using Nucleus.AspNetCore.Mvc.IdentityModel;
using Nucleus.Core.Business.Claims.Enhancers;
using Nucleus.Core.Controllers.Security;

namespace Nucleus.Core.Controllers
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCoreWebServices(this IServiceCollection services)
        {
            services.TryAddTransient<IUserSession, ApplicationUser>();

            // Claims management services
            services.AddTransient<IClaimsEnhancer, UserIdClaimsEnhancer>();
            services.AddTransient<IClaimsEnhancer, RightsClaimsEnhancer>();

            return services;
        }
    }
}
