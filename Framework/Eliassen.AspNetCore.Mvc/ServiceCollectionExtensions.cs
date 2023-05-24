using Eliassen.AspNetCore.Mvc.Filters;
using Eliassen.System.Accessors;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
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
            });
            return services;
        }
    }
}