namespace Eliassen.CosmosDb.Services;

/// <summary>
/// Represents options for configuring the OpenAI service.
/// </summary>
public class CosmosDbClientOptions
{
    public string? Connection { get; set; }
    public string? DatabaseName { get; set; }
    public string? CollectionNames { get; set; }
    public string? MaxVectorSearchResults { get; set; }
    public string? VectorIndexType { get; set; }
}
