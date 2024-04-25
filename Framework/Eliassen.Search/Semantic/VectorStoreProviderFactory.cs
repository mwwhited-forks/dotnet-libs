using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Eliassen.Search.Semantic;

public class VectorStoreProviderFactory : IVectorStoreProviderFactory
{
    private readonly IServiceProvider _serviceProvider;

    public VectorStoreProviderFactory(IServiceProvider serviceProvider) =>
        _serviceProvider = serviceProvider;

    public IVectorStoreProvider Create(string containerName)
    {
        var provider = _serviceProvider.GetKeyedService<IVectorStoreProvider>(containerName);

        provider ??= _serviceProvider.GetServices<IVectorStoreProviderFactory>()
            .Where(i => i is not VectorStoreProviderFactory)
            .Select(i => i.Create(containerName))
            .FirstOrDefault(i => i != null);

        provider ??= _serviceProvider.GetRequiredService<IVectorStoreProvider>();

        provider.ContainerName = containerName;
        return provider;
    }
}
