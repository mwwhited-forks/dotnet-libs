namespace Eliassen.Search.Semantic;

public interface IVectorStoreProvider : IVectorStore
{
    string ContainerName { get; set; }
}
