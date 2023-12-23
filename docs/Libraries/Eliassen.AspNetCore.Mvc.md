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


#### OnAuthorization(Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext)
Ensure that current authenticated user matches as least one requested right
    #####Parameters
    **context:** 


## Class: AspNetCore.Mvc.Filters.FormFileOperationFilter
Implementation of for handling file upload in Swagger UI.
### Methods


#### Apply(Microsoft.OpenApi.Models.OpenApiOperation,Swashbuckle.AspNetCore.SwaggerGen.OperationFilterContext)
Applies the file upload operation filter to modify the Swagger UI documentation.
    #####Parameters
    **operation:** The OpenApiOperation representing the Swagger operation.

    **context:** The OperationFilterContext providing information about the operation.


## Class: AspNetCore.Mvc.Filters.SearchQueryOperationFilter
Search Query Operation filter extends Swagger/OpenAPI to provide details on IQueryable{T} endpoints.

## Class: AspNetCore.Mvc.Filters.SearchQueryResultFilter
Search Query Results filter is an extension for ASP.Net Core to enable a common pattern to query data endpoints with from Controller Actions. This detects actions that return IQueryable{TModel} and intercepts the web request to complete the query based on user requested inputs.

## Class: AspNetCore.Mvc.Middleware.CultureInfoMiddleware
Custom middleware to enable detection of language/culture from HTTP request header as well as assignment for response header

## Class: AspNetCore.Mvc.Middleware.SearchQueryMiddleware
ASP.Net MVC Middlware to enable IQueryable{T} responses from Controller Actions

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


## Class: AspNetCore.Mvc.ServiceCollectionExtensions
Extension methods for configuring ASP.Net Core extensions and related services.
### Methods


#### TryAddAspNetCoreExtensions(Microsoft.Extensions.DependencyInjection.IServiceCollection,System.Boolean,System.Boolean,System.Action{Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder})
Adds IOC configurations to support all ASP.Net Core extensions provided by this library.
    #####Parameters
    **services:** The service collection to which ASP.Net Core extensions should be added.

    **requireAuthenticatedByDefault:** Indicates whether authentication is required by default.

    **requireApplicationUserId:** Indicates whether the application user ID is required.

    **authorizationPolicyBuilder:** Action to configure the authorization policy builder.

    ##### Return value
    The modified service collection.

#### AddRequireAuthenticatedUser(Microsoft.Extensions.DependencyInjection.IServiceCollection,System.Boolean,System.Action{Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder})
Adds authentication requirements to the service collection.
    #####Parameters
    **services:** The service collection to which authentication requirements should be added.

    **requireApplicationUserId:** Indicates whether the application user ID is required.

    **authorizationPolicyBuilder:** Action to configure the authorization policy builder.

    ##### Return value
    The modified service collection.

#### TryAddCommonOpenApiExtensions(Microsoft.Extensions.DependencyInjection.IServiceCollection)
Enables extensions for Swagger/OpenAPI (included in AddAspNetCoreExtensions).
    #####Parameters
    **services:** The service collection to which Swagger/OpenAPI extensions should be added.

    ##### Return value
    The modified service collection.

#### TryAddAspNetCoreSearchQuery(Microsoft.Extensions.DependencyInjection.IServiceCollection)
Enables extensions for shared Search Query extensions (included in AddAspNetCoreExtensions).
    #####Parameters
    **services:** The service collection to which Search Query extensions should be added.

    ##### Return value
    The modified service collection.

## Class: AspNetCore.Mvc.SwaggerGen.AdditionalSwaggerGenEndpointsOptions
SwaggerGen extensions to enable presenting permissions, application versions and XMLDocs

## Class: AspNetCore.Mvc.SwaggerGen.AdditionalSwaggerUIEndpointsOptions
SwaggerUI Extension to enable grouping controller/actions by assembly

## Class: AspNetCore.Mvc.SwaggerGen.AddMvcFilterOptions`1
register additional ASP.Net MVC Filters

## Class: AspNetCore.Mvc.SwaggerGen.AddOperationFilterOptions`1
Register additional IOperationFilters

## Class: AspNetCore.Mvc.SwaggerGen.AddSchemaFilterOptions`1
Register additional IOperationFilters

## Class: AspNetCore.Mvc.SwaggerGen.ApiNamespaceControllerModelConvention
SwaggerGen extension to configure controller group as the related assembly name

## Class: AspNetCore.JwtAuthentication.Authorization.UserAuthorizationHandler
Handles user authorization based on specified requirements.
### Methods


####Constructor
Initializes a new instance of the class.
    #####Parameters
    **logger:** The logger.


#### HandleRequirementAsync(Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext,Eliassen.AspNetCore.JwtAuthentication.Authorization.UserAuthorizationRequirement)
Handles the user authorization requirement asynchronously.
    #####Parameters
    **context:** The authorization context.

    **requirement:** The user authorization requirement.

    ##### Return value
    A task representing the asynchronous operation.

## Class: AspNetCore.JwtAuthentication.Authorization.UserAuthorizationRequirement
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


####Constructor
Initializes a new instance of the class.
    #####Parameters
    **requireApplicationUserId:** Specifies whether the application user ID is required for authorization.
