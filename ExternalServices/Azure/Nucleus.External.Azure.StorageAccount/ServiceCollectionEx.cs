using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Nucleus.External.Azure.StorageAccount;

public static class ServiceCollectionEx
{
    public static IServiceCollection AddAzureStorageAccountServices(this IServiceCollection services)
    {
        services.TryAddTransient<IDocumentProvider, BlobContainerProvider>();
        return services;
    }
}
