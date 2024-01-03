using Eliassen.Azure.StorageAccount.BlobStorage;
using Eliassen.Azure.StorageAccount.MessageQueueing;
using Eliassen.MessageQueueing.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Eliassen.Azure.StorageAccount;

/// <summary>
/// Provides extension methods for configuring Azure Storage services in the <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionEx
{
    /// <summary>
    /// Tries to add Azure Storage services including blob and queue services to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
    /// <returns>The modified <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection TryAddAzureStorageServices(this IServiceCollection services) =>
        services
            .TryAddAzureStorageBlobServices()
            .TryAddAzureStorageQueueServices()
        ;

    /// <summary>
    /// Tries to add Azure Storage blob services to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
    /// <returns>The modified <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection TryAddAzureStorageBlobServices(this IServiceCollection services)
    {
        services.TryAddTransient<IDocumentProvider, BlobContainerProvider>();
        return services;
    }

    /// <summary>
    /// Tries to add Azure Storage queue services to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
    /// <returns>The modified <see cref="IServiceCollection"/>.</returns>
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
