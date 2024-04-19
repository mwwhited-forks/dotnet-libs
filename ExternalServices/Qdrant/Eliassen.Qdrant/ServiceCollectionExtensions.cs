using Eliassen.Search;
using Eliassen.Search.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Qdrant.Client.Grpc;

namespace Eliassen.Qdrant;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection TryAddQdrantServices(
        this IServiceCollection services,
        IConfiguration configuration,
#if DEBUG
        string qdrantOptionSection
#else
        string qdrantOptionSection = nameof(QdrantOptions)
#endif
        )
    {
        services.Configure<QdrantOptions>(options => configuration.Bind(qdrantOptionSection, options));
        services.TryAddTransient<IQdrantGrpcClientFactory, QdrantGrpcClientFactory>();
        services.TryAddTransient(sp => sp.GetRequiredService<IQdrantGrpcClientFactory>().Create());
        services.TryAddTransient<ISemanticStoreProviderFactory, SemanticStoreProviderFactory>();

        services.TryAddTransient(sp => sp.GetRequiredService<ISemanticStoreProviderFactory>().Create(false));

        services.TryAddTransient<IPointStructFactory, PointStructFactory>();
        services.TryAddTransient<IStoreContent>(sp => sp.GetRequiredService<SemanticStoreProvider>());
        services.TryAddKeyedTransient<ISearchContent<SearchResultModel>>(SearchTypes.Semantic, (sp, k) => sp.GetRequiredService<SemanticStoreProvider>());
        services.TryAddTransient<ISearchContent<ScoredPoint>>(sp => sp.GetRequiredService<SemanticStoreProvider>());

        return services;
    }
}
