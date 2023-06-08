using Eliassen.AspNetCore.Mvc.Filters;
using Eliassen.AspNetCore.Mvc.SwaggerGen;
using Eliassen.System.Accessors;
using Eliassen.System.Linq.Search;
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
            services.TryAddSingleton<IConfigureOptions<SwaggerGenOptions>, AdditionalSwaggerGenEndpointsOptions>();
            services.TryAddSingleton<IConfigureOptions<SwaggerUIOptions>, AdditionalSwaggerUIEndpointsOptions>();
            services.AddControllers(opt =>
            {
                opt.Conventions.Add(new ApiNamespaceControllerModelConvention());
            });
            services.AddSwaggerGen(setup =>
            {
                setup.OperationFilter<FormFileOperationFilter>();
            });
            return services;
        }

        public static IServiceCollection TryAddAspNetCoreSearchQuery(this IServiceCollection services)
        {
            services.AddAccessor<ISearchQuery>();
            services.TryAddSingleton<SearchQueryResultFilter>();
            services.TryAddSearchQueryExtensions();
            services.AddControllers(opt =>
            {
                opt.Filters.Add(typeof(SearchQueryResultFilter));
            });
            services.AddSwaggerGen(setup =>
            {
                setup.OperationFilter<SearchQueryOperationFilter>();
            });

            return services;
        }
    }
}