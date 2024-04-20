using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace Eliassen.Qdrant;

/// <summary>
/// Factory for creating instances of SemanticStoreProvider.
/// </summary>
public class SemanticStoreProviderFactory : ISemanticStoreProviderFactory
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IOptions<QdrantOptions> _options;

    /// <summary>
    /// Initializes a new instance of the <see cref="SemanticStoreProviderFactory"/> class.
    /// </summary>
    /// <param name="serviceProvider">The service provider for creating instances.</param>
    /// <param name="options">The Qdrant options.</param>
    public SemanticStoreProviderFactory(
        IServiceProvider serviceProvider,
        IOptions<QdrantOptions> options
        )
    {
        _serviceProvider = serviceProvider;
        _options = options;
    }

    /// <summary>
    /// Creates a new instance of SemanticStoreProvider.
    /// </summary>
    /// <param name="forSummary">Indicates whether the provider is for summary.</param>
    /// <returns>A new instance of SemanticStoreProvider.</returns>
    public SemanticStoreProvider Create(bool forSummary) =>
        ActivatorUtilities.CreateInstance<SemanticStoreProvider>(_serviceProvider, _options.Value.CollectionName, forSummary);
}
