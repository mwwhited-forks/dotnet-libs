Here is the documentation for the provided source code files:

**CompletionRequest.cs**

Overview:
The `CompletionRequest` class represents a completion request sent to an AI model for processing.

Class Diagram in Plant UML:

```plantuml
@startuml
class CompletionRequest {
  - Model: string?
  - Context: long[]?
  - Images: string[]?
  - Prompt: string (required)
  - System: string?
  - Template: string?
}
@enduml
```

**CompletionResponse.cs**

Overview:
The `CompletionResponse` class represents a completion response received from an AI model after processing a completion request.

Class Diagram in Plant UML:

```plantuml
@startuml
class CompletionResponse {
  - Context: long[] (required)
  - Response: string (required)
}
@enduml
```

**KeyValuePairModel.cs**

Overview:
The `KeyValuePairModel` class is a base class that represents a key-value pair model.

Class Diagram in Plant UML:

```plantuml
@startuml
class KeyValuePairModel {
  - Key: string (required)
  - Value: string (required)
}
@enduml
```

Here is the combined class diagram for all three classes:

```plantuml
@startuml
class CompletionRequest {
  - Model: string?
  - Context: long[]?
  - Images: string[]?
  - Prompt: string (required)
  - System: string?
  - Template: string?
}

class CompletionResponse {
  - Context: long[] (required)
  - Response: string (required)
}

class KeyValuePairModel {
  - Key: string (required)
  - Value: string (required)
}

CompletionRequest --* KeyValuePairModel
CompletionResponse --* CompletionRequest
@enduml
```

Note: The `--*` notation indicates a composition relationship between classes, meaning that a `CompletionRequest` can contain multiple `KeyValuePairModel`s, and a `CompletionResponse` is a response to a `CompletionRequest`.