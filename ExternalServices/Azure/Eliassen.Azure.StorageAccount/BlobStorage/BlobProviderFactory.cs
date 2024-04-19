using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace Eliassen.Azure.StorageAccount.BlobStorage;

public class BlobProviderFactory : IBlobProviderFactory
{
    public const string DocumentCollectionKey = nameof(DocumentCollectionKey);//TODO: do this differently
    public const string SummaryCollectionKey = nameof(SummaryCollectionKey);

    private readonly IServiceProvider _serviceProvider;
    private readonly IOptions<AzureBlobProviderOptions> _config;

    public BlobProviderFactory(
        IServiceProvider serviceProvider,
        IOptions<AzureBlobProviderOptions> config
        )
    {
        _serviceProvider = serviceProvider;
        _config = config;
    }

    public BlobProvider Create(string collectionName) =>
        ActivatorUtilities.CreateInstance<BlobProvider>(_serviceProvider, collectionName switch
        {
            DocumentCollectionKey => _config.Value.DocumentCollectionName,
            SummaryCollectionKey => _config.Value.SummaryCollectionName,
            _ => throw new NotSupportedException($"{collectionName} collection key not supported"),
        });
}
