namespace Eliassen.Documents.Containers;

public interface IBlobContainerFactory
{
    IBlobContainer Create(string containerName);
    IBlobContainer Create<T>();
}
