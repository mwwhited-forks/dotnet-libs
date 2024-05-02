using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Eliassen.Documents.Containers;

/// <summary>
/// Represents a factory for creating blob containers.
/// </summary>
public class BlobContainerFactory : IBlobContainerFactory
{
    private readonly IBlobContainerProviderFactory _factory;

    /// <summary>
    /// Initializes a new instance of the <see cref="BlobContainerFactory"/> class.
    /// </summary>
    /// <param name="factory">The factory used to create blob container providers.</param>
    public BlobContainerFactory(
        IBlobContainerProviderFactory factory
        ) => _factory = factory;

    /// <summary>
    /// Creates a blob container with the specified container name.
    /// </summary>
    /// <param name="containerName">The name of the container.</param>
    /// <returns>An instance of <see cref="IBlobContainer"/>.</returns>
    public IBlobContainer Create(string containerName) =>
       new WrappedBlobContainer(_factory.Create(containerName));

    /// <summary>
    /// Creates a blob container with a name derived from the specified type.
    /// </summary>
    /// <typeparam name="T">The type used to derive the container name.</typeparam>
    /// <returns>An instance of <see cref="IBlobContainer"/>.</returns>
    public IBlobContainer Create<T>() =>
        Create(
            typeof(T).GetCustomAttribute<BlobContainerAttribute>()?.ContainerName ??
            typeof(T).GetCustomAttribute<TableAttribute>()?.Name ??
            typeof(T).Name
            );
}
