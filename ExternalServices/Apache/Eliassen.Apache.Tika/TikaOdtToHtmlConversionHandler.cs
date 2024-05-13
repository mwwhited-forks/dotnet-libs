using Microsoft.Extensions.Logging;

namespace Eliassen.Apache.Tika;


/// <summary>
/// Provides functionality to convert OpenDocument Text (ODT) documents to HTML using Apache Tika.
/// </summary>
public class TikaOdtToHtmlConversionHandler : TikaToHtmlConversionBaseHandler
{
    public TikaOdtToHtmlConversionHandler(
        IApacheTikaClient client,
        ILogger<TikaOdtToHtmlConversionHandler> logger
            ) : base(client, logger)
    {
    }

    /// <summary>
    /// Gets an array of supported source content types for conversion.
    /// </summary>
    public override string[] Sources => ["application/vnd.oasis.opendocument.text"];
}
