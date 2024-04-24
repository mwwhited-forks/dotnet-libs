using Eliassen.Documents.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Eliassen.Documents;

/// <summary>
/// Provides extension methods for configuring document-related services.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Configures services for document processing.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <returns>The modified <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection TryAddDocumentServices(this IServiceCollection services)
    {
        services.TryAddSingleton<IContentProvider, ContentProvider>();//TODO: change this out

        services.TryAddSingleton<IDocumentConversion, DocumentConversion>();
        services.TryAddTransient<IDocumentConversionChainBuilder, DocumentConversionChainBuilder>();
        services.TryAddTransient<IDocumentConversionHandler, ToTextConversionHandler>();

        services.AddTransient<IDocumentType>(_ => new DocumentType
        {
            Name = "HyperText Markup Language",
            FileHeader = [],
            FileExtensions = [".html", ".htm", ".xhtml", ".xhtm"],
            ContentTypes = ["text/html", "text/xhtml", "text/xhtml+xml"],
        });
        services.AddTransient<IDocumentType>(_ => new DocumentType
        {
            Name = "Plain Text",
            FileHeader = [],
            FileExtensions = [".txt", ".text"],
            ContentTypes = ["text/plain"],
        });
        services.AddTransient<IDocumentType>(_ => new DocumentType
        {
            Name = "Extensible Markup Language",
            FileHeader = [],
            FileExtensions = [".xml"],
            ContentTypes = ["text/xml"],
        });
        return services;
    }
}
