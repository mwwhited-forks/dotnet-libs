using Eliassen.Communications;
using Eliassen.Communications.MessageQueueing;
using Eliassen.Identity;
using Eliassen.MessageQueueing;
using Eliassen.System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Eliassen.Common;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection TryCommonExtensions(
        this IServiceCollection services,
        IConfiguration configuration,

        SystemExtensionBuilder? builder = default
    )
    {
        services.TryAddSystemExtensions(configuration, builder);

        services.TryAddMessageQueueingServices();
        services.TryAddCommunicationQueueServices();
        services.TryAddCommunicationsServices();
        services.TryAddIdentityServices(configuration);

        return services;
    }
}
