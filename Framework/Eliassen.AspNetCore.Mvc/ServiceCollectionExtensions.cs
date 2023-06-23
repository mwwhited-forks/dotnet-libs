using Eliassen.AspNetCore.Mvc.Filters;
using Eliassen.AspNetCore.Mvc.SwaggerGen;
using Eliassen.System;
using Eliassen.System.Linq.Search;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Globalization;
using System.Security.Claims;

namespace Eliassen.AspNetCore.Mvc
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAspNetCoreExtensions(this IServiceCollection services)
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

            return services;
        }

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
}