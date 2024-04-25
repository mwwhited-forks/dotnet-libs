using System.Collections.Generic;

namespace Eliassen.Documents.Models;

public record ContentMetaDataReference
{

    /// <summary>
    /// Gets or initializes the content type of the content.
    /// </summary>
    public required string ContentType { get; init; }

    /// <summary>
    /// Gets or initializes the file name associated with the content.
    /// </summary>
    public required string FileName { get; init; }

    public Dictionary<string, string>? MetaData { get; init; }
}
