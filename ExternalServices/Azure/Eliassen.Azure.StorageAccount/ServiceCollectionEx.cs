using Eliassen.Azure.StorageAccount.BlobStorage;
using Eliassen.Azure.StorageAccount.MessageQueueing;
using Eliassen.MessageQueueing.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Eliassen.Azure.StorageAccount;

public static class ServiceCollectionEx
{
    public static IServiceCollection AddAzureStorageAccountServices(this IServiceCollection services) =>
        services
            .TryAddAzureStorageBlobServices()
            .TryAddAzureStorageQueueServices()
        ;

    public static IServiceCollection TryAddAzureStorageBlobServices(this IServiceCollection services)
    {
        services.TryAddTransient<IDocumentProvider, BlobContainerProvider>();
        return services;
    }

    public static IServiceCollection TryAddAzureStorageQueueServices(this IServiceCollection services)
    {
        services.TryAddTransient<IMessageSenderProvider, AzureStorageQueueMessageSenderProvider>();
        services.TryAddKeyedTransient<IMessageSenderProvider, AzureStorageQueueMessageSenderProvider>(AzureStorageGlobals.MessageProviderKey);

        return services;
    }
}
