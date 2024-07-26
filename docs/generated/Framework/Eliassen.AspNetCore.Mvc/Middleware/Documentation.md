Here is the documentation for the source code files with class diagrams in Plant UML:

**CorrelationInfoMiddleware.cs**

Class Diagram:
```dot
@startuml
class CorrelationInfoMiddleware {
  - _next: RequestDelegate
  - logger: ILogger<CorrelationInfoMiddleware>
  - correlationAccessor: IAccessor<CorrelationInfo>
}

CorrelationInfoMiddleware -> RequestDelegate
CorrelationInfoMiddleware -> ILogger<CorrelationInfoMiddleware>
CorrelationInfoMiddleware -> IAccessor<CorrelationInfo>
@enduml
```

Summary:

The `CorrelationInfoMiddleware` class is a middleware for handling correlation information in HTTP requests and responses. It takes three parameters: `_next`, `logger`, and `correlationAccessor`.

Methodology:

*   The `Invoke` method is called to process the HTTP context.
*   It sets the correlation ID and request ID in the `correlationAccessor` object.
*   It logs a message indicating the correlation ID and request ID.
*   The `OnStarting` event is triggered to add the correlation ID and request ID to the response headers.
*   It calls the `_next` delegate to continue processing the request.

**CultureInfoMiddleware.cs**

Class Diagram:
```dot
@startuml
class CultureInfoMiddleware {
  - next: RequestDelegate
  - logger: ILogger<CultureInfoMiddleware>
  - cultureInfoAccessor: IAccessor<CultureInfo>
}

CultureInfoMiddleware -> RequestDelegate
CultureInfoMiddleware -> ILogger<CultureInfoMiddleware>
CultureInfoMiddleware -> IAccessor<CultureInfo>
@enduml
```

Summary:

The `CultureInfoMiddleware` class is a custom middleware to detect the language/culture from the HTTP request header and assign it to the response header.

Methodology:

*   The `Invoke` method is called to process the HTTP context.
*   It detects the language/culture from the `Accept-Language` header.
*   It sets the culture to the value from the header or to the default culture if no value is found.
*   It logs a message indicating the detected culture.
*   The `OnStarting` event is triggered to add the culture to the response headers.
*   It calls the `next` delegate to continue processing the request.

**SearchQueryMiddleware.cs**

Class Diagram:
```dot
@startuml
class SearchQueryMiddleware {
  - next: RequestDelegate
  - logger: ILogger<SearchQueryMiddleware>
  - searchQueryAccessor: IAccessor<ISearchQuery>
  - modelBuilder: ISearchModelBuilder
}

SearchQueryMiddleware -> RequestDelegate
SearchQueryMiddleware -> ILogger<SearchQueryMiddleware>
SearchQueryMiddleware -> IAccessor<ISearchQuery>
SearchQueryMiddleware -> ISearchModelBuilder
@enduml
```

Summary:

The `SearchQueryMiddleware` class is a middleware to enable IQueryable responses from controller actions.

Methodology:

*   The `InvokeAsync` method is called to handle the request.
*   It checks if the request is a search query and binds the search model if it is.
*   It logs a message indicating the search query.
*   It sets the search query to the accessor.
*   It calls the `next` delegate to continue processing the request.

Note: These diagrams are generated using the Plant UML syntax, and they represent the classes and their relationships.