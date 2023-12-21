using Eliassen.Handlebars.Extensions.Templating;
using Eliassen.System.Text.Templating;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Eliassen.Handlebars.Extensions
{

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection TryAddHandlebarServices(this IServiceCollection services)
        {
            services.AddTransient<ITemplateProvider, HandlebarsTemplateProvider>();
            services.AddTransient<IFileType>(_ => new FileType { Extension = ".hbs", ContentType = "text/x-handlebars-template", IsTemplateType = true });
            return services;
        }
    }
}