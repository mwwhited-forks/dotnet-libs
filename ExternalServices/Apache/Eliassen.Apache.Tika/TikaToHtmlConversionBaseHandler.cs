﻿using Microsoft.Extensions.Logging;

namespace Eliassen.Apache.Tika;

/// <summary>
/// Provides a base class for handlers that convert documents to HTML using Apache Tika.
/// </summary>
public abstract class TikaToHtmlConversionBaseHandler : TikaConversionHandlerBase
{
    protected TikaToHtmlConversionBaseHandler(
        IApacheTikaClient client,
        ILogger logger
            ) : base(client, logger)
    {
    }

    /// <summary>
    /// Gets an array of supported destination content types for conversion.
    /// </summary>
    public override string[] Destinations => ["text/html", "text/xhtml", "text/xhtml+xml",];
}
