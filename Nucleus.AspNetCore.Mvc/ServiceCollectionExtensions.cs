using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Nucleus.AspNetCore.Mvc.Authorization;
using Nucleus.AspNetCore.Mvc.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

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

            services.AddControllers(options =>
            {
                options.Filters.Add(new AuthorizeFilter(
                    new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .AddRequirements(
                        new NucleusUserAuthorizationRequirement()
                        //new NucleusActiveUserAuthorizationRequirement()
                        )
                    .Build()
                    ));
            });

            services.AddSingleton<IConfigureOptions<SwaggerUIOptions>, OAuthSwaggerUIOptions>();
            services.AddSingleton<IConfigureOptions<SwaggerGenOptions>, OAuthSwaggerGenOptions>();

            return services;
        }
    }
}
