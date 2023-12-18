using Eliassen.System.Accessors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace Eliassen.MessageQueueing.Services;

public class MessageSenderContextFactory : IMessageSenderContextFactory
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ClaimsPrincipal? _user;

    public MessageSenderContextFactory(
        IServiceProvider serviceProvider,
        ClaimsPrincipal? user
        )
    {
        _serviceProvider = serviceProvider;
        _user = user;
    }

    public virtual IMessageSenderContext Create(
        Type targetQueueType,
        Type messageType,
        string messageId,
        IConfigurationSection configuration,
        /*[CallerMemberName]*/ MethodBase? caller /* = default */,
        /*[CallerLineNumber]*/ int callerLine     /* = default */,
        /*[CallerFilePath]  */ string? callerFile /* = default */
        )
    {
        var context = ActivatorUtilities.CreateInstance<MessageSenderContext>(_serviceProvider);

        context.MessageId = messageId;
        context.Config = configuration;

        context.Headers.Add("X-TargetType", targetQueueType.AssemblyQualifiedName);
        context.Headers.Add("X-MessageType", messageType.AssemblyQualifiedName);

        context.Headers.Add("X-CallerName", caller?.DeclaringType?.AssemblyQualifiedName ?? "UNKNOWN CALLER");
        context.Headers.Add("X-CallerMemberName", caller?.ToString() ?? "UNKNOWN CALLER");
        context.Headers.Add("X-CallerLineNumber", callerLine);
        context.Headers.Add("X-CallerFilePath", callerFile ?? "UNKNOWN CALLER PATH");

        context.Headers.Add("X-UserName", (_user ?? ClaimsPrincipal.Current)?.Identity?.Name ?? Environment.UserName);
        context.Headers.Add("X-MachineName", Environment.MachineName);

        context.Headers.Add("X-SentAt", DateTimeOffset.UtcNow);
        context.Headers.Add("X-MessageId", messageId);
        context.Headers.Add("X-RequestId", Guid.NewGuid());

        return context;
    }
}
