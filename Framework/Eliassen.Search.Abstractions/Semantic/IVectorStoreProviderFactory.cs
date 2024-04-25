namespace Eliassen.Search.Semantic;

public interface IVectorStoreProviderFactory
{
    IVectorStoreProvider Create(string containerName);
}
