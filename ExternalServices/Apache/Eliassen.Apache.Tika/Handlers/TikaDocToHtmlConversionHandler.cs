﻿using Eliassen;
using Eliassen.Apache;
using Eliassen.Apache.Tika;
using Eliassen.Apache.Tika.Handlers;
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;

namespace Eliassen.Apache.Tika.Handlers;

/// <summary>
/// Provides functionality to convert Microsoft Word documents to HTML using Apache Tika.
/// </summary>
public class TikaDocToHtmlConversionHandler : TikaToHtmlConversionBaseHandler
{
    /// <summary>
    /// Constructor to convert Microsoft Word documents to HTML using Apache Tika.
    /// </summary>
    /// <param name="client">client interface</param>
    /// <param name="logger">system logger</param>
    [ExcludeFromCodeCoverage]
    public TikaDocToHtmlConversionHandler(
        IApacheTikaClient client,
        ILogger<TikaDocToHtmlConversionHandler> logger
            ) : base(client, logger)
    {
    }

    /// <summary>
    /// Gets an array of supported source content types for conversion.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public override string[] Sources => ["application/msword", "application/x-tika-msoffice"];
}