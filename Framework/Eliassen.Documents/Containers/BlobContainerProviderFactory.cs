using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Eliassen.Documents.Containers;

/// <summary>
/// Represents a factory for creating blob container providers.
/// </summary>
public class BlobContainerProviderFactory : IBlobContainerProviderFactory
{
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="BlobContainerProviderFactory"/> class.
    /// </summary>
    /// <param name="serviceProvider">The service provider used for dependency injection.</param>
    public BlobContainerProviderFactory(IServiceProvider serviceProvider) =>
        _serviceProvider = serviceProvider;

    /// <summary>
    /// Creates a blob container provider with the specified container name.
    /// </summary>
    /// <param name="containerName">The name of the container.</param>
    /// <returns>An instance of <see cref="IBlobContainerProvider"/>.</returns>
    public IBlobContainerProvider? Create(string containerName)
    {
        var provider = _serviceProvider.GetKeyedService<IBlobContainerProvider>(containerName);

        provider ??= _serviceProvider.GetServices<IBlobContainerProviderFactory>()
            .Where(i => i is not BlobContainerProviderFactory)
            .Select(i => i.Create(containerName))
            .FirstOrDefault(i => i != null);

        provider ??= _serviceProvider.GetRequiredService<IBlobContainerProvider>();

        provider.ContainerName = containerName;
        return provider;
    }
}
