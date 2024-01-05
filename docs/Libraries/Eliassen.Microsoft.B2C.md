# Eliassen.Microsoft.B2C


## Class: Microsoft.B2C.Identity.ManageGraphUser
Implementation of 
 *See: T:Eliassen.Microsoft.B2C.Identity.IManageGraphUser*and 
 *See: T:Eliassen.Microsoft.B2C.Identity.IIdentityManager*for managing users in Microsoft Graph. 

Initializes a new instance of the class.
### Methods


#### Constructor
Initializes a new instance of the class.
Implementation of 
 *See: T:Eliassen.Microsoft.B2C.Identity.IManageGraphUser*and 
 *See: T:Eliassen.Microsoft.B2C.Identity.IIdentityManager*for managing users in Microsoft Graph. 


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



## Class: Microsoft.B2C.Identity.UserManagementProvider
Represents a provider for user management operations. 

Initializes a new instance of the class.
### Methods


#### Constructor
Initializes a new instance of the class.
Represents a provider for user management operations. 


##### Parameters
* *user:* The user manager for managing graph users.




#### CreateAccountAsync(Eliassen.Microsoft.B2C.Identity.UserCreateModel)
Creates a new user account asynchronously. 


##### Parameters
* *model:* The model containing user information for account creation.




##### Return value
A task representing the asynchronous operation. The result is a model containing the created user's information.



## Class: Microsoft.B2C.ServiceCollectionEx
Extension methods for adding Microsoft B2C services to the service collection. 

### Methods


#### AddMicrosoftB2CServices(Microsoft.Extensions.DependencyInjection.IServiceCollection)
Adds Microsoft B2C services to the service collection. 


##### Parameters
* *services:* The service collection to which Microsoft B2C services should be added.




##### Return value
The modified service collection.

