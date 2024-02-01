using Eliassen.System.Security.Claims;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Http;

namespace Eliassen.ApplicationInsights;

public class UserTelemetryProcessor : ITelemetryProcessor
{
    private readonly IHttpContextAccessor _accessor;

    public UserTelemetryProcessor(
        IHttpContextAccessor accessor
        )
    {
        _accessor = accessor;
    }

    public void Process(ITelemetry item)
    {
        var user = _accessor.HttpContext?.User;
        if (user != null)
        {
            var objectId = user.Claims.FirstOrDefault(c => c.Type == CommonClaims.ObjectId)?.Value;
            if (!string.IsNullOrWhiteSpace(objectId))
                item.Context.GlobalProperties[$"Claim-{CommonClaims.ObjectId}"] = objectId;

            var userId = user.Claims.FirstOrDefault(c => c.Type == CommonClaims.UserId)?.Value;
            if (!string.IsNullOrWhiteSpace(userId))
                item.Context.GlobalProperties[$"Claim-{CommonClaims.UserId}"] = userId;
        }
    }
}
