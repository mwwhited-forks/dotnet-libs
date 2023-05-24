using Eliassen.AspNetCore.Mvc.Filters;
using Eliassen.AspNetCore.Mvc.SwaggerGen;
using Eliassen.System.Accessors;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Nucleus.Api.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Globalization;

namespace Eliassen.AspNetCore.Mvc
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection TryAddAspNetCoreExtensionServices(this IServiceCollection services)
        {
            services.TryAddScoped<ICultureInfoAccessor, CultureInfoAccessor>();
            services.TryAddScoped(sp => sp.GetRequiredService<ICultureInfoAccessor>().CultureInfo);

            services.TryAddScoped<ISearchQueryAccessor, SearchQueryAccessor>();

            services.TryAddScoped<SearchQueryResultFilter>();

            services.AddControllers(opt =>
            {
                opt.Filters.Add(typeof(SearchQueryResultFilter));
                opt.Conventions.Add(new ControllerModelConvention());
            });

            services.TryAddSingleton<IConfigureOptions<SwaggerGenOptions>, AdditionalSwaggerGenEndpointsOptions>();
            services.TryAddSingleton<IConfigureOptions<SwaggerUIOptions>, AdditionalSwaggerUIEndpointsOptions>();
            services.AddSwaggerGen(c => c.OperationFilter<SwaggerFileOperationFilter>());

            return services;
        }
    }
}