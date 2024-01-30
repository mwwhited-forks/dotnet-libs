# Eliassen.Microsoft.B2C


## Class: Microsoft.B2C.Identity.ManageGraphUser
Implementation of 
 *See: T:Eliassen.Identity.IManageGraphUser*and 
 *See: T:Eliassen.Identity.IIdentityManager*for managing users in Microsoft Graph. 

Initializes a new instance of the class.
### Methods


#### Constructor
Initializes a new instance of the class.
Implementation of 
 *See: T:Eliassen.Identity.IManageGraphUser*and 
 *See: T:Eliassen.Identity.IIdentityManager*for managing users in Microsoft Graph. 


##### Parameters
* *log:* The logger.
* *config:* The configuration.




#### GetAuthProvider
Gets the authentication provider for Microsoft Graph. 


##### Return value
The authentication provider.



#### GetGraphUsersByEmail(System.String)
Retrieves a list of user identity models based on the provided email address. 


##### Parameters
* *email:* The email address to query users by.




##### Return value
A list of user identity models matching the specified email address, or null if no matches are found.



#### CreateIdentityUserAsync(System.String,System.String,System.String)
Creates a new identity user asynchronously with the specified email, first name, and last name. 


##### Parameters
* *email:* The email address for the new user.
* *firstName:* The first name for the new user.
* *lastName:* The last name for the new user.




##### Return value
A tuple containing the object ID and password of the created user, or null if the user already exists.



#### CreateGraphUserAsync(System.String,System.String,System.String)
Creates a new user asynchronously with the specified email, first name, and last name in Microsoft Graph. 


##### Parameters
* *email:* The email address for the new user.
* *firstName:* The first name for the new user.
* *lastName:* The last name for the new user.




##### Return value
A tuple containing the object ID and password of the created user, or null if the user already exists.



#### RemoveIdentityUserAsync(System.String)
Removes an identity user asynchronously based on the specified object ID. 


##### Parameters
* *objectId:* The object ID of the user to be removed.




##### Return value
True if the user is successfully removed, false otherwise.



#### RemoveGraphUserAsync(System.String)
Removes a user asynchronously based on the specified object ID in Microsoft Graph. 


##### Parameters
* *userId:* The object ID of the user to be removed.




##### Return value
True if the user is successfully removed, false otherwise.



## Class: Microsoft.B2C.Identity.MicrosoftIdentityOptions
Contains keys related to Azure Active Directory B2C configuration. 

### Properties

#### ClientID
Represents the key for the Azure AD B2C client ID configuration.
#### Issuer
Represents the key for the Azure AD B2C issuer configuration.
#### ClientSecret
Represents the key for the Azure AD B2C client secret configuration.
#### Tenant
Represents the key for the Azure AD B2C tenant configuration.

## Class: Microsoft.B2C.ServiceCollectionExtensions
Extension methods for adding Microsoft B2C services to the service collection. 

### Methods


#### TryAddMicrosoftB2CServices(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration,System.String)
Adds Microsoft B2C services to the service collection. 


##### Parameters
* *services:* The service collection to which Microsoft B2C services should be added.




##### Return value
The modified service collection.

