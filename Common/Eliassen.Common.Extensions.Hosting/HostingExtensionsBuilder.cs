namespace Eliassen.Common.Extensions.Hosting;

public record HostingExtensionsBuilder
{
    public bool DisableMailKit { get; init; } = false;
    public bool DisableMessageQueueing { get; init; } = false;
}
