Here is the documentation for the given source code files, including class diagrams in PlantUML.

**IMessageContext.cs**

This interface represents the context of a message being processed in a message queue.

```plantuml
@startuml
interface IMessageContext {
  + string? OriginMessageId { get; }
  + string? CorrelationId { get; set; }
  + string? RequestId { get; }
  + string? SentId { get; }
  + string? ChannelType { get; }
  + string? MessageType { get; }
  + DateTimeOffset? SentAt { get; }
  + string? SentBy { get; }
  + string? SentFrom { get; }
  + object? this[string key] { get; set; }
  + Dictionary<string, object?> Headers { get; }
  + IConfigurationSection Config { get; }
}
@enduml
```

**IMessageContextFactory.cs**

This interface provides a factory for creating instances of `IMessageContext`.

```plantuml
@startuml
interface IMessageContextFactory {
  + IMessageContext Create(Type channelType, Type messageType, string? originMessageId, string correlationId, string requestId, IConfigurationSection configuration, MethodBase? caller = default, int callerLine = default, string? callerFile = default);
  + IMessageContext Create(Type channelType, IQueueMessage message, IConfigurationSection configuration);
}
@enduml
```

**IMessageHandlerProvider.cs**

This interface provides a mechanism for handling queue messages.

```plantuml
@startuml
interface IMessageHandlerProvider {
  + Task HandleAsync(IQueueMessage message, string messageId);
  + IConfigurationSection Config { get; }
}
@enduml
```

**IMessageHandlerProviderWrapped.cs**

This interface provides internal extensions for mechanism for handling queue messages.

```plantuml
@startuml
interface IMessageHandlerProviderWrapped {
  + IMessageHandlerProviderWrapped SetHandlers(IEnumerable<IMessageQueueHandler> handlers);
  + IMessageHandlerProviderWrapped SetChannelType(Type channelType);
  + IMessageHandlerProviderWrapped SetConfig(IConfigurationSection config);
}
@enduml
```

**IMessagePropertyResolver.cs**

This interface resolves properties related to message handling, such as provider, message ID, and configuration.

```plantuml
@startuml
interface IMessagePropertyResolver {
  + (string? providerKey, string simpleTargetName, string simpleMessageName, string? configPath) ProviderSafe(Type channelType, Type messageType);
  + string Provider(Type channelType, Type messageType);
  + string MessageId(Type channelType, Type messageType, string? messageId);
  + string GenerateId(Type channelType, Type messageType);
  + (IConfigurationSection? configurationSection, string simpleTargetName, string simpleMessageName, string? configPath) ConfigurationSafe(Type channelType, Type messageType);
  + IConfigurationSection Configuration(Type channelType, Type messageType);
}
@enduml
```

**IMessageReceiverProvider.cs**

This interface provides functionality for receiving messages from a message queue.

```plantuml
@startuml
interface IMessageReceiverProvider {
  + IMessageReceiverProvider SetHandlerProvider(IMessageHandlerProvider handlerProvider);
  + Task RunAsync(CancellationToken cancellationToken = default);
}
@enduml
```

**IMessageReceiverProviderFactory.cs**

This interface provides a factory for creating instances of `IMessageReceiverProvider`.

```plantuml
@startuml
interface IMessageReceiverProviderFactory {
  + IEnumerable<IMessageReceiverProvider> Create();
}
@enduml
```

**IMessageSenderProvider.cs**

This interface represents a provider for sending messages to a message queue.

```plantuml
@startuml
interface IMessageSenderProvider {
  + Task<string?> SendAsync(object message, IMessageContext context);
}
@enduml
```

**IMessageSenderProviderFactory.cs**

This interface provides a factory for creating instances of `IMessageSenderProvider`.

```plantuml
@startuml
interface IMessageSenderProviderFactory {
  + IMessageSenderProvider Sender(Type channelType, Type messageType);
}
@enduml
```

**IQueueMessage.cs**

This interface represents a message within a message queue.

```plantuml
@startuml
interface IQueueMessage {
  + string ContentType { get; }
  + string? CorrelationId { get; }
  + object Payload { get; }
  + string? PayloadType { get; }
  + Dictionary<string, object?> Properties { get; }
}
@enduml
```

**WrappedQueueMessage.cs**

This class represents a wrapped queue message.

```plantuml
@startuml
class WrappedQueueMessage implements IQueueMessage {
  - string _contentType
  - string _correlationId
  - object _payload
  - string _payloadType
  - Dictionary<string, object?> _properties
  
  + WrappedQueueMessage {ContentType = _contentType, CorrelationId = _correlationId, Payload = _payload, PayloadType = _payloadType, Properties = _properties}
}
@enduml
```

Please note that this documentation is generated based on the