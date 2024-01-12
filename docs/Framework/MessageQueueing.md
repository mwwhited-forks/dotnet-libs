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
package Abstractions {
    interface IMessageQueueSender {
    }
    interface IMessageQueueHandler {
        HandleAsync(object, IMessageContext) : Task
    }
    class MessageQueueAttribute {
        + SimpleName : string 
    }

    package services {
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
        interface IMessageReceiverProviderFactory{
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
}

package Extensions {
    class EmailMessageHandler 
    class AzureStorageQueueMessageProvider
    class RabbitMQQueueMessageProvider 
    class InProcessMessageProvider
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

IMessageSenderProvider ^-- AzureStorageQueueMessageProvider : implements 
IMessageReceiverProvider ^-- AzureStorageQueueMessageProvider : implements 

IMessageSenderProvider ^-- RabbitMQQueueMessageProvider : implements 
IMessageReceiverProvider ^-- RabbitMQQueueMessageProvider : implements 

IMessageSenderProvider ^-- InProcessMessageProvider : implements 
IMessageReceiverProvider ^-- InProcessMessageProvider : implements 

IMessageQueueHandler ^-- EmailMessageHandler : implements

```