Here is the documentation for the `Eliassen.Communications.MessageQueueing` project, including class diagrams in Plant UML.

**Project Overview**

The `Eliassen.Communications.MessageQueueing` project is a module that facilitates message queueing for communication-related tasks. It provides a mechanism for handling and sending email messages asynchronously.

**Class Diagram**

Here is the class diagram for the `Eliassen.Communications.MessageQueueing` project:
```
@startuml
class EmailMessageHandler {
  -logger: ILogger
  -email: ICommunicationSender<EmailMessageModel>
  -message: EmailMessageModel
  -context: IMessageContext

  +HandleAsync(EmailMessageModel, IMessageContext)
  +HandleAsync(object, IMessageContext)
}

class ICommunicationSender<T> {
  +SendAsync(T)
}

class ILogger {
  +LogInformation(string)
  +LogWarning(string)
  +LogError(string)
}

class IMessageContext {
  +CorrelationId: string
}

class EmailMessageModel {
  -Subject: string
  -FromAddress: string
  -ReferenceId: string
}

class IMessageTypeHandler<TIn, TOut> {
  +HandleAsync(TIn, IMessageContext)
}

Eliassen_Communications_MessageQueueing -> ICommunicationSender<EmailMessageModel>
EmailMessageHandler -> ILogger
EmailMessageHandler -> ICommunicationSender<EmailMessageModel>
EmailMessageModel -> IMessageContext
```
**Classes**

### EmailMessageHandler

The `EmailMessageHandler` class represents a message handler tailored for handling and sending email messages asynchronously.

**Methods**

* `HandleAsync(EmailMessageModel, IMessageContext)`: Handles the specified email message asynchronously.
* `HandleAsync(object, IMessageContext)`: Handles the specified message asynchronously.

### ICommunicationSender<T>

The `ICommunicationSender<T>` interface represents a communication sender for sending objects of type `T`.

**Methods**

* `SendAsync(T)`: Sends the specified object asynchronously.

### ILogger

The `ILogger` interface represents a logger for logging messages to the console or a file.

**Methods**

* `LogInformation(string)`: Logs an information message.
* `LogWarning(string)`: Logs a warning message.
* `LogError(string)`: Logs an error message.

### IMessageContext

The `IMessageContext` interface represents a message context for storing information about the currently processed message.

**Properties**

* `CorrelationId: string`: The correlation ID for the message.

### EmailMessageModel

The `EmailMessageModel` class represents an email message model.

**Properties**

* `Subject: string`: The subject of the email message.
* `FromAddress: string`: The from address of the email message.
* `ReferenceId: string`: The reference ID of the email message.

**Service Collection Extensions**

The `ServiceCollectionExtensions` class provides extension methods for configuring communication queue services within the application.

**Methods**

* `TryAddCommunicationQueueServices(IServiceCollection)`: Tries to add communication queue services to the specified service collection.

**Readme**

The `Readme` file provides an overview of the `Eliassen.Communications.MessageQueueing` project, including its components and functionality.

I hope this documentation helps! Let me know if you have any further requests.