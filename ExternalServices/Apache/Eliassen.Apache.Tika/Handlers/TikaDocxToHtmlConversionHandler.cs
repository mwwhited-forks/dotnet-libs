using Eliassen;
using Eliassen.Apache;
using Eliassen.Apache.Tika;
using Eliassen.Apache.Tika.Handlers;
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;

namespace Eliassen.Apache.Tika.Handlers;

/// <summary>
/// Provides functionality to convert Microsoft Word (DOCX) documents to HTML using Apache Tika.
/// </summary>
public class TikaDocxToHtmlConversionHandler : TikaToHtmlConversionBaseHandler
{
    public static readonly string[] SOURCES = [
        "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
        "application/x-tika-ooxml"
    ];

    /// <summary>
    /// Constructor to convert Microsoft Word (DOCX) documents to HTML using Apache Tika.
    /// </summary>
    /// <param name="client">client interface</param>
    /// <param name="logger">system logger</param>
    [ExcludeFromCodeCoverage]
    public TikaDocxToHtmlConversionHandler(
        IApacheTikaClient client,
        ILogger<TikaDocxToHtmlConversionHandler> logger
            ) : base(client, logger)
    {
    }

    /// <summary>
    /// Gets an array of supported source content types for conversion.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public override string[] Sources => SOURCES;
}
