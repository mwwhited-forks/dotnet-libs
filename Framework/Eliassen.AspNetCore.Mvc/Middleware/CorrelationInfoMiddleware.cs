using Eliassen.System.Accessors;
using Eliassen.System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Eliassen.AspNetCore.Mvc.Middleware;

public class CorrelationInfoMiddleware
{
    private readonly RequestDelegate _next;

    public CorrelationInfoMiddleware(
        RequestDelegate next
        )
    {
        _next = next;
    }

    public async Task Invoke(
        HttpContext context,
        ILogger<CorrelationInfoMiddleware> logger,
        IAccessor<CorrelationInfo> correlationAccessor
        )
    {
        correlationAccessor.Value ??= new();

        {
            var correlationId = context.Request.Headers[DefinedHttpHeaders.CorrelationIdHeader];
            var requestId = context.Request.Headers[DefinedHttpHeaders.RequestIdHeader];

            correlationId = correlationAccessor.Value.CorrelationId = string.IsNullOrWhiteSpace(correlationId) ? Guid.NewGuid().ToString() : correlationId;
            correlationAccessor.Value.RequestId = string.IsNullOrWhiteSpace(requestId) ? (string?)null : requestId;

            logger.LogInformation($"Invoke: {{{nameof(correlationId)}}}/{{{nameof(requestId)}}}", correlationId, requestId);
        }

        context.Response.OnStarting(state =>
        {
            var accessor = state as IAccessor<CorrelationInfo>;

            var correlationId = correlationAccessor.Value?.CorrelationId;
            var requestId = correlationAccessor.Value?.RequestId;

            if (!string.IsNullOrWhiteSpace(correlationId)) context.Response.Headers[DefinedHttpHeaders.CorrelationIdHeader] = correlationId;
            if (!string.IsNullOrWhiteSpace(requestId)) context.Response.Headers[DefinedHttpHeaders.RequestIdHeader] = requestId;

            logger.LogInformation($"Return: {{{nameof(correlationId)}}}/{{{nameof(requestId)}}}", correlationId, requestId);

            return Task.CompletedTask;

        }, correlationAccessor);

        await _next.Invoke(context);
    }
}
