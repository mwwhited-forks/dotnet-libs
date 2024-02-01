using Eliassen.ApplicationInsights;
using Microsoft.Extensions.DependencyInjection;

namespace Eliassen.Microsoft.ApplicationInsights;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection TryAddApplicationInsightsExtensions(this IServiceCollection services)
    {
        services.AddApplicationInsightsTelemetryProcessor<CorrelationInfoTelemetryProcessor>();
        services.AddApplicationInsightsTelemetryProcessor<UserTelemetryProcessor>();
        return services;
    }
}
