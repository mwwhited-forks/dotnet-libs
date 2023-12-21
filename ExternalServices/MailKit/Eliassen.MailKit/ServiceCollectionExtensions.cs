using Eliassen.Communications.Models;
using Eliassen.Communications.Services;
using Eliassen.MailKit.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Eliassen.MailKit;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection TryAddMailKitExtensions(this IServiceCollection services,
        IConfiguration configuration,
        string configurationSection = nameof(MailKitSmtpClientOptions)
        )
    {
        services.TryAddTransient<IMessageSender<EmailMessageModel>, MailKitProvider>();

        services.TryAddTransient<ISmtpClientFactory, SmtpClientFactory>();
        services.TryAddTransient<IMimeMessageFactory, MimeMessageFactory>();

        services.Configure<MailKitSmtpClientOptions>(options => configuration.Bind(configurationSection, options));

        return services;
    }
}