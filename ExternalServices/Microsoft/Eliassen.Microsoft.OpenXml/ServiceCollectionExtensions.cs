using Eliassen.Documents;
using Eliassen.Documents.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Eliassen.Microsoft.OpenXml;

/// <summary>
/// Provides extension methods for configuring services related to MysticMind.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Configures services for MysticMind.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <returns>The modified <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection TryAddMicrosoftOpenXmlServices(this IServiceCollection services)
    {
        services.AddTransient<IDocumentConversionHandler, DocxToMarkdownConversionHandler>();

        services.AddTransient<IDocumentType>(_ => new DocumentType
        {
            Name = "OpenXML DocX",
            FileHeader = [],
            FileExtensions = [".docx",],
            ContentTypes = ["application/vnd.openxmlformats-officedocument.wordprocessingml.document"],
        });

        return services;
    }
}
