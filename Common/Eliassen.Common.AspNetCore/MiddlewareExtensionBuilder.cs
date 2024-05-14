namespace Eliassen.Common.AspNetCore;

public record MiddlewareExtensionBuilder
{
    public string? HealthCheckPath { get; init; } = "/health";
}
