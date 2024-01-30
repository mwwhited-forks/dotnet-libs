using Eliassen.MailKit.Hosting;
using Eliassen.MessageQueueing.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Eliassen.Common.Extensions.Hosting;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection TryCommonHostingExtensions(
        this IServiceCollection services,
        IConfiguration configuration,
        HostingExtensionsBuilder? builder = default
    )
    {
        builder ??= new();
        if (!builder.DisableMailKit) services.TryAddMailKitHosting();
        if (!builder.DisableMessageQueueing) services.TryAddMessageQueueingHosting();
        return services;
    }
}
