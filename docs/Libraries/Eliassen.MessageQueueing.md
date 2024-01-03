﻿# Eliassen.MessageQueueing


## Class: MessageQueueing.MessageSender`1
Represents a message sender for a specific communication channel ().The type representing the communication channel.
Initializes a new instance of the class.
### Methods


#### Constructor
Initializes a new instance of the class.
Represents a message sender for a specific communication channel ().

##### Parameters
* *context:* The message context factory.
* *provider:* The message sender provider factory.
* *resolver:* The message property resolver.
* *logger:* The logger.




#### SendAsync(System.Object,System.String)
Sends a message asynchronously to the specified communication channel.

##### Parameters
* *message:* The message to be sent.
* *correlationId:* The correlation ID associated with the message (optional).




##### Return value
The ID of the sent message.



## Class: MessageQueueing.ServiceCollectionExtensions
Provides extension methods for configuring IoC (Inversion of Control) services to support all Message Queueing within this library.
### Methods


#### TryAddMessageQueueingServices(Microsoft.Extensions.DependencyInjection.IServiceCollection)
Add IOC configurations to support all Message Queueing within this library.

##### Parameters
* *services:* 




##### Return value




## Class: MessageQueueing.Services.MessageContext
Represents the context associated with a message, including metadata and headers.
### Properties

#### OriginMessageId
Gets or sets the origin message ID.
#### CorrelationId
Gets or sets the correlation ID.
#### RequestId
Gets or sets the request ID.
#### SentId
Gets or sets the sent ID.
#### ChannelType
Gets or sets the channel type.
#### MessageType
Gets or sets the message type.
#### SentAt
Gets or sets the timestamp when the message was sent.
#### SentBy
Gets or sets the entity that sent the message.
#### SentFrom
Gets or sets the origin from where the message was sent.
#### Item(System.String)
Gets or sets the value associated with the specified key in the headers. The key of the value to get or set.The value associated with the specified key.
#### Headers
Gets the headers associated with the message context.
#### Config
Gets or sets the configuration section associated with the message context.
### Methods


#### Constructor
Initializes a new instance of the class.
Factory for creating instances of .

##### Parameters
* *serviceProvider:* The service provider for creating instances.
* *user:* The claims principal representing the user associated with the message context.




#### 
Creates a new instance of with the specified parameters.

##### Parameters
* *channelType:* The type of the message channel.
* *messageType:* The type of the message.
* *originMessageId:* The origin message ID.
* *correlationId:* The correlation ID.
* *requestId:* The request ID.
* *configuration:* The configuration section.
* *caller:* The calling method.
* *callerLine:* The line number in the source file where the call originated.
* *callerFile:* The full path of the source file where the call originated.




##### Return value
A new instance of .



#### 
Creates a new instance of with the specified parameters from a queue message.

##### Parameters
* *channelType:* The type of the message channel.
* *message:* The queue message.
* *configuration:* The configuration section.




##### Return value
A new instance of .



## Class: MessageQueueing.Services.MessageContextFactory
Factory for creating instances of .
Initializes a new instance of the class.
### Methods


#### Constructor
Initializes a new instance of the class.
Factory for creating instances of .

##### Parameters
* *serviceProvider:* The service provider for creating instances.
* *user:* The claims principal representing the user associated with the message context.




#### Create(System.Type,System.Type,System.String,System.String,System.String,Microsoft.Extensions.Configuration.IConfigurationSection,System.Reflection.MethodBase,System.Int32,System.String)
Creates a new instance of with the specified parameters.

##### Parameters
* *channelType:* The type of the message channel.
* *messageType:* The type of the message.
* *originMessageId:* The origin message ID.
* *correlationId:* The correlation ID.
* *requestId:* The request ID.
* *configuration:* The configuration section.
* *caller:* The calling method.
* *callerLine:* The line number in the source file where the call originated.
* *callerFile:* The full path of the source file where the call originated.




##### Return value
A new instance of .



#### Create(System.Type,Eliassen.MessageQueueing.Services.IQueueMessage,Microsoft.Extensions.Configuration.IConfigurationSection)
Creates a new instance of with the specified parameters from a queue message.

##### Parameters
* *channelType:* The type of the message channel.
* *message:* The queue message.
* *configuration:* The configuration section.




##### Return value
A new instance of .



## Class: MessageQueueing.Services.MessageHandlerProvider
Provides handling of queue messages by coordinating multiple instances.
Initializes a new instance of the class.
### Properties

#### Config
Gets the configuration section associated with the message handler.
### Methods


#### Constructor
Initializes a new instance of the class.
Provides handling of queue messages by coordinating multiple instances.

##### Parameters
* *serializer:* The JSON serializer.
* *context:* The factory for creating instances of .
* *logger:* The logger for logging messages.




#### SetHandlers(System.Collections.Generic.IEnumerable{Eliassen.MessageQueueing.IMessageQueueHandler})
Sets the collection of instances that will handle the messages.

##### Parameters
* *handlers:* The collection of message handlers.




##### Return value
The current instance of .



