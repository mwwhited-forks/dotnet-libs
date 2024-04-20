namespace Eliassen.Search.Models;

/// <summary>
/// Represents a search result model containing information about a search result.
/// </summary>
public record SearchResultModel
{
    /// <summary>
    /// Gets or initializes the score of the search result.
    /// </summary>
    public required float Score { get; init; }

    /// <summary>
    /// Gets or initializes the hash of the path where the search result was found.
    /// </summary>
    public required string PathHash { get; init; }

    /// <summary>
    /// Gets or initializes the name of the file where the search result was found.
    /// </summary>
    public required string File { get; init; }

    /// <summary>
    /// Gets or initializes the content of the file where the search result was found.
    /// </summary>
    public required string Content { get; init; }

    /// <summary>
    /// Gets or initializes the type of the search result.
    /// </summary>
    public SearchTypes Type { get; init; }
}
