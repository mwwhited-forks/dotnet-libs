using Eliassen.Azure.StorageAccount.BlobStorage;
using Eliassen.Azure.StorageAccount.MessageQueueing;
using Eliassen.Documents.Models;
using Eliassen.Documents;
using Eliassen.MessageQueueing.Services;
using Eliassen.Search.Models;
using Eliassen.Search;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Eliassen.Azure.StorageAccount;

/// <summary>
/// Provides extension methods for configuring Azure Storage services in the <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Tries to add Azure Storage services including blob and queue services to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
    /// <param name="configuration">The <see cref="IConfiguration"/> to add services to.</param>
    /// <param name="azureBlobProviderOptionSection">The name for the ConfigurationSectionName.</param>
    /// <returns>The modified <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection TryAddAzureStorageServices(
        this IServiceCollection services,
        IConfiguration configuration,
#if DEBUG
        string azureBlobProviderOptionSection
#else
        string azureBlobProviderOptionSection = nameof(AzureBlobContainerOptions)
#endif
        ) =>
        services
            .TryAddAzureStorageBlobServices(configuration, azureBlobProviderOptionSection)
            .TryAddAzureStorageQueueServices()
        ;

    /// <summary>
    /// Configures services for Azure Storage Blob.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <param name="configuration">The <see cref="IConfiguration"/> to bind Azure Blob Storage options from.</param>
    /// <param name="azureBlobProviderOptionSection">The configuration section name containing Azure Blob Storage options.</param>
    /// <returns>The modified <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection TryAddAzureStorageBlobServices(
        this IServiceCollection services, 
        IConfiguration configuration,
#if DEBUG
        string azureBlobProviderOptionSection
#else
        string azureBlobProviderOptionSection = nameof(AzureBlobProviderOptions)
#endif
        )
    {
        services.Configure<AzureBlobProviderOptions>(options => configuration.Bind(azureBlobProviderOptionSection, options));
        services.TryAddTransient<IBlobServiceClientFactory, BlobServiceClientFactory>();
        services.TryAddTransient(sp => sp.GetRequiredService<IBlobServiceClientFactory>().Create());
        services.TryAddTransient<IBlobProviderFactory, BlobProviderFactory>();
        services.AddKeyedTransient(BlobProviderFactory.DocumentCollectionKey, (sp, k) => sp.GetRequiredService<IBlobProviderFactory>().Create(k as string));
        services.AddKeyedTransient(BlobProviderFactory.SummaryCollectionKey, (sp, k) => sp.GetRequiredService<IBlobProviderFactory>().Create(k as string));
        services.TryAddTransient<IStoreContent>(sp => sp.GetRequiredKeyedService<BlobProvider>(BlobProviderFactory.DocumentCollectionKey));
        services.TryAddTransient<ISearchContent<SearchResultModel>>(sp => sp.GetRequiredKeyedService<BlobProvider>(BlobProviderFactory.DocumentCollectionKey));
        services.TryAddKeyedTransient<ISearchContent<SearchResultModel>>(SearchTypes.None, (sp, k) => sp.GetRequiredKeyedService<BlobProvider>(BlobProviderFactory.DocumentCollectionKey));
        services.TryAddTransient<IGetContent<ContentReference>>(sp => sp.GetRequiredKeyedService<BlobProvider>(BlobProviderFactory.DocumentCollectionKey));
        services.TryAddTransient<IGetSummary<ContentReference>>(sp => sp.GetRequiredKeyedService<BlobProvider>(BlobProviderFactory.SummaryCollectionKey));
        return services;


        //TODO: retire this
        //        services.TryAddTransient<IDocumentProvider, BlobContainerProvider>();

        //        services.Configure<AzureBlobContainerOptions>(options => configuration.Bind(configurationSection, options));
        //        return services;
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
