Here is the documentation for the source code files, including class diagrams in PlantUML:

**ApplicationPermissionsApiFilter.cs**

This class is responsible for extending the Swagger/OpenAPI documentation to include application rights.

```
ClassDiagram
    class ApplicationPermissionsApiFilter
        extends IOperationFilter

    class OpenApiOperation
        -- operation
        -- parameters

    class OpenApiSecurityRequirement
        -- schemes

    class OpenApiSecurityScheme
        -- name
```

The `Apply` method is called for each operation in the Swagger/OpenAPI documentation. It checks if the method has been decorated with `AllowAnonymousAttribute` or `ApplicationRightAttribute`. If it does, it adds a security requirement to the operation.

**FormFileOperationFilter.cs**

This class is responsible for handling file uploads in Swagger UI.

```
ClassDiagram
    class FormFileOperationFilter
        extends IOperationFilter

    class OpenApiOperation
        -- operation
        -- parameters

    class fileUploadMime
        -- mime type

    class OpenApiSchema
        -- type
```

The `Apply` method is called for each operation in the Swagger/OpenAPI documentation. It checks if the operation has a request body that supports file uploads. If it does, it maps the `IFormFile` parameters to OpenApiSchema properties.

**SearchQueryOperationFilter.cs**

This class is responsible for extending the Swagger/OpenAPI documentation to provide details on IQueryable endpoints.

```
ClassDiagram
    class SearchQueryOperationFilter
        extends IOperationFilter

    class OpenApiOperation
        -- operation
        -- parameters

    class SearchQuery
        -- filter
        -- orderBy
        -- searchTerm

    class OpenApiSchema
        -- type
        -- properties
```

The `Apply` method is called for each operation in the Swagger/OpenAPI documentation. It checks if the method returns an IQueryable type. If it does, it updates the Swagger/OpenAPI documentation to include properties for filter, orderBy, and searchTerm.

**SearchQueryResultFilter.cs**

This class is responsible for filtering the results of an IQueryable endpoint.

```
ClassDiagram
    class SearchQueryResultFilter
        extends IResultFilter

    class ResultExecutingContext
        -- context

    class RequestAccessor
        -- query

    class SearchQuery
        -- executeBy
```

The `OnResultExecuting` method is called before the action result executes. It checks if the result is an IQueryable object. If it is, it filters the results using the SearchQuery object.

Note: The class diagrams are Simplified UML Class Diagrams, and the naming conventions are based on the plantUML syntax.