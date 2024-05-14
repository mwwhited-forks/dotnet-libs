using Eliassen;
using Eliassen.Apache;
using Eliassen.Apache.Tika;
using Eliassen.Apache.Tika.Handlers;
using Microsoft.Extensions.Logging;

namespace Eliassen.Apache.Tika.Handlers;

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
