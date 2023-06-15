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
            services.TryAddTransient(sp => sp.GetRequiredService<IHttpContextAccessor>().HttpContext?.User ?? ClaimsPrincipal.Current);

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