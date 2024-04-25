namespace Eliassen.Documents.Containers;

public interface IBlobContainerProvider : IBlobContainer
{
    string ContainerName { get; set; }
}
