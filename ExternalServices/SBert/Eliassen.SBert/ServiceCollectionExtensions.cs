using Eliassen.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Eliassen.SBert;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection TryAddSbertServices(
        this IServiceCollection services,
        IConfiguration configuration,
#if DEBUG
        string sbertOptionsSection
#else
        string sbertOptionsSection = nameof(SBertOptions)
#endif
        )
    {
        services.Configure<SBertOptions>(options => configuration.Bind(sbertOptionsSection, options));
        services.TryAddTransient<SBertClient>();
        services.TryAddTransient<IEmbeddingProvider, SentenceEmbeddingProvider>();

        return services;
    }
}
