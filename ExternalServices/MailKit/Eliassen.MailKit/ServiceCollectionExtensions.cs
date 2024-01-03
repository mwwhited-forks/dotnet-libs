using Eliassen.Communications.Models;
using Eliassen.Communications.Services;
using Eliassen.MailKit.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Eliassen.MailKit;

/// <summary>
/// Extensions for adding MailKit services to the <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Tries to add MailKit extensions to the <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The service collection to which MailKit services will be added.</param>
    /// <param name="configuration">The configuration.</param>
    /// <param name="configurationSection">The configuration section name for MailKit options.</param>
    /// <returns>The modified <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection TryAddMailKitExtensions(this IServiceCollection services,
        IConfiguration configuration,
        string configurationSection = nameof(MailKitSmtpClientOptions)
        )
    {
        services.TryAddTransient<ICommunicationSender<EmailMessageModel>, MailKitProvider>();

        services.TryAddTransient<ISmtpClientFactory, SmtpClientFactory>();
        services.TryAddTransient<IMimeMessageFactory, MimeMessageFactory>();

        services.Configure<MailKitSmtpClientOptions>(options => configuration.Bind(configurationSection, options));

        return services;
    }
}