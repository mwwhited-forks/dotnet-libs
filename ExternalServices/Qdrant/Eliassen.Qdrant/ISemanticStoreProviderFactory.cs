namespace Eliassen.Qdrant;

public interface ISemanticStoreProviderFactory
{
    SemanticStoreProvider Create(bool forSummary);
}