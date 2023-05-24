using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Nucleus.AspNetCore.Mvc.Claims;
using Nucleus.AspNetCore.Mvc.IdentityModel;

namespace Nucleus.AspNetCore.Mvc
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationAspNetCoreServices(this IServiceCollection services)
        {
            services.TryAddTransient<IClaimsProvider, ClaimsProvider>();
            services.TryAddTransient<IClaimsEnhancerPipeline, ClaimsEnhancerPipeline>();
            services.TryAddTransient<IClaimsEnhancerFactory, ClaimsEnhancerFactory>();
            return services;
        }
    }
}
