# Eliassen.AspNetCore.JwtAuthentication


## Class: AspNetCore.JwtAuthentication.ServiceCollectionExtensions
Extension methods for configuring JWT Bearer authentication and SwaggerGen services in .
### Methods


#### TryAddJwtBearerServices(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration,System.String,System.String,System.String)
Tries to add JWT Bearer authentication and SwaggerGen services to the specified .
    #####Parameters
    **services:** The to add the services to.

    **configuration:** The configuration.

    **defaultScheme:** The default authentication scheme.

    **jwtBearerConfigurationSection:** The configuration section for JwtBearer options.

    **oAuth2SwaggerConfigurationSection:** The configuration section for OAuth2Swagger options.

    ##### Return value
    The modified .

#### TryAddJwtBearerAuthentication(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration,System.String,System.String)
Tries to add JWT Bearer authentication services to the specified .
    #####Parameters
    **services:** The to add the services to.

    **configuration:** The configuration.

    **defaultScheme:** The default authentication scheme.

    **configurationSection:** The configuration section for JwtBearer options.

    ##### Return value
    The modified .

#### TryAddJwtBearerSwaggerGen(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration,System.String)
Tries to add SwaggerGen services for OAuth2 to the specified .
    #####Parameters
    **services:** The to add the services to.

    **configuration:** The configuration.

    **configurationSection:** The configuration section for OAuth2Swagger options.

    ##### Return value
    The modified .

## Class: AspNetCore.SwaggerGen.B2C.OAuth2SwaggerOptions
Represents the options for configuring OAuth2 in Swagger.
### Properties

#### UserReadApiClaim
Gets or sets the claim that Swagger will use to determine the authenticated user's API access.
#### AuthorizationUrl
Gets or sets the URL for the authorization endpoint.
#### TokenUrl
Gets or sets the URL for the token endpoint.