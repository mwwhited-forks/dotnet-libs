using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Nucleus.AspNetCore.Mvc.Authorization;
using Nucleus.AspNetCore.Mvc.Claims.Enhancers;
using Nucleus.AspNetCore.Mvc.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Nucleus.AspNetCore.Mvc
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationAspNetCoreServices(this IServiceCollection services)
        {
            // Adding in the magic sauce that connects B2C Bearer tokens to our internal users
            services.AddSingleton<IAuthorizationHandler, NucleusUserAuthorizationHandler>();

            //TODO: clean this policy up
            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .AddRequirements(new NucleusUserAuthorizationRequirement())
                .Build();
            });

            var existing = services.Where(i => i.ServiceType == typeof(IClaimsTransformation)).ToArray();

            var serviceDescriptor = ServiceDescriptor.Transient<IClaimsTransformation, UserIdClaimsTransformation>();
            //if (existing != null)
            //{
            //    services.Insert(services.IndexOf(existing), serviceDescriptor);
            //}
            //else
            //{
            services.Add(serviceDescriptor);
            //}

            //services.AddTransient<IClaimsTransformation, AllClaimsTransformation>();

            //var existing = services.Where(i => i.ServiceType == typeof(IClaimsTransformation)).ToArray();
            //foreach (var exist in existing)
            //    services.Remove(exist);
            //services.AddTransient<IClaimsTransformation, UserIdClaimsTransformation>();
            //foreach (var exist in existing)
            //    services.Add(exist);

            services.AddSingleton<IConfigureOptions<SwaggerUIOptions>, OAuthSwaggerUIOptions>();
            services.AddSingleton<IConfigureOptions<SwaggerGenOptions>, OAuthSwaggerGenOptions>();

            return services;
        }
    }


    //public class AllClaimsTransformation : IClaimsTransformation
    //{
    //    private readonly IEnumerable<IClaimsTransformation> _all;

    //    public AllClaimsTransformation(
    //        IEnumerable<IClaimsTransformation> all
    //        )
    //    {
    //        _all = all;
    //    }

    //    public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    //    {
    //        foreach(var transform in _all.Where(i=>i != this))
    //        {
    //            principal = await transform.TransformAsync(principal);
    //        }
    //        return principal;
    //    }
    //}

    //var serviceDescriptor = ServiceDescriptor.Transient<IClaimsTransformation, UserIdClaimsTransformation>();
}
