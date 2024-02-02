# Eliassen.AspNetCore.Mvc


## Class: AspNetCore.Mvc.ApplicationBuilderExtensions
This is a set of extension configurations for ASP.Net Core 

### Methods


#### UseAspNetCoreExtensionMiddleware(Microsoft.AspNetCore.Builder.IApplicationBuilder)
Add custom middleware to ASP.Net to support these extensions 
 *See: T:Eliassen.AspNetCore.Mvc.Middleware.CultureInfoMiddleware* *See: T:Eliassen.AspNetCore.Mvc.Middleware.SearchQueryMiddleware*

##### Parameters
* *builder:* 




##### Return value




## Class: AspNetCore.Mvc.AspNetCoreExtensionBuilder
Represents a builder for configuring ASP.NET Core extensions. 

### Properties

#### RequireAuthenticatedByDefault
Gets or sets a value indicating whether authentication is required by default. Set to true to require authentication by default; otherwise, set to false. The default value is .
#### RequireApplicationUserId
Gets or sets a value indicating whether an application user ID is required. Set to true to require an application user ID; otherwise, set to false. The default value is .
#### AuthorizationPolicyBuilder
Gets or sets the delegate for configuring an . Set to a delegate that configures an . The default value is null.

## Class: AspNetCore.Mvc.Authorization.UserAuthorizationHandler
Handles user authorization based on specified requirements. 

Initializes a new instance of the class.
### Methods


#### Constructor
Initializes a new instance of the class.
Handles user authorization based on specified requirements. 


##### Parameters
* *logger:* The logger.




#### HandleRequirementAsync(Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext,Eliassen.AspNetCore.Mvc.Authorization.UserAuthorizationRequirement)
Handles the user authorization requirement asynchronously. 


##### Parameters
* *context:* The authorization context.
* *requirement:* The user authorization requirement.




##### Return value
A task representing the asynchronous operation.



## Class: AspNetCore.Mvc.Authorization.UserAuthorizationRequirement
Represents an authorization requirement for user-specific authorization. 

### Fields

#### RequireApplicationUserIdDefault
The default value indicating whether the application user ID is required for authorization.
#### RequireAuthenticatedByDefault
The default value indicating whether authentication is required for authorization.
### Properties

#### RequireApplicationUserId
Gets a value indicating whether the application user ID is required for authorization.
### Methods


#### Constructor
Initializes a new instance of the 
 *See: T:Eliassen.AspNetCore.Mvc.Authorization.UserAuthorizationRequirement*class. 


##### Parameters
* *requireApplicationUserId:* Specifies whether the application user ID is required for authorization.




## Class: AspNetCore.Mvc.Filters.ApplicationPermissionsApiFilter
operation filter to extend swagger to include application rights 

### Methods


#### Apply(Microsoft.OpenApi.Models.OpenApiOperation,Swashbuckle.AspNetCore.SwaggerGen.OperationFilterContext)
Applies the operation filter to include application rights in Swagger documentation. 


##### Parameters
* *operation:* The OpenApiOperation to be modified.
* *context:* The OperationFilterContext providing information about the operation.




## Class: AspNetCore.Mvc.Filters.FormFileOperationFilter
Implementation of 
 *See: T:Swashbuckle.AspNetCore.SwaggerGen.IOperationFilter*for handling file upload in Swagger UI. 

### Methods


#### Apply(Microsoft.OpenApi.Models.OpenApiOperation,Swashbuckle.AspNetCore.SwaggerGen.OperationFilterContext)
Applies the file upload operation filter to modify the Swagger UI documentation. 


##### Parameters
* *operation:* The OpenApiOperation representing the Swagger operation.
* *context:* The OperationFilterContext providing information about the operation.




## Class: AspNetCore.Mvc.Filters.SearchQueryOperationFilter
Search Query Operation filter extends Swagger/OpenAPI to provide details on IQueryable{T} endpoints. 

### Methods


#### Constructor
Search Query Operation filter extends Swagger/OpenAPI to provide details on IQueryable{T} endpoints. 


