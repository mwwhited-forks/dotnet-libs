using Azure.Storage.Blobs;
using Microsoft.Extensions.Options;

namespace Eliassen.Azure.StorageAccount.BlobStorage;

public class BlobServiceClientFactory : IBlobServiceClientFactory
{
    private readonly IOptions<AzureBlobProviderOptions> _config;

    public BlobServiceClientFactory(
        IOptions<AzureBlobProviderOptions> config
    )
    {
        _config = config;
    }

    public BlobServiceClient Create() => new(_config.Value.ConnectionString);
}
