using Eliassen.Handlebars.Templating;
using Eliassen.System.Net.Mime;
using Eliassen.System.Text.Templating;
using Microsoft.Extensions.DependencyInjection;

namespace Eliassen.Handlebars;

/// <summary>
/// Provides extension methods for configuring services related to Handlebars templates in the <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds services related to Handlebars templates to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <returns>The modified <see cref="IServiceCollection"/> with added Handlebars template services.</returns>
    public static IServiceCollection TryAddHandlebarServices(this IServiceCollection services)
    {
        // Add a transient service for Handlebars template provider.
        //TODO: enable support to used keyed providers for content type
        services.AddTransient<ITemplateProvider, HandlebarsTemplateProvider>();

        // Add a transient service for FileType with default values for Handlebars templates.
        services.AddTransient<IFileType>(_ => new FileType { Extension = ".hbs", ContentType = ContentTypesExtensions.Text.HandlebarsTemplate, IsTemplateType = true });

        return services;
    }
}
