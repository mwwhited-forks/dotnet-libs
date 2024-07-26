**Eliassen.Communications.Abstractions Documentation**

**Summary**

The Eliassen Communications libraries provide an abstraction layer for asynchronously sending messages over a dedicated channel, such as Email and SMS.

**Namespace**

Eliassen.Communications

**Classes**

### ICommunicationSender<T>

#### Description

The `ICommunicationSender<T>` interface is used to interact with various channel providers, such as email and SMS.

#### Methods

* `SendAsync(T message)`: Sends a message asynchronously over the specified channel.

### EmailMessageModel

#### Description

Represents an email message model.

### SmsMessageModel

#### Description

Represents an SMS message model.

**Class Diagram**

```plantuml
@startuml
class ICommunicationSender<T> {
  - SendAsync(T message): Task<string>
}

class EmailMessageModel

class SmsMessageModel

ICommunicationSender<T] --|> EmailMessageModel
ICommunicationSender<T] --|> SmsMessageModel

@enduml
```

**Example**

To use the `ICommunicationSender<T>` interface, include it in your service class and inject an instance of the desired channel provider.

```csharp
public class ExampleClass : IExampleService
{
    private readonly ICommunicationSender<EmailMessageModel> _email;

    public ExampleClass(ICommunicationSender<EmailMessageModel> email)
    {
        _email = email;
    }

    public async Task<string> SendAsync(EmailMessageModel message)
    {
        return await _email.SendAsync(message);
    }
}
```

**Dependencies**

* Microsoft.Extensions.Configuration.Abstractions (version 8.0.0)

**Used Assemblies**

* Eliassen.Communications
* Eliassen.Communications.Tests

**Authors**

* [Your Name]

**License**

* [Your License]

**Readme**

The `Readme.md` file is located in the root directory of the project and provides a general overview of the Eliassen Communications libraries.