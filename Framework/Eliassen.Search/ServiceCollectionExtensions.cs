using Eliassen.Search.Models;
using Eliassen.Search.Providers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Eliassen.Search;

/// <summary>
/// Provides extension methods for configuring search-related services.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Configures services for search functionality.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <returns>The modified <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection TryAddSearchServices(this IServiceCollection services)
    {
        services.TryAddTransient<ISummarizeContent, DocumentSummaryGenerationProvider>();
        services.TryAddTransient<ISearchContent<SearchResultModel>, HybridProvider>();
        services.TryAddKeyedTransient<ISearchContent<SearchResultModel>, HybridProvider>(SearchTypes.Hybrid);

        services.TryAddTransient<ISearchProvider, SearchProvider>();

        return services;
    }
}
