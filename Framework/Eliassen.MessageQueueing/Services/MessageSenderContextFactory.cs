using Eliassen.System.Accessors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.Security.Claims;

namespace Eliassen.MessageQueueing.Services;

public class MessageSenderContextFactory : IMessageSenderContextFactory
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IAccessor<ClaimsPrincipal> _user;

    public MessageSenderContextFactory(
        IServiceProvider serviceProvider,
        IAccessor<ClaimsPrincipal> user,
        IConfiguration config
        )
    {
        _serviceProvider = serviceProvider;
        _user = user;
    }

    public virtual IMessageSenderContext Create(Type targetQueueType, Type messageType, string messageId, IConfigurationSection configuration)
    {
        var context = ActivatorUtilities.CreateInstance<MessageSenderContext>(_serviceProvider);

        context.MessageId = messageId;

        var stackFrame = new StackFrame(2);

        var callerMethod = stackFrame.GetMethod();
        var lineNumber = stackFrame.GetFileLineNumber();
        var callerPath = stackFrame.GetFileName();

        context.Headers.Add("X-TargetType", targetQueueType);
        context.Headers.Add("X-MessageType", messageType);

        context.Headers.Add("X-CallerMemberName", callerMethod?.ToString() ?? "UNKNOWN CALLER");
        context.Headers.Add("X-CallerLineNumber", lineNumber);
        context.Headers.Add("X-CallerFilePath", callerPath ?? "UNKNOWN CALLER PATH");

        context.Headers.Add("X-UserName", (_user.Value ?? ClaimsPrincipal.Current)?.Identity?.Name ?? Environment.UserName);
        context.Headers.Add("X-MachineName", Environment.MachineName);

        context.Headers.Add("X-SentAt", DateTimeOffset.UtcNow);
        context.Headers.Add("X-MessageId", messageId);
        context.Headers.Add("X-RequestId", Guid.NewGuid());

        return context;
    }
}
