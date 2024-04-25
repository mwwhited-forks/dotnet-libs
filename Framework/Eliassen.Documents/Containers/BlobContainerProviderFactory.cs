using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Eliassen.Documents.Containers;

public class BlobContainerProviderFactory : IBlobContainerProviderFactory
{
    private readonly IServiceProvider _serviceProvider;

    public BlobContainerProviderFactory(IServiceProvider serviceProvider) =>
        _serviceProvider = serviceProvider;

    public IBlobContainerProvider Create(string containerName)
    {
        var provider = _serviceProvider.GetKeyedService<IBlobContainerProvider>(containerName);

        provider ??= _serviceProvider.GetServices<IBlobContainerProviderFactory>()
            .Where(i => i is not BlobContainerProviderFactory)
            .Select(i => i.Create(containerName))
            .FirstOrDefault(i=>i!= null);

        provider ??= _serviceProvider.GetRequiredService<IBlobContainerProvider>();

        provider.ContainerName = containerName;
        return provider;
    }
}
