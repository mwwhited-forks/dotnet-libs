# Eliassen - Message Queueing

See [back](MajorFunctionality.md)

## Summary

Messages and business event supported is provided by the `Eliassen.MessageQueueing` libraries.  

Handlers are provided in process though an Hosting Engine extension.

### Current Implementations

* In Process `ConcurrentQueue` - Built in
* Azure Storage Queues - Requires `Eliassen.Azure.StorageAccount`

### 

* should have support for impersonate the originating ClaimsPrincipal

## Related Notes

* [MessageQueueing](../Libraries/Eliassen.MessageQueueing.md)
  * [MessageQueueing.Abstractions](../Libraries/Eliassen.MessageQueueing.Abstractions.md)
  * [MessageQueueing.Hosting](../Libraries/Eliassen.MessageQueueing.Hosting.md)
* [Azure.StorageAccount](../Libraries/Eliassen.Azure.StorageAccount.md)
* [RabbitMQ](../Libraries/Eliassen.RabbitMQ.md)

## Structure

```plantuml
top to bottom direction 

package Abstractions {
    interface IMessageQueueSender {
    }
    interface IMessageQueueHandler {
        HandleAsync(object, IMessageContext) : Task
    }
    class MessageQueueAttribute {
        + SimpleName : string 
    }

    interface IMessageContext {
        ...
    }
    interface IMessageHandlerProvider {
        + HandleAsync(IQueueMessage message, string messageId) : Task
        + Config : IConfigurationSection
    }
    interface IMessageReceiverProvider {
        + RunAsync(CancellationToken) : Task
    }
    interface IMessageReceiverProviderFactory {
        + Create() : IMessageReceiverProvider[]
    }
    interface IMessageSenderProvider {
        + SendAsync(object, IMessageContext) : Task<string?>
    }
    interface IMessageSenderProviderFactory {
        + Sender(Type, Type) : IMessageSenderProvider
    }
    interface IQueueMessage {
        ...
    }
}

package Implementation {
    class GenericHandler 
    class GenericProvider
}

package Hosting  {
    class MessageReceiverHost {
        - factory IMessageReceiverProviderFactory
        + StartAsync() : Task
        + StopAsync() : Task
    }
}

IMessageQueueHandler --> IMessageContext : uses
IMessageSenderProvider --> IMessageContext : uses
IMessageHandlerProvider o-- IMessageQueueHandler : uses

IMessageQueueSender  --* IMessageSenderProviderFactory : uses
IMessageHandlerProvider  --* IQueueMessage : uses
IMessageSenderProviderFactory  --> IMessageSenderProvider : uses
IMessageReceiverProviderFactory  --o IMessageReceiverProvider : uses
IMessageReceiverProviderFactory  --o IMessageQueueHandler : uses

IMessageSenderProvider --* IMessageHandlerProvider : uses

IMessageSenderProvider ^-- GenericProvider : implements 
IMessageReceiverProvider ^-- GenericProvider : implements 

IMessageQueueHandler ^-- GenericHandler : implements

MessageReceiverHost --* IMessageReceiverProviderFactory : uses

```

---

See [back](MajorFunctionality.md)
