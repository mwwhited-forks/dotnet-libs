namespace Eliassen.Qdrant;

/// <summary>
/// Options for configuring Qdrant.
/// </summary>
public class QdrantOptions
{
    /// <summary>
    /// Gets or sets the URL for Qdrant.
    /// </summary>
    public required string Url { get; set; }

    /// <summary>
    /// Gets or sets the collection name for Qdrant.
    /// </summary>
    public required string CollectionName { get; set; }
}
