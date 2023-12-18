using Eliassen.MessageQueueing.Services;
using System;
using System.Threading.Tasks;

namespace Eliassen.MessageQueueing.Tests.TestItems;

public class TestExceptionMessageSenderProvider : IMessageSenderProvider
{
    public async Task<string?> SendAsync(object message, IMessageSenderContext context)
    {
        throw new ApplicationException();
    }
}
