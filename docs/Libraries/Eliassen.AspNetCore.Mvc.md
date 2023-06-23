# Eliassen.AspNetCore.Mvc


## Class: AspNetCore.Mvc.ApplicationBuilderExtensions
This is a set of extension configurations for ASP.Net Core
### Methods


#### UseAspNetCoreExtensionMiddleware(Microsoft.AspNetCore.Builder.IApplicationBuilder)
Add custom middleware to ASP.Net to support these extensions
    #####Parameters
    **builder:** 

    ##### Return value
    

## Class: AspNetCore.Mvc.Filters.ApplicationPermissionsApiFilter
operation filter to extend swagger to include application rights
### Methods


#### Apply(Microsoft.OpenApi.Models.OpenApiOperation,Swashbuckle.AspNetCore.SwaggerGen.OperationFilterContext)

## Class: AspNetCore.Mvc.Filters.ApplicationRightAttribute
At least one of these declared rights must be assigned to the user to access this point
### Properties

#### Rights
list of required rights
### Methods


####Constructor
Declare required rights for endpoint
    #####Parameters
    **rights:** 


## Class: AspNetCore.Mvc.Filters.ApplicationRightRequirementFilter
Authorization filter to compared application rights for user to rights required by endpoint
### Methods


####Constructor

#### OnAuthorization(Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext)
Ensure that current authenticated user matches as least one requested right
    #####Parameters
    **context:** 


## Class: AspNetCore.Mvc.Filters.FormFileOperationFilter
### Methods


#### Apply(Microsoft.OpenApi.Models.OpenApiOperation,Swashbuckle.AspNetCore.SwaggerGen.OperationFilterContext)

## Class: AspNetCore.Mvc.Filters.SearchQueryOperationFilter
Search Query Operation filter extends Swagger/OpenAPI to provide details on IQueryable{T} endpoints.
### Methods


####Constructor

#### Apply(Microsoft.OpenApi.Models.OpenApiOperation,Swashbuckle.AspNetCore.SwaggerGen.OperationFilterContext)

## Class: AspNetCore.Mvc.Filters.SearchQueryResultFilter
Search Query Results filter is an extension for ASP.Net Core to enable a common pattern to query data endpoints with from Controller Actions. This detects actions that return IQueryable{TModel} and intercepts the web request to complete the query based on user requested inputs.
### Methods


####Constructor

#### OnResultExecuted(Microsoft.AspNetCore.Mvc.Filters.ResultExecutedContext)

#### OnResultExecuting(Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext)

## Class: AspNetCore.Mvc.Middleware.CultureInfoMiddleware
Custom middleware to enable detection of language/culture from HTTP request header as well as assignment for response header
### Methods


####Constructor

#### Invoke(Microsoft.AspNetCore.Http.HttpContext,Microsoft.Extensions.Logging.ILogger{Eliassen.AspNetCore.Mvc.Middleware.CultureInfoMiddleware},Eliassen.System.Accessors.IAccessor{System.Globalization.CultureInfo})

## Class: AspNetCore.Mvc.Middleware.SearchQueryMiddleware
ASP.Net MVC Middlware to enable IQueryable{T} responses from Controller Actions
### Methods


####Constructor

#### InvokeAsync(Microsoft.AspNetCore.Http.HttpContext)

## Class: AspNetCore.Mvc.OpenApi.ApiPermissionsExtension
Declare permissions required for application endpoint
### Properties

#### AllowAnonymous
End point allows unauthenticated requests
#### Rights
end point requires at least one of these permissions
### Methods


####Constructor

    #####Parameters
    **allowAnonymous:** End point allows unauthenticated requests

    **rights:** end point requires at least one of these permissions


#### Write(Microsoft.OpenApi.Writers.IOpenApiWriter,Microsoft.OpenApi.OpenApiSpecVersion)

## Class: AspNetCore.Mvc.ServiceCollectionExtensions
### Methods


#### AddAspNetCoreExtensions(Microsoft.Extensions.DependencyInjection.IServiceCollection)
Add IOC configurations to support all ASP.Net Core extensions provided by this library.
    #####Parameters
    **services:** 

    ##### Return value
    

#### TryAddCommonOpenApiExtensions(Microsoft.Extensions.DependencyInjection.IServiceCollection)
Enable extensions for Swagger/OpenAPI (included in AddAspNetCoreExtensions)
    #####Parameters
    **services:** 

    ##### Return value
    

#### TryAddAspNetCoreSearchQuery(Microsoft.Extensions.DependencyInjection.IServiceCollection)
Enable extensions for shared Search Query extensions (included in AddAspNetCoreExtensions)
    #####Parameters
    **services:** 

    ##### Return value
    

## Class: AspNetCore.Mvc.SwaggerGen.AdditionalSwaggerGenEndpointsOptions
SwaggerGen extensions to enable presenting permissions, application versions and XMLDocs
### Methods


####Constructor

#### Configure(Swashbuckle.AspNetCore.SwaggerGen.SwaggerGenOptions)

## Class: AspNetCore.Mvc.SwaggerGen.AdditionalSwaggerUIEndpointsOptions
SwaggerUI Extension to enable grouping controller/actions by assembly
### Methods


####Constructor

#### Configure(Swashbuckle.AspNetCore.SwaggerUI.SwaggerUIOptions)

## Class: AspNetCore.Mvc.SwaggerGen.AddMvcFilterOptions`1
register additional ASP.Net MVC Filters
### Methods


#### Configure(Microsoft.AspNetCore.Mvc.MvcOptions)

## Class: AspNetCore.Mvc.SwaggerGen.AddOperationFilterOptions`1
Register additional IOperationFilters
### Methods


#### Configure(Swashbuckle.AspNetCore.SwaggerGen.SwaggerGenOptions)

## Class: AspNetCore.Mvc.SwaggerGen.AddSchemaFilterOptions`1
Register additional IOperationFilters
### Methods


#### Configure(Swashbuckle.AspNetCore.SwaggerGen.SwaggerGenOptions)

## Class: AspNetCore.Mvc.SwaggerGen.ApiNamespaceControllerModelConvention
SwaggerGen extension to configure controller group as the related assembly name
### Methods


#### Apply(Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel)