using System.Text.Json.Nodes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Eliassen.Search;
using Eliassen.Search.Models;

namespace Eliassen.OpenSearch;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection TryAddOpenSearchServices(
        this IServiceCollection services,
        IConfiguration configuration,
        #if DEBUG
        string openSearchOptionSections
#else
        string openSearchOptionSections = nameof(OpenSearchOptions)
#endif
        )
    {
        services.Configure<OpenSearchOptions>(options => configuration.Bind(openSearchOptionSections, options));
        services.Configure<OpenSearchOptions>(nameof(OpenSearchOptions), opt => { });
        services.TryAddTransient<IOpenSearchClientFactory, OpenSearchClientFactory>();
        services.TryAddTransient(sp => sp.GetRequiredService<IOpenSearchClientFactory>().Create());
        services.TryAddTransient<LexicalProvider>();
        services.TryAddTransient<IStoreContent, LexicalProvider>();
        services.TryAddKeyedTransient<ISearchContent<SearchResultModel>, LexicalProvider>(SearchTypes.Lexical);
        services.TryAddTransient<ISearchContent<JsonNode>, LexicalProvider>();

        return services;
    }
}
