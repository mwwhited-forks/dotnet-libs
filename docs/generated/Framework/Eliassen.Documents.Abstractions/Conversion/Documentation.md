Here is the documentation for the source code file, including a class diagram in PlantUML:

**IDocumentConversionHandler.cs**

**Class Diagram in PlantUML:**
```plantuml
@startuml
interface IDocumentConversionHandler
  - left --+> IDocumentConversion
  - string[] Sources { get; }
  - boolean SupportedSource(string contentType)
  - string[] Destinations { get; }
  - boolean SupportedDestination(string contentType)
end interface
@enduml
```

**Documentation:**

The `IDocumentConversionHandler` interface represents a handler for document conversion. It inherits from the `IDocumentConversion` interface, which is not shown in this diagram.

The `IDocumentConversionHandler` interface has four properties and methods:

* `Sources`: Gets the supported source content types for document conversion. This is an array of strings, where each string represents a content type.
* `SupportedSource(string contentType)`: Determines whether the specified content type is supported as a source for document conversion. This method returns a boolean value indicating whether the content type is supported.
* `Destinations`: Gets the supported destination content types for document conversion. This is an array of strings, where each string represents a content type.
* `SupportedDestination(string contentType)`: Determines whether the specified content type is supported as a destination for document conversion. This method returns a boolean value indicating whether the content type is supported.

**Class Description:**

The `IDocumentConversionHandler` interface defines the contract for a handler that can convert documents between different formats. The handler must provide information about the supported source and destination content types, as well as methods to determine whether a specific content type is supported for conversion. Implementations of this interface must provide concrete implementations for these methods and properties.