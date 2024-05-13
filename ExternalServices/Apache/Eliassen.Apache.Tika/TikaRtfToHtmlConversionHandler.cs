using Microsoft.Extensions.Logging;

namespace Eliassen.Apache.Tika;

/// <summary>
/// Provides functionality to convert Rich Text Format (RTF) documents to HTML using Apache Tika.
/// </summary>
public class TikaRtfToHtmlConversionHandler : TikaToHtmlConversionBaseHandler
{
    public TikaRtfToHtmlConversionHandler(
        IApacheTikaClient client,
        ILogger<TikaRtfToHtmlConversionHandler> logger
            ) : base(client, logger)
    {
    }

    /// <summary>
    /// Gets an array of supported source content types for conversion.
    /// </summary>
    public override string[] Sources => ["application/rtf"];
}
