namespace Eliassen.Qdrant;

/// <summary>
/// Interface for a factory that creates instances of <see cref="SemanticStoreProvider"/>.
/// </summary>
public interface ISemanticStoreProviderFactory
{
    /// <summary>
    /// Creates a new instance of <see cref="SemanticStoreProvider"/>.
    /// </summary>
    /// <param name="forSummary">A flag indicating whether the provider is for summary or not.</param>
    /// <returns>A new instance of <see cref="SemanticStoreProvider"/>.</returns>
    SemanticStoreProvider Create(bool forSummary);
}
