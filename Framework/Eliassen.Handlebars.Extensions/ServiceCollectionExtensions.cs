using Eliassen.Handlebars.Extensions.Templating;
using Eliassen.System.Templating;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Eliassen.Handlebars.Extensions
{

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddHandlebarServices(this IServiceCollection services)
        {
            services.TryAddTransient<ITemplateProvider, HandlebarsTemplateProvider>();
            return services;
        }
    }
}