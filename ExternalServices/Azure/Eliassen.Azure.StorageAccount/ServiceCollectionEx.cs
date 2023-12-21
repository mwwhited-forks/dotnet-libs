using Eliassen.Azure.StorageAccount.BlobStorage;
using Eliassen.Azure.StorageAccount.MessageQueueing;
using Eliassen.MessageQueueing.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Eliassen.Azure.StorageAccount;

public static class ServiceCollectionEx
{
    public static IServiceCollection TryAddAzureStorageServices(this IServiceCollection services) =>
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
        services.AddTransient<IMessageSenderProvider, AzureStorageQueueMessageProvider>();
        services.TryAddKeyedTransient<IMessageSenderProvider, AzureStorageQueueMessageProvider>(AzureStorageGlobals.MessageProviderKey);

        services.AddTransient<IMessageReceiverProvider, AzureStorageQueueMessageProvider>();
        services.TryAddKeyedTransient<IMessageReceiverProvider, AzureStorageQueueMessageProvider>(AzureStorageGlobals.MessageProviderKey);

        services.TryAddTransient<IQueueClientFactory, QueueClientFactory>();

        return services;
    }
}