#### Apply(Microsoft.OpenApi.Models.OpenApiOperation,Swashbuckle.AspNetCore.SwaggerGen.OperationFilterContext)
Applies the Search Query Operation filter to Swagger/OpenAPI. 


##### Parameters
* *operation:* The OpenApiOperation to apply the filter to.
* *context:* The OperationFilterContext containing information about the operation.




## Class: AspNetCore.Mvc.Filters.SearchQueryResultFilter
Search Query Results filter is an extension for ASP.Net Core to enable a common pattern to query data endpoints with from Controller Actions. This detects actions that return IQueryable{TModel} and intercepts the web request to complete the query based on user requested inputs. 
 *See: T:Eliassen.System.Linq.Search.SearchQuery`1* *See: T:Eliassen.System.Linq.Search.IQueryBuilder`1* *See: T:System.Linq.IQueryable`1* *See: T:Eliassen.System.ResponseModel.IQueryResult`1* *See: T:Eliassen.System.ResponseModel.IPagedQueryResult`1*
### Methods


#### Constructor
Search Query Results filter is an extension for ASP.Net Core to enable a common pattern to query data endpoints with from Controller Actions. This detects actions that return IQueryable{TModel} and intercepts the web request to complete the query based on user requested inputs. 
 *See: T:Eliassen.System.Linq.Search.SearchQuery`1* *See: T:Eliassen.System.Linq.Search.IQueryBuilder`1* *See: T:System.Linq.IQueryable`1* *See: T:Eliassen.System.ResponseModel.IQueryResult`1* *See: T:Eliassen.System.ResponseModel.IPagedQueryResult`1*

#### OnResultExecuted(Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext)
Called after the action result executes. 


##### Parameters
* *context:* The .




#### OnResultExecuting(Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext)
Called before the action result executes. 


##### Parameters
* *context:* The .




## Class: AspNetCore.Mvc.Middleware.CultureInfoMiddleware
Custom middleware to enable detection of language/culture from HTTP request header as well as assignment for response header 

### Methods


#### Constructor
Custom middleware to enable detection of language/culture from HTTP request header as well as assignment for response header 


##### Parameters
* *next:* The next middleware in the pipeline.




#### Invoke(Microsoft.AspNetCore.Http.HttpContext,Microsoft.Extensions.Logging.ILogger{Eliassen.AspNetCore.Mvc.Middleware.CultureInfoMiddleware},Eliassen.System.Accessors.IAccessor{System.Globalization.CultureInfo})
Invokes the middleware to process the request and response. 


##### Parameters
* *context:* The HTTP context.
* *logger:* The logger.
* *cultureInfo:* The accessor for .




##### Return value
A task representing the asynchronous operation.



## Class: AspNetCore.Mvc.Middleware.SearchQueryMiddleware
ASP.Net MVC Middlware to enable IQueryable{T} responses from Controller Actions 

### Methods


#### Constructor
ASP.Net MVC Middlware to enable IQueryable{T} responses from Controller Actions 


##### Parameters
* *next:* The next middleware in the pipeline.
* *log:* The logger for logging information.
* *searchQuery:* The accessor for the search query.




#### InvokeAsync(Microsoft.AspNetCore.Http.HttpContext)
Invokes the middleware to handle the request. 


##### Parameters
* *context:* The HTTP context.




##### Return value
A task representing the asynchronous operation.



## Class: AspNetCore.Mvc.OpenApi.ApiPermissionsExtension
Declare permissions required for application endpoint 

### Properties

#### AllowAnonymous
End point allows unauthenticated requests
#### Rights
end point requires at least one of these permissions
### Methods


#### Constructor
Declare permissions required for application endpoint 


##### Parameters
* *allowAnonymous:* End point allows unauthenticated requests
* *rights:* end point requires at least one of these permissions




#### Write(Microsoft.OpenApi.Writers.IOpenApiWriter,Microsoft.OpenApi.OpenApiSpecVersion)
generate a property to provide the required permissions 


##### Parameters
* *writer:* 
* *specVersion:* 




## Class: AspNetCore.Mvc.ServiceCollectionExtensions
Extension methods for configuring ASP.Net Core extensions and related services. 

