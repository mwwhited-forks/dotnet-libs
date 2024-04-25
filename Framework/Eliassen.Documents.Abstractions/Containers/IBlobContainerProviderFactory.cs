namespace Eliassen.Documents.Containers;

public interface IBlobContainerProviderFactory
{
    IBlobContainerProvider Create(string containerName);
}
