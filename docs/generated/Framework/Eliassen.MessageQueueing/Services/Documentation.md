**Documentation**

**InProcessMessageProvider Class**

The `InProcessMessageProvider` class is a message provider that can send and receive messages in-process. It implements both `IMessageSenderProvider` and `IMessageReceiverProvider` interfaces.

**Constructors**

* `InProcessMessageProvider(ILogger<InProcessMessageProvider> logger)`: Initializes a new instance of the `InProcessMessageProvider` class with the specified logger.

**Properties**

* `MessageProviderKey`: Gets the key associated with the in-process message provider.

**Methods**

* `SendAsync(object message, IMessageContext context)`: Sends a message asynchronously using the specified context.
* `SetHandlerProvider(IMessageHandlerProvider handlerProvider)`: Sets the message handler provider.
* `RunAsync(CancellationToken cancellationToken)`: Runs the in-process message provider asynchronously.

**MessageContext Class**

The `MessageContext` class represents the context associated with a message, including metadata and headers.

**Constructors**

* `MessageContext()`: Initializes a new instance of the `MessageContext` class with default values.

**Properties**

* `OriginMessageId`: Gets or sets the origin message ID.
* `CorrelationId`: Gets or sets the correlation ID.
* `RequestId`: Gets or sets the request ID.
* `SentId`: Gets or sets the sent ID.
* `ChannelType`: Gets or sets the type of the message channel.
* `MessageType`: Gets or sets the type of the message.
* `Headers`: Gets the headers associated with the message context.
* `Config`: Gets the configuration section associated with the message context.

**MessageContextFactory Class**

The `MessageContextFactory` class is a factory for creating instances of `IMessageContext`.

**Constructors**

* `MessageContextFactory(IServiceProvider serviceProvider, ClaimsPrincipal? user)`: Initializes a new instance of the `MessageContextFactory` class with the specified service provider and user.

**Methods**

* `Create(Type channelType, IQueueMessage message, IConfigurationSection configuration)`: Creates a new instance of `IMessageContext` with the specified parameters.

**MessageHandlerProvider Class**

The `MessageHandlerProvider` class coordinates multiple `IMessageQueueHandler` instances to handle queue messages.

**Constructors**

* `MessageHandlerProvider(IJsonSerializer serializer, IMessageContextFactory context, ILogger<MessageHandlerProvider> logger)`: Initializes a new instance of the `MessageHandlerProvider` class with the specified serializer, context factory, and logger.

**Properties**

* `Config`: Gets the configuration section associated with the message handler.

**Methods**

* `HandleAsync(IQueueMessage message, string correlationId)`: Handles the specified queue message by invoking each registered message handler.

**MessagePropertyResolver Class**

The `MessagePropertyResolver` class is used to resolve message properties, such as IDs and provider keys.

**Constructors**

* `MessagePropertyResolver(IConfiguration configuration)`: Initializes a new instance of the `MessagePropertyResolver` class with the specified configuration.

**Methods**

* `Configuration(Type channelType, Type messageType)`: Retrieves the configuration section associated with the message channel and type.
* `Provider(Type channelType, Type messageType)`: Retrieves the provider key associated with the message channel and type.

**MessageReceiverProviderFactory Class**

The `MessageReceiverProviderFactory` class creates instances of `IMessageReceiverProvider` based on configured message handlers.

**Constructors**

* `MessageReceiverProviderFactory(IEnumerable<IMessageQueueHandler> handlers, IMessagePropertyResolver resolver, IServiceProvider serviceProvider, ILogger<MessageReceiverProviderFactory> logger)`: Initializes a new instance of the `MessageReceiverProviderFactory` class with the specified handlers, resolver, service provider, and logger.

**Methods**

* `Create()`: Creates instances of `IMessageReceiverProvider` based on configured message handlers.

**MessageSenderProviderFactory Class**

The `MessageSenderProviderFactory` class creates instances of `IMessageSenderProvider` based on channel and message types.

**Constructors**

* `MessageSenderProviderFactory(IServiceProvider serviceProvider, IMessagePropertyResolver resolver)`: Initializes a new instance of the `MessageSenderProviderFactory` class with the specified service provider and resolver.

**Methods**

* `Sender(Type channelType, Type messageType)`: Creates an instance of `IMessageSenderProvider` based on the specified channel and message types.

**Class Diagram**

```plantuml
@startuml
class IMetaService {
  + IMessageContext Create(Type channelType, IQueueMessage message, IConfigurationSection configuration)
  + IMessageHandlerProvider SetHandlerProvider(IMessageHandlerProvider handlerProvider)
}

class MessageContextFactory {
  + IMetaService Create(Type channelType, IQueueMessage message, IConfigurationSection configuration)
}

class IMessageHandlerProvider {
  + void HandleAsync(IQueueMessage message, string correlationId)
}

class MessageHandlerProvider {
  + IMessageHandlerProvider SetHandlers(IEnumerable<IMessageQueueHandler> handlers)
  + IMessageHandlerProvider SetChannelType(Type channelType)
  + IMessageHandlerProvider SetConfig(IConfigurationSection config)
}

class MessagePropertyResolver {
  + IConfigurationSection Configuration(Type channel