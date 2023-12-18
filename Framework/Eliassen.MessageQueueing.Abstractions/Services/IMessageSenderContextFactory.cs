using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Eliassen.MessageQueueing.Services;

public interface IMessageSenderContextFactory
{
    IMessageSenderContext Create(
        Type targetQueueType, 
        Type messageType,
        string messageId,
        IConfigurationSection configuration,
        /*[CallerMemberName]*/ MethodBase? caller     /* = default */,
        /*[CallerLineNumber]*/ int callerLine     /* = default */,
        /*[CallerFilePath]  */ string? callerFile /* = default */
        );
}
