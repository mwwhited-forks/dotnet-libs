using Eliassen;
using Eliassen.Apache;
using Eliassen.Apache.Tika;
using Eliassen.Apache.Tika.Handlers;
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;

namespace Eliassen.Apache.Tika.Handlers;


/// <summary>
/// Provides functionality to convert OpenDocument Text (ODT) documents to HTML using Apache Tika.
/// </summary>
public class TikaOdtToHtmlConversionHandler : TikaToHtmlConversionBaseHandler
{
    /// <summary>
    /// Constructor to convert OpenDocument Text (ODT) documents to HTML using Apache Tika.
    /// </summary>
    /// <param name="client">client interface</param>
    /// <param name="logger">system logger</param>
    [ExcludeFromCodeCoverage]
    public TikaOdtToHtmlConversionHandler(
        IApacheTikaClient client,
        ILogger<TikaOdtToHtmlConversionHandler> logger
            ) : base(client, logger)
    {
    }

    /// <summary>
    /// Gets an array of supported source content types for conversion.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public override string[] Sources => ["application/vnd.oasis.opendocument.text"];
}
