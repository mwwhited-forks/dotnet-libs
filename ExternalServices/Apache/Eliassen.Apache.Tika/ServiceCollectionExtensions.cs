using Eliassen.Documents.Conversion;
using Eliassen.Documents.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Eliassen.Apache.Tika;

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
    public static IServiceCollection TryAddApacheTikaServices(
        this IServiceCollection services
        )
    {
        services.AddTransient<IDocumentConversionHandler, TikaDocToHtmlConversionHandler>();
        services.AddTransient<IDocumentConversionHandler, TikaDocxToHtmlConversionHandler>();
        services.AddTransient<IDocumentConversionHandler, TikaOdtToHtmlConversionHandler>();
        services.AddTransient<IDocumentConversionHandler, TikaPdfToHtmlConversionHandler>();

        services.AddTransient<IDocumentType>(_ => new DocumentType
        {
            Name = "Microsoft Word",
            FileHeader = [],
            FileExtensions = [".doc",],
            ContentTypes = [
                "application/msword",
                ],
        });
        services.AddTransient<IDocumentType>(_ => new DocumentType
        {
            Name = "Microsoft Word - OpenXML",
            FileHeader = [],
            FileExtensions = [".docx",],
            ContentTypes = [
                "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                "application/x-tika-ooxml",
                ],
        });
        services.AddTransient<IDocumentType>(_ => new DocumentType
        {
            Name = "Portable Document Format",
            FileHeader = [(byte)'%', (byte)'P', (byte)'D', (byte)'F', (byte)'-'],
            FileExtensions = [".pdf",],
            ContentTypes = ["application/pdf"],
        });

        services.AddTransient<IDocumentType>(_ => new DocumentType
        {
            Name = "Open Office Document",
            FileHeader = [],
            FileExtensions = [".odt",],
            ContentTypes = ["application/vnd.oasis.opendocument.text"],
        });

        return services;
    }
}
