using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Eliassen.Azure.StorageAccount;

public static class ServiceCollectionEx
{
    public static IServiceCollection AddAzureStorageAccountServices(this IServiceCollection services)
    {
        services.TryAddTransient<IDocumentProvider, BlobContainerProvider>();
        return services;
    }
}
