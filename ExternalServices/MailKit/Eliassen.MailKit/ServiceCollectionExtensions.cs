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
    /// <param name="smtpConfigurationSection">The configuration section name for MailKit SMTP options.</param>
    /// <param name="imapConfigurationSection">The configuration section name for MailKit IMAP options.</param>
    /// <returns>The modified <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection TryAddMailKitExtensions(this IServiceCollection services,
        IConfiguration configuration,
        string smtpConfigurationSection = nameof(MailKitSmtpClientOptions),
        string imapConfigurationSection = nameof(MailKitImapClientOptions)
        )
    {
        services.TryAddTransient<ICommunicationSender<EmailMessageModel>, MailKitProvider>();

        services.TryAddTransient<IMimeMessageFactory, MimeMessageFactory>();

        services.TryAddTransient<ISmtpClientFactory, SmtpClientFactory>();
        services.Configure<MailKitSmtpClientOptions>(options => configuration.Bind(smtpConfigurationSection, options));

        services.TryAddTransient<IImapClientFactory, ImapClientFactory>();
        services.Configure<MailKitImapClientOptions>(options => configuration.Bind(imapConfigurationSection, options));

        return services;
    }
}