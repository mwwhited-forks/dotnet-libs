using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Security.Claims;

namespace Eliassen.MessageQueueing.Services;

public class MessageContextFactory : IMessageContextFactory
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ClaimsPrincipal? _user;

    public MessageContextFactory(
        IServiceProvider serviceProvider,
        ClaimsPrincipal? user
        )
    {
        _serviceProvider = serviceProvider;
        _user = user;
    }

    public virtual IMessageContext Create(
        Type channelType,
        Type messageType,
        string? originMessageId,
        string correlationId,
        string requestId,
        IConfigurationSection configuration,
        /*[CallerMemberName]*/ MethodBase? caller /* = default */,
        /*[CallerLineNumber]*/ int callerLine     /* = default */,
        /*[CallerFilePath]  */ string? callerFile /* = default */
        )
    {
        var context = ActivatorUtilities.CreateInstance<MessageContext>(_serviceProvider);

        var userName = (_user ?? ClaimsPrincipal.Current)?.Identity?.Name ?? Environment.UserName;

        context.OriginMessageId = originMessageId;
        context.CorrelationId = correlationId;
        context.RequestId = requestId;

        context.SentBy = userName;
        context.SentFrom = Environment.MachineName;
        context.SentAt = DateTimeOffset.UtcNow;

        context.ChannelType = channelType.AssemblyQualifiedName;
        context.MessageType = messageType.AssemblyQualifiedName;

        context["X-CallerName"] = caller?.DeclaringType?.AssemblyQualifiedName ?? "UNKNOWN CALLER";
        context["X-CallerMemberName"] = caller?.ToString() ?? "UNKNOWN CALLER";
        context["X-CallerLineNumber"] = callerLine;
        context["X-CallerFilePath"] = callerFile ?? "UNKNOWN CALLER PATH";

        context.Config = configuration;

        return context;
    }
}
