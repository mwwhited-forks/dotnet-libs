using Eliassen;
using Eliassen.Apache;
using Eliassen.Apache.Tika;
using Eliassen.Apache.Tika.Handlers;
using Microsoft.Extensions.Logging;

namespace Eliassen.Apache.Tika.Handlers;

/// <summary>
/// Provides functionality to convert Microsoft Word (DOCX) documents to HTML using Apache Tika.
/// </summary>
public class TikaDocxToHtmlConversionHandler : TikaToHtmlConversionBaseHandler
{
    public TikaDocxToHtmlConversionHandler(
        IApacheTikaClient client,
        ILogger<TikaDocxToHtmlConversionHandler> logger
            ) : base(client, logger)
    {
    }

    /// <summary>
    /// Gets an array of supported source content types for conversion.
    /// </summary>
    public override string[] Sources => [
        "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
        "application/x-tika-ooxml"
    ];
}
