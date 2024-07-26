Here is the documentation for the provided source code files, including class diagrams generated using PlantUML:

**Eliassen.MessageQueueing.Hosting.csproj**

This is a .NET Core project file for Eliassen.MessageQueueing.Hosting. It references various libraries and projects, including Eliassen.MessageQueueing#abstractions, Eliassen.System#abstractions, and Eliassen.System.

**MessageReceiverHost.cs**

This class is a hosted service responsible for starting and stopping message receivers based on the configured providers.

**Class Diagram:**

```plantuml
@startuml
class MessageReceiverHost {
  - logger: ILogger
  - factory: IMessageReceiverProviderFactory
  - tasks: List<Task>
  - tokenSource: CancellationTokenSource
  - disposed: Boolean

  + StartAsync(CancellationToken cancellationToken)
  + StopAsync(CancellationToken cancellationToken)
  + Dispose()
  + Dispose(Boolean disposing)
}

class ILogger {
  + LogInformation(String message)
  + LogError(String message, Exception ex)
  + LogDebug(String message, String debugMessage)
}

class IMessageReceiverProviderFactory {
  + Create()
}

class IMessageReceiverProvider {
  + RunAsync(CancellationToken cancellationToken)
}

MessageReceiverHost -impl-> IMessageReceiverProviderFactory
ILogger -impl-> MessageReceiverHost
IMessageReceiverProvider -impl-> MessageReceiverHost
IMessageReceiverProvider -impl-> IMessageReceiverProviderFactory
@enduml
```

**Description:**

The `MessageReceiverHost` class has properties for the logger, factory, tasks, token source, and disposed state. It has methods for starting, stopping, and disposing of the message receiver host.

The `Dispose` method disposes of unmanaged resources and sets the `disposed` state to true. The `StartAsync` method starts the message receiver host by creating and starting tasks for each provider. The `StopAsync` method stops the message receiver host by canceling the token source and waiting for all tasks to complete. The `Dispose(Boolean disposing)` method disposes of managed and unmanaged resources.

**Readme.MessageQueueing.Hosting.md**

This is a Markdown file providing documentation for the Eliassen.MessageQueueing.Hosting project. It includes information on the `MessageReceiverHost` class and its methods.

**ServiceCollectionExtensions.cs**

This class provides extension methods for configuring IoC (Inversion of Control) services to support all Message Queueing within this library.

**Class Diagram:**

```plantuml
@startuml
class ServiceCollectionExtensions {
  + TryAddMessageQueueingHosting(IServiceCollection services)
}

class IServiceCollection {
  + AddHostedService(Type type)
}

ServiceCollectionExtensions -impl-> IServiceCollection
(IServiceCollection) -impl-> MessageReceiverHost
@enduml
```

**Description:**

The `ServiceCollectionExtensions` class has a single method, `TryAddMessageQueueingHosting`, which adds IOC configurations to support all Message Queueing within this library. This method returns the `IServiceCollection` instance.

The `IServiceCollection` class represents the service collection, which is used to configure and build a service provider instance. The `AddHostedService` method adds a hosted service to the service collection.