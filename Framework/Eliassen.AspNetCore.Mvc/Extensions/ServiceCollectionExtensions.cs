using Eliassen.AspNetCore.Mvc.Filters;
using Eliassen.AspNetCore.Mvc.SwaggerGen;
using Eliassen.System;
using Eliassen.System.Accessors;
using Eliassen.System.Linq.Search;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Eliassen.AspNetCore.Mvc.Extensions
{
    public static class ServiceCollectionExtensions
    {
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