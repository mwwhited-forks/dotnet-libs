using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace Eliassen.Azure.StorageAccount.BlobStorage;

/// <summary>
/// Represents a factory for creating instances of <see cref="BlobProvider"/>.
/// </summary>
public class BlobProviderFactory : IBlobProviderFactory
{
    /// <summary>
    /// The key used for document collection.
    /// </summary>
    public const string DocumentCollectionKey = nameof(DocumentCollectionKey);//TODO: do this differently

    /// <summary>
    /// The key used for summary collection.
    /// </summary>
    public const string SummaryCollectionKey = nameof(SummaryCollectionKey);

    private readonly IServiceProvider _serviceProvider;
    private readonly IOptions<AzureBlobProviderOptions> _config;

    /// <summary>
    /// Initializes a new instance of the <see cref="BlobProviderFactory"/> class with the specified dependencies.
    /// </summary>
    /// <param name="serviceProvider">The service provider.</param>
    /// <param name="config">The Azure Blob provider options.</param>
    public BlobProviderFactory(
        IServiceProvider serviceProvider,
        IOptions<AzureBlobProviderOptions> config
        )
    {
        _serviceProvider = serviceProvider;
        _config = config;
    }

    /// <summary>
    /// Creates a new instance of <see cref="BlobProvider"/> based on the specified collection name.
    /// </summary>
    /// <param name="collectionName">The name of the collection.</param>
    /// <returns>A new instance of <see cref="BlobProvider"/>.</returns>
    public BlobProvider Create(string collectionName) =>
        ActivatorUtilities.CreateInstance<BlobProvider>(_serviceProvider, collectionName switch
        {
            DocumentCollectionKey => _config.Value.DocumentCollectionName,
            SummaryCollectionKey => _config.Value.SummaryCollectionName,
            _ => throw new NotSupportedException($"{collectionName} collection key not supported"),
        });
}
