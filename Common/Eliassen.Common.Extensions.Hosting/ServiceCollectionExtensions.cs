using Eliassen.MailKit.Hosting;
using Eliassen.MessageQueueing.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Eliassen.Common.Extensions.Hosting;

/// <summary>
/// Provides extension methods for configuring common hosting services in the <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Tries to add common hosting services to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> instance.</param>
    /// <param name="configuration">The configuration containing settings for hosting services.</param>
    /// <param name="builder">Optional builder for configuring hosting extensions. Default is <c>null</c>.</param>
    /// <returns>The updated <see cref="IServiceCollection"/> instance.</returns>
    public static IServiceCollection TryCommonHostingExtensions(
        this IServiceCollection services,
        IConfiguration configuration,
        HostingExtensionsBuilder? builder = default
    )
    {
        builder ??= new();

        // Add MailKit hosting if not disabled
        if (!builder.DisableMailKit)
            services.TryAddMailKitHosting();

        // Add MessageQueueing hosting if not disabled
        if (!builder.DisableMessageQueueing)
            services.TryAddMessageQueueingHosting();

        return services;
    }
}
