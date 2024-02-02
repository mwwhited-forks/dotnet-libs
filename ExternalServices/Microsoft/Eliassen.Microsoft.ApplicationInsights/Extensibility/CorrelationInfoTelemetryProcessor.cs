using Eliassen.System.Accessors;
using Eliassen.System.Net.Http;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;

namespace Eliassen.ApplicationInsights;

public class CorrelationInfoTelemetryProcessor : ITelemetryProcessor
{
    private readonly IAccessor<CorrelationInfo> _correlationAccessor;
    public CorrelationInfoTelemetryProcessor(
        IAccessor<CorrelationInfo> stringAccessor
        )
    {
        _correlationAccessor = stringAccessor;
    }
    public void Process(ITelemetry item)
    {
        var correlationId = _correlationAccessor.Value?.CorrelationId;
        if (!string.IsNullOrWhiteSpace(correlationId))
            item.Context.GlobalProperties[DefinedHttpHeaders.CorrelationIdHeader] = correlationId;
        var requestId = _correlationAccessor.Value?.RequestId;
        if (!string.IsNullOrWhiteSpace(requestId))
            item.Context.GlobalProperties[DefinedHttpHeaders.RequestIdHeader] = requestId;
    }
}
