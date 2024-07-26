Here is the documentation for each of the source code files, including class diagrams in PlantUML:

**AttachmentReferenceModel.cs**

This class represents a model for referencing attachments.

[PlantUML]:
```
@startuml
class AttachmentReferenceModel {
  - ContainerName: string
  - DocumentKey: string
}

@enduml
```

**EmailMessageModel.cs**

This class represents an email message model.

[PlantUML]:
```
@startuml
class EmailMessageModel {
  - ReferenceId: string
  - FromAddress: string
  - ToAddresses: List<string>
  - CcAddresses: List<string>
  - BccAddresses: List<string>
  - Subject: string
  - TextContent: string
  - HtmlContent: string
  - Headers: Dictionary<string, string>
  - Attachments: List<AttachmentReferenceModel>
}

@enduml
```

**ReceivedEmailMessageModel.cs**

This class represents inbound email messages.

[PlantUML]:
```
@startuml
class ReceivedEmailMessageModel extends EmailMessageModel {
  - Server: string
  - Path: string
}

@enduml
```

**SmsMessageModel.cs**

This class represents a model for SMS messages.

[PlantUML]:
```
@startuml
class SmsMessageModel {
  - From: string
  - To: string
  - RequestId: Guid
  - Body: string
  - Headers: Dictionary<string, object>
}

@enduml
```

Here is the overall summary for the documentation:

These classes represent different types of communication models in the Eliassen Communications system. The `AttachmentReferenceModel` class represents a model for referencing attachments, while the `EmailMessageModel` class represents an email message model. The `ReceivedEmailMessageModel` class extends the `EmailMessageModel` and adds additional properties related to inbound email messages. The `SmsMessageModel` class represents a model for SMS messages.

Note: The PlantUML diagrams are formatted using Markdown syntax, with the `@startuml` and `@enduml` commands defining the boundaries of the UML diagram. The classes and their properties are defined using the `class` keyword, with properties listed inside curly braces.