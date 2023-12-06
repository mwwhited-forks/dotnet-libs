using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Eliassen.MessageQueueing.Services;

public class MessageSenderContextFactory : IMessageSenderContextFactory
{
    private readonly IServiceProvider _serviceProvider;

    public MessageSenderContextFactory(
        IServiceProvider serviceProvider
        )
    {
        _serviceProvider = serviceProvider;
    }

    public virtual IMessageSenderContext Create(Type targetQueueType, Type messageType, string messageId)
    {
        var context = ActivatorUtilities.CreateInstance<MessageSenderContext>(_serviceProvider);

        context.MessageId = messageId;

        var stackFrame = new StackFrame(2);

        context.Headers.Add("X-TargetType", targetQueueType);
        context.Headers.Add("X-MessageType", messageType);

        context.Headers.Add("X-CallerMemberName", caller ?? "UNKNOWN CALLER");
        context.Headers.Add("X-CallerLineNumber", lineNumber);
        context.Headers.Add("X-CallerFilePath", callerPath ?? "UNKNOWN CALLER PATH");



        //            { "X-CallerMemberName", caller ?? "UNKNOWN CALLER"},
        //            { "X-CallerLineNumber", lineNumber},
        //            { "X-CallerFilePath", callerPath ?? "UNKNOWN CALLER PATH"},

        //            { "X-UserName",  _user.Value?.Username ?? Environment.UserName},
        //            { "X-MachineName", Environment.MachineName},

        //            { "X-SentAt",  _date.Now()},
        //            { "X-MessageId", messageId},


        return context;
    }
}
