using Eliassen.AspNetCore.JwtAuthentication.Authorization;
using Eliassen.AspNetCore.Mvc.Filters;
using Eliassen.AspNetCore.Mvc.SwaggerGen;
using Eliassen.System;
using Eliassen.System.Linq.Search;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Globalization;
using System.Security.Claims;

namespace Eliassen.AspNetCore.Mvc;

/// <inheritdoc/>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add IOC configurations to support all ASP.Net Core extensions provided by this library.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="requireAuthenticatedByDefault"></param>
    /// <param name="requireApplicationUserId"></param>
    /// <param name="authorizationPolicyBuilder"></param>
    /// <returns></returns>
    public static IServiceCollection TryAddAspNetCoreExtensions(
        this IServiceCollection services,
        bool requireAuthenticatedByDefault = UserAuthorizationRequirement.RequireAuthenticatedByDefault,
        bool requireApplicationUserId = UserAuthorizationRequirement.RequireApplicationUserIdDefault,
        Action<AuthorizationPolicyBuilder>? authorizationPolicyBuilder = null
        )
    {
        services.TryAddCommonOpenApiExtensions();
        services.TryAddAspNetCoreSearchQuery();

        services.AddAccessor<CultureInfo>();

        services.AddHttpContextAccessor();
        services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();
#pragma warning disable CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.
#pragma warning disable CS8621 // Nullability of reference types in return type doesn't match the target delegate (possibly because of nullability attributes).
        services.TryAddTransient(sp => sp.GetRequiredService<IHttpContextAccessor>().HttpContext?.User ?? ClaimsPrincipal.Current);
#pragma warning restore CS8621 // Nullability of reference types in return type doesn't match the target delegate (possibly because of nullability attributes).
#pragma warning restore CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.

        services.AddSwaggerGen();

        if (requireAuthenticatedByDefault)
        {
            services.AddRequireAuthenticatedUser(requireApplicationUserId, authorizationPolicyBuilder);
        }

        return services;
    }

    public static IServiceCollection AddRequireAuthenticatedUser(
        this IServiceCollection services,
        bool requireApplicationUserId = UserAuthorizationRequirement.RequireApplicationUserIdDefault,
        Action<AuthorizationPolicyBuilder>? authorizationPolicyBuilder = null
        )
    {
        // Adding in the magic sauce that connects B2C Bearer tokens to our internal users
        services.AddSingleton<IAuthorizationHandler, UserAuthorizationHandler>();

        //Policy builder

        var policyBuilder = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .AddRequirements(new UserAuthorizationRequirement(requireApplicationUserId));
        authorizationPolicyBuilder?.Invoke(policyBuilder);

        var authorizationPolicy = policyBuilder.Build();

        services.AddAuthorization(options =>
        {
            options.DefaultPolicy = authorizationPolicy;
        });

        services.AddControllers(options =>
        {
            options.Filters.Add(new AuthorizeFilter(authorizationPolicy));
        });

        return services;
    }


    /// <summary>
    /// Enable extensions for Swagger/OpenAPI (included in AddAspNetCoreExtensions)
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection TryAddCommonOpenApiExtensions(this IServiceCollection services)
    {
        services.AddSingleton<IConfigureOptions<SwaggerGenOptions>, AddOperationFilterOptions<FormFileOperationFilter>>();
        services.AddSingleton<IConfigureOptions<SwaggerGenOptions>, AdditionalSwaggerGenEndpointsOptions>();
        services.AddSingleton<IConfigureOptions<SwaggerUIOptions>, AdditionalSwaggerUIEndpointsOptions>();
        services.AddControllers(opt =>
        {
            opt.Conventions.Add(new ApiNamespaceControllerModelConvention());
        });
        return services;
    }

    /// <summary>
    /// Enable extensions for shared Search Query extensions (included in AddAspNetCoreExtensions)
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection TryAddAspNetCoreSearchQuery(this IServiceCollection services)
    {
        services.AddSingleton<IConfigureOptions<SwaggerGenOptions>, AddOperationFilterOptions<SearchQueryOperationFilter>>();
        services.AddSingleton<IConfigureOptions<MvcOptions>, AddMvcFilterOptions<SearchQueryResultFilter>>();
        services.AddAccessor<ISearchQuery>();
        services.TryAddSingleton<SearchQueryResultFilter>();
        services.TryAddSearchQueryExtensions();

        return services;
    }
}