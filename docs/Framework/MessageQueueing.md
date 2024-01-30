# Eliassen - Message Queueing

## Summary

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
