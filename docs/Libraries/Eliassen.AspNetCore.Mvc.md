﻿# Eliassen.AspNetCore.Mvc


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