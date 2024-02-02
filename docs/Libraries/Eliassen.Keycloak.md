# Eliassen.Keycloak


## Class: Keycloak.Identity.KeycloakIdentityOptions
Represents the options for configuring Keycloak identity. 


## Class: Keycloak.ServiceCollectionExtensions
Provides extension methods for configuring services related to Keycloak in the 
 *See: T:Microsoft.Extensions.DependencyInjection.IServiceCollection*. 

### Methods


#### TryAddKeycloakServices(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration,System.String)
Tries to add Keycloak-related services to the specified 
 *See: T:Microsoft.Extensions.DependencyInjection.IServiceCollection*. 


##### Parameters
* *services:* The instance.
* *configuration:* The configuration containing Keycloak-related settings.
* *keycloakIdentityConfigurationSection:* The configuration section name for Keycloak identity options. Default is "KeycloakIdentityOptions".




##### Return value
The updated instance.

