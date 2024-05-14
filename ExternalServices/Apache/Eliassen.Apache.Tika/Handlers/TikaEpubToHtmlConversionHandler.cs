using Eliassen;
using Eliassen.Apache;
using Eliassen.Apache.Tika;
using Eliassen.Apache.Tika.Handlers;
using Microsoft.Extensions.Logging;

namespace Eliassen.Apache.Tika.Handlers;

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

