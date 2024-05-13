using Microsoft.Extensions.Logging;

namespace Eliassen.Apache.Tika;

/// <summary>
/// Provides functionality to convert PDF documents to HTML using Apache Tika.
/// </summary>
public class TikaPdfToHtmlConversionHandler : TikaToHtmlConversionBaseHandler
{
    public TikaPdfToHtmlConversionHandler(
        IApacheTikaClient client,
        ILogger<TikaPdfToHtmlConversionHandler> logger
            ) : base(client, logger)
    {
    }

    /// <summary>
    /// Gets an array of supported source content types for conversion.
    /// </summary>
    public override string[] Sources => ["application/pdf"];
}
