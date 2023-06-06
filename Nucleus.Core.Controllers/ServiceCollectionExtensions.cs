using Eliassen.System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Nucleus.AspNetCore.Mvc.IdentityModel;
using Nucleus.Core.Controllers.Security;

namespace Nucleus.Core.Controllers
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCoreWebServices(this IServiceCollection services)
        {
            services.TryAddTransient<IUserSession, ApplicationUser>();

            services.AddTransient<IClaimsTransformation, NucluesClaimsTransformation>();

            return services;
        }
    }
}
