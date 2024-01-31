# Eliassen.Common.Extensions


## Class: Common.Extensions.IdentityExtensionBuilder
Represents a builder for configuring identity extensions. 

### Properties

#### IdentityProvider
Gets or sets the identity provider to use. Specifies the identity provider for authentication. The default value is .

## Class: Common.Extensions.IdentityProviders
Specifies different identity providers for authentication. 

### Fields

#### None
Represents no specific identity provider.
#### AzureB2C
Represents the Azure B2C identity provider.
#### Keycloak
Represents the Keycloak identity provider.

## Class: Common.Extensions.ServiceCollectionExtensions
Provides extension methods for configuring common external services in the 
 *See: T:Microsoft.Extensions.DependencyInjection.IServiceCollection*. 

### Methods


#### TryCommonExternalExtensions(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration,Eliassen.Common.Extensions.IdentityExtensionBuilder)
Tries to add common external services to the specified 
 *See: T:Microsoft.Extensions.DependencyInjection.IServiceCollection*. 


##### Parameters
* *services:* The instance.
* *configuration:* The configuration containing settings for external services.
* *builder:* Optional builder for configuring identity extensions. Default is null.




##### Return value
The updated instance.

