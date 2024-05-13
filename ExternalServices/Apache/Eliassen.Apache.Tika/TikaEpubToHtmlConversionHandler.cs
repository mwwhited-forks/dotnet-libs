using Microsoft.Extensions.Logging;

namespace Eliassen.Apache.Tika;

public class TikaEpubToHtmlConversionHandler : TikaToHtmlConversionBaseHandler
{
    public TikaEpubToHtmlConversionHandler(
        IApacheTikaClient client,
        ILogger<TikaEpubToHtmlConversionHandler> logger
            ) : base(client, logger)
    {
    }

    /// <summary>
    /// Gets an array of supported source content types for conversion.
    /// </summary>
    public override string[] Sources => ["application/epub+zip"];
}

