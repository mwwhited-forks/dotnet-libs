namespace Eliassen.Search.Semantic;

public interface IVectorStoreFactory
{
    IVectorStore Create(string containerName);
    IVectorStore Create<T>();
}
