using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Eliassen.Search.Semantic;

/// <summary>
/// Represents a factory for creating vector store providers.
/// </summary>
public class VectorStoreProviderFactory : IVectorStoreProviderFactory
{
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="VectorStoreProviderFactory"/> class.
    /// </summary>
    /// <param name="serviceProvider">The service provider used for dependency injection.</param>
    public VectorStoreProviderFactory(IServiceProvider serviceProvider) =>
        _serviceProvider = serviceProvider;

    /// <summary>
    /// Creates a vector store provider with the specified container name.
    /// </summary>
    /// <param name="containerName">The name of the container.</param>
    /// <returns>An instance of <see cref="IVectorStoreProvider"/>.</returns>
    public virtual IVectorStoreProvider Create(string containerName)
    {
        var provider = _serviceProvider.GetKeyedService<IVectorStoreProvider>(containerName);

        provider ??= _serviceProvider.GetServices<IVectorStoreProviderFactory>()
            .Where(i => i is not VectorStoreProviderFactory)
            .Select(i => i.Create(containerName))
            .FirstOrDefault(i => i != null);

        provider ??= _serviceProvider.GetRequiredService<IVectorStoreProvider>();

        provider.ContainerName = containerName;
        return provider;
    }
}
