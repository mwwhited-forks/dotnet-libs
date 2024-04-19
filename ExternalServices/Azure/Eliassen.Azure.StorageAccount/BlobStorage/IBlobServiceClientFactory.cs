using Azure.Storage.Blobs;

namespace Eliassen.Azure.StorageAccount.BlobStorage;

public interface IBlobServiceClientFactory
{
    BlobServiceClient Create();
}
