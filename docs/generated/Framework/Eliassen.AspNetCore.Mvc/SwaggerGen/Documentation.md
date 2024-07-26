Here is the documentation for each of the source code files, along with class diagrams in PlantUML:

**AdditionalSwaggerGenEndpointsOptions.cs**

This class provides additional configuration options for SwaggerGen. It allows you to:

* Present permissions and application versions
* Include XML documentation comments
* Configure SwaggerGen to use a custom schema ID resolver

Class Diagram:
```plantuml
@startuml
class AdditionalSwaggerGenEndpointsOptions {
  - IActionDescriptorCollectionProvider provider
  - ILogger<AdditionalSwaggerGenEndpointsOptions> log
  - IEnumerable<IVersionProvider> versions
  ~Configure(SwaggerGenOptions options)
}

class SwaggerGenOptions {
  - OpenApiInfo OpenApiInfo
  - OpenApiDocument OpenApiDocument
  - bool CustomSchemaIds
}

class OpenApiInfo {
  - string Title
  - string Version
  - string Description
}

@enduml
```
**AdditionalSwaggerUIEndpointsOptions.cs**

This class provides additional configuration options for SwaggerUI. It allows you to:

* Group controller actions by assembly

Class Diagram:
```plantuml
@startuml
class AdditionalSwaggerUIEndpointsOptions {
  - IActionDescriptorCollectionProvider provider
  ~Configure(SwaggerUIOptions options)
}

class SwaggerUIOptions {
  - string SwaggerEndpoint
  - bool ShowExtensions
}

class SwaggerEndpoint {
  - string Path
  - string Description
}
@enduml
```
**AddMvcFilterOptions.cs**

This class allows you to add additional ASP.NET MVC filters. It is used to register filters with the MVC options.

Class Diagram:
```plantuml
@startuml
class AddMvcFilterOptions<TFilter> {
  - TFilter
  ~Configure(MvcOptions options)
}

class MvcOptions {
  - IFilterMetadata Filters
}

class IFilterMetadata {
  --filter metadata attributes
}

@enduml
```
**AddOperationFilterOptions.cs**

This class allows you to add additional operation filters. It is used to register filters with the SwaggerGen options.

Class Diagram:
```plantuml
@startuml
class AddOperationFilterOptions<T> {
  - T
  ~Configure(SwaggerGenOptions options)
}

class SwaggerGenOptions {
  - IOperationFilter OperationFilters
}

class IOperationFilter {
  -filter metadata attributes
}

@enduml
```
**AddSchemaFilterOptions.cs**

This class allows you to add additional schema filters. It is used to register filters with the SwaggerGen options.

Class Diagram:
```plantuml
@startuml
class AddSchemaFilterOptions<T> {
  - T
  ~Configure(SwaggerGenOptions options)
}

class SwaggerGenOptions {
  - ISchemaFilter SchemaFilters
}

class ISchemaFilter {
  -filter metadata attributes
}

@enduml
```
**ApiNamespaceControllerModelConvention.cs**

This class provides a convention for SwaggerGen to use the assembly name as the group name for controller actions.

Class Diagram:
```plantuml
@startuml
class ApiNamespaceControllerModelConvention {
  ~Apply(ControllerModel controller)
}

class ControllerModel {
  - string ApiExplorer.GroupName
}

class IControllerModelConvention {
  ~Apply(ControllerModel controller)
}

@enduml
```
**HealthChecksDocumentFilter.cs**

This class provides a document filter for health checks in the OpenAPI document.

Class Diagram:
```plantuml
@startuml
class HealthChecksDocumentFilter {
  ~Apply(OpenApiDocument openApiDocument, DocumentFilterContext context)
}

class OpenApiDocument {
  - OpenApiPathItem Paths
}

class DocumentFilterContext {
  - OpenApiDocument OpenApiDocument
  - OpenApiPathItem CurrentPathItem
}

class OpenApiPathItem {
  - OpenApiOperation Operations
}

class OpenApiOperation {
  - OpenApiTag Tags
  - OpenApiResponse Responses
  - string HttpMethod
  - string Path
}

class OpenApiTag {
  - string Name
}

class OpenApiResponse {
  - OpenApiMediaType Response
}

class OpenApiMediaType {
  - OpenApiSchema Schema
}

class OpenApiSchema {
  - Type Type
  - Dictionary<string, OpenApiSchema> AdditionalProperties
}
@enduml
```
**HealthCheckSwaggerGenEndpointOptions.cs**

This class provides configuration options for SwaggerGen related to health check endpoints.

Class Diagram:
```plantuml
@startuml
class HealthCheckSwaggerGenEndpointOptions {
  ~Configure(SwaggerGenOptions options)
}

class SwaggerGenOptions {
  - IDocumentFilter DocumentFilters
}

class IDocumentFilter {
  ~Apply(OpenApiDocument openApiDocument, DocumentFilterContext context)
}

class OpenApiDocument {
  - OpenApiPathItem Paths
}

class DocumentFilterContext {
  - OpenApiDocument OpenApiDocument
  - OpenApiPathItem CurrentPathItem
}
@enduml
```
Please note that these class diagrams only represent the relationships between the classes and do not include the implementation details of the methods.