using Eliassen.Documents;
using Eliassen.Documents.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Eliassen.Markdig;

/// <summary>
/// Provides extension methods for configuring services related to Markdig.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Configures services for Markdig.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <returns>The modified <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection TryAddMarkdigServices(this IServiceCollection services)
    {
        services.AddTransient<IDocumentConversionHandler, MarkdownToHtmlConversionHandler>();

        services.AddTransient<IDocumentType>(_ => new DocumentType
        {
            Name = "Markdown",
            FileHeader = [],
            FileExtensions = [".md",],
            ContentTypes = ["text/markdown", "text/x-markdown"],
        });

        return services;
    }
}