### Methods


#### TryAddAspNetCoreExtensions(Microsoft.Extensions.DependencyInjection.IServiceCollection,Eliassen.AspNetCore.Mvc.AspNetCoreExtensionBuilder)
Adds IOC configurations to support all ASP.Net Core extensions provided by this library. 


##### Parameters
* *services:* The service collection to which ASP.Net Core extensions should be added.
* *builder:* Indicates whether authentication is required by default.




##### Return value
The modified service collection.



#### AddRequireAuthenticatedUser(Microsoft.Extensions.DependencyInjection.IServiceCollection,System.Boolean,System.Action{Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder})
Adds authentication requirements to the service collection. 


##### Parameters
* *services:* The service collection to which authentication requirements should be added.
* *requireApplicationUserId:* Indicates whether the application user ID is required.
* *authorizationPolicyBuilder:* Action to configure the authorization policy builder.




##### Return value
The modified service collection.



#### TryAddCommonOpenApiExtensions(Microsoft.Extensions.DependencyInjection.IServiceCollection)
Enables extensions for Swagger/OpenAPI (included in AddAspNetCoreExtensions). 


##### Parameters
* *services:* The service collection to which Swagger/OpenAPI extensions should be added.




##### Return value
The modified service collection.



#### TryAddAspNetCoreSearchQuery(Microsoft.Extensions.DependencyInjection.IServiceCollection)
Enables extensions for shared Search Query extensions (included in AddAspNetCoreExtensions). 


##### Parameters
* *services:* The service collection to which Search Query extensions should be added.




##### Return value
The modified service collection.



## Class: AspNetCore.Mvc.SwaggerGen.AdditionalSwaggerGenEndpointsOptions
SwaggerGen extensions to enable presenting permissions, application versions and XMLDocs 

### Methods


#### Constructor
SwaggerGen extensions to enable presenting permissions, application versions and XMLDocs 


#### Configure(Swashbuckle.AspNetCore.SwaggerGen.SwaggerGenOptions)
Configures SwaggerGen options with additional features such as presenting permissions, application versions, and XMLDocs. 


##### Parameters
* *options:* The SwaggerGen options to be configured.




## Class: AspNetCore.Mvc.SwaggerGen.AdditionalSwaggerUIEndpointsOptions
SwaggerUI Extension to enable grouping controller/actions by assembly 

### Methods


#### Constructor
SwaggerUI Extension to enable grouping controller/actions by assembly 


#### Configure(Swashbuckle.AspNetCore.SwaggerUI.SwaggerUIOptions)
Configures SwaggerUI options to enable grouping of controller/actions by assembly. 


##### Parameters
* *options:* The SwaggerUI options to be configured.




## Class: AspNetCore.Mvc.SwaggerGen.AddMvcFilterOptions`1
register additional ASP.Net MVC Filters 

### Methods


#### Configure(Microsoft.AspNetCore.Mvc.MvcOptions)
Configures MVC options to add the specified filter. 


##### Parameters
* *options:* The MVC options to be configured.




## Class: AspNetCore.Mvc.SwaggerGen.AddOperationFilterOptions`1
Register additional IOperationFilters 

### Methods


#### Configure(Swashbuckle.AspNetCore.SwaggerGen.SwaggerGenOptions)
Configures SwaggerGen options to add the specified operation filter. 


##### Parameters
* *options:* The SwaggerGen options to be configured.




## Class: AspNetCore.Mvc.SwaggerGen.AddSchemaFilterOptions`1
Register additional IOperationFilters 

### Methods


#### Configure(Swashbuckle.AspNetCore.SwaggerGen.SwaggerGenOptions)
Register additional IOperationFilters 


##### Parameters
* *options:* 




## Class: AspNetCore.Mvc.SwaggerGen.ApiNamespaceControllerModelConvention
SwaggerGen extension to configure controller group as the related assembly name 

### Methods


#### Apply(Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel)
Applies the convention to the specified controller model. 


##### Parameters
* *controller:* The controller model to apply the convention to.