#### SetChannelType(System.Type)
Sets the type of the message channel associated with the handler.

##### Parameters
* *channelType:* The type of the message channel.




##### Return value
The current instance of .



#### SetConfig(Microsoft.Extensions.Configuration.IConfigurationSection)
Sets the configuration section associated with the message handler.

##### Parameters
* *config:* The configuration section.




##### Return value
The current instance of .



#### HandleAsync(Eliassen.MessageQueueing.Services.IQueueMessage,System.String)
Handles the specified queue message by invoking each registered message handler.

##### Parameters
* *message:* The queue message to handle.
* *messageId:* The ID of the message.




##### Return value
A task representing the asynchronous operation.



## Class: MessageQueueing.Services.MessagePropertyResolver
Utility class for resolving properties related to message queue handling.
Initializes a new instance of the class with the specified configuration.
### Methods


#### Constructor
Initializes a new instance of the class with the specified configuration.
Utility class for resolving properties related to message queue handling.

##### Parameters
* *configuration:* The configuration used for resolving message queue properties.




#### RootConfiguration(System.Type,System.Type)
Gets the root configuration section along with simple target and message names.

##### Parameters
* *channelType:* The type of the message queue channel.
* *messageType:* The type of the message.




##### Return value
A tuple containing the root configuration section, simple target name, simple message name, and the configuration path.



#### ConfigurationSafe(System.Type,System.Type)
Retrieves the safe configuration section along with simple target and message names.

##### Parameters
* *channelType:* The type of the message queue channel.
* *messageType:* The type of the message.




##### Return value
A tuple containing the safe configuration section, simple target name, simple message name, and the configuration path.



#### Configuration(System.Type,System.Type)
Retrieves the configuration section along with simple target and message names.

##### Parameters
* *channelType:* The type of the message queue channel.
* *messageType:* The type of the message.




##### Return value
The configuration section.



#### MessageId(System.Type,System.Type,System.String)
Resolves the message ID, generating a new one if not provided.

##### Parameters
* *channelType:* The type of the message queue channel.
* *messageType:* The type of the message.
* *messageId:* The provided message ID.




##### Return value
The resolved message ID.



#### GenerateId(System.Type,System.Type)
Generates a new message ID.

##### Parameters
* *channelType:* The type of the message queue channel.
* *messageType:* The type of the message.




##### Return value
The generated message ID.



#### ProviderSafe(System.Type,System.Type)
Retrieves the safe provider information along with simple target and message names.

##### Parameters
* *channelType:* The type of the message queue channel.
* *messageType:* The type of the message.




##### Return value
A tuple containing the provider key, simple target name, simple message name, and the configuration path.



#### Provider(System.Type,System.Type)
Retrieves the provider key along with simple target and message names.

##### Parameters
* *channelType:* The type of the message queue channel.
* *messageType:* The type of the message.




##### Return value
The provider key.



## Class: MessageQueueing.Services.MessageReceiverProviderFactory
Factory for creating instances of based on configured message handlers.
Initializes a new instance of the class.
### Methods


#### Constructor
Initializes a new instance of the class.
Factory for creating instances of based on configured message handlers.

##### Parameters
* *handlers:* The collection of message queue handlers.
* *resolver:* The message property resolver.
* *serviceProvider:* The service provider.
* *logger:* The logger.




#### Create
Creates instances of based on configured message handlers.

##### Return value
An enumerable collection of .



## Class: MessageQueueing.Services.MessageSenderProviderFactory
Factory for creating instances of based on channel and message types.
Initializes a new instance of the class.
### Methods


#### Constructor
Initializes a new instance of the class.
Factory for creating instances of based on channel and message types.

##### Parameters
* *serviceProvider:* The service provider used for resolving services.
* *resolver:* The message property resolver.




#### Sender(System.Type,System.Type)
Creates an instance of based on channel and message types.

##### Parameters
* *channelType:* The type of the communication channel.
* *messageType:* The type of the message.




##### Return value
An instance of .



## Class: Azure.StorageAccount.MessageQueueing.InProcessMessageProvider
Represents an in-process message provider that implements both and .
Initializes a new instance of the class.
### Fields

#### MessageProviderKey
Gets the key associated with the in-process message provider.
### Methods


#### Constructor
Initializes a new instance of the class.
Represents an in-process message provider that implements both and .

##### Parameters
* *logger:* The logger.




#### SendAsync(System.Object,Eliassen.MessageQueueing.Services.IMessageContext)
Sends a message asynchronously.

##### Parameters
* *message:* The message to send.
* *context:* The message context.




##### Return value
A task representing the asynchronous operation and returning the correlation ID.



#### SetHandlerProvider(Eliassen.MessageQueueing.Services.IMessageHandlerProvider)
Sets the message handler provider.

##### Parameters
* *handlerProvider:* The message handler provider.




##### Return value
The current instance of the message receiver provider.



#### RunAsync(System.Threading.CancellationToken)
Runs the in-process message provider asynchronously.

##### Parameters
* *cancellationToken:* The cancellation token.




##### Return value
A task representing the asynchronous operation.
