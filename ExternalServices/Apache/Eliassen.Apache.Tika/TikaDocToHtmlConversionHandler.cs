using Microsoft.Extensions.Logging;

namespace Eliassen.Apache.Tika;

/// <summary>
/// Provides functionality to convert Microsoft Word documents to HTML using Apache Tika.
/// </summary>
public class TikaDocToHtmlConversionHandler : TikaToHtmlConversionBaseHandler
{
    public TikaDocToHtmlConversionHandler(
        IApacheTikaClient client,
        ILogger<TikaDocToHtmlConversionHandler> logger
            ):base(client, logger)
    {
    }

    /// <summary>
    /// Gets an array of supported source content types for conversion.
    /// </summary>
    public override string[] Sources => ["application/msword", "application/x-tika-msoffice"];
}
