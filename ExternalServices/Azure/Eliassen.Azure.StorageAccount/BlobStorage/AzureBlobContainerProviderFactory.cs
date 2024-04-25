using Eliassen.Documents.Containers;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Eliassen.Azure.StorageAccount.BlobStorage;

/// <summary>
/// Represents a factory for creating instances of <see cref="AzureBlobContainerProvider"/>.
/// </summary>
public class AzureBlobContainerProviderFactory : IBlobContainerProviderFactory
{
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="AzureBlobContainerProvider"/> class with the specified dependencies.
    /// </summary>
    /// <param name="serviceProvider">The service provider.</param>
    public AzureBlobContainerProviderFactory(
            IServiceProvider serviceProvider
            )
    {
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Creates a new instance of <see cref="AzureBlobContainerProvider"/> based on the specified collection name.
    /// </summary>
    /// <param name="containerName">The name of the collection.</param>
    /// <returns>A new instance of <see cref="AzureBlobContainerProvider"/>.</returns>
    public IBlobContainerProvider Create(string containerName) =>
        ActivatorUtilities.CreateInstance<AzureBlobContainerProvider>(_serviceProvider, containerName);
}
