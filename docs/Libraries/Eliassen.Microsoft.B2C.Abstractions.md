# Eliassen.Microsoft.B2C.Abstractions


## Class: Microsoft.B2C.Identity.ConfigKeys
Contains constant keys for Azure-related configuration settings. 

### Fields

#### Azure.AdB2C.ClientID
Represents the key for the Azure AD B2C client ID configuration.
#### Azure.AdB2C.Issuer
Represents the key for the Azure AD B2C issuer configuration.
#### Azure.AdB2C.ClientSecret
Represents the key for the Azure AD B2C client secret configuration.
#### Azure.AdB2C.Tenant
Represents the key for the Azure AD B2C tenant configuration.
#### Azure.AdB2C.Domain
Represents the key for the Azure AD B2C domain configuration.

## Class: Microsoft.B2C.Identity.ConfigKeys.Azure
Contains keys related to Azure configuration. 

### Fields

#### AdB2C.ClientID
Represents the key for the Azure AD B2C client ID configuration.
#### AdB2C.Issuer
Represents the key for the Azure AD B2C issuer configuration.
#### AdB2C.ClientSecret
Represents the key for the Azure AD B2C client secret configuration.
#### AdB2C.Tenant
Represents the key for the Azure AD B2C tenant configuration.
#### AdB2C.Domain
Represents the key for the Azure AD B2C domain configuration.

## Class: Microsoft.B2C.Identity.ConfigKeys.Azure.AdB2C
Contains keys related to Azure Active Directory B2C configuration. 

### Fields

#### ClientID
Represents the key for the Azure AD B2C client ID configuration.
#### Issuer
Represents the key for the Azure AD B2C issuer configuration.
#### ClientSecret
Represents the key for the Azure AD B2C client secret configuration.
#### Tenant
Represents the key for the Azure AD B2C tenant configuration.
#### Domain
Represents the key for the Azure AD B2C domain configuration.

## Class: Microsoft.B2C.Identity.IIdentityManager
Represents an identity manager for managing user identities. 

### Methods


#### GetGraphUsersByEmail(System.String)
Retrieves a list of user identity models based on the specified email address. 


##### Parameters
* *emailAddress:* The email address to search for.




##### Return value
A task that represents the asynchronous operation. The task result contains the list of user identity models or null if no users are found.



#### CreateIdentityUserAsync(System.String,System.String,System.String)
Creates a new identity user asynchronously with the specified details. 


##### Parameters
* *email:* The email address of the user.
* *firstName:* The first name of the user.
* *lastName:* The last name of the user.




##### Return value
A task that represents the asynchronous operation. The task result contains the object ID and an optional password for the created user.



#### RemoveIdentityUserAsync(System.String)
Removes an identity user asynchronously based on the specified object ID. 


##### Parameters
* *objectId:* The object ID of the user to remove.




##### Return value
A task that represents the asynchronous operation. The task result is true if the user was successfully removed; otherwise, false.



## Class: Microsoft.B2C.Identity.IManageGraphUser
Represents a service for managing users in the Microsoft Graph. 

### Methods


#### CreateGraphUserAsync(System.String,System.String,System.String)
Creates a new user in the Microsoft Graph asynchronously with the specified details. 


##### Parameters
* *email:* The email address of the user.
* *firstName:* The first name of the user.
* *lastName:* The last name of the user.




##### Return value
A task that represents the asynchronous operation. The task result contains the object ID and an optional password for the created user.



#### RemoveGraphUserAsync(System.String)
Removes a user from the Microsoft Graph asynchronously based on the specified user ID. 


##### Parameters
* *userId:* The user ID of the user to remove.




##### Return value
A task that represents the asynchronous operation. The task result is true if the user was successfully removed; otherwise, false.



## Class: Microsoft.B2C.Identity.IUserManagementProvider
Provides methods for managing user accounts. 

### Methods


#### CreateAccountAsync(Eliassen.Microsoft.B2C.Identity.UserCreateModel)
Creates a user account asynchronously based on the provided model. 


##### Parameters
* *model:* The model containing user account information.




##### Return value
A task representing the asynchronous operation, containing the created user model.



## Class: Microsoft.B2C.Identity.UserCreatedModel
Represents the model for a user created as a result of account creation. 

### Properties

#### Username
Gets or sets the username associated with the created user.
#### Password
Gets or sets the password associated with the created user.

## Class: Microsoft.B2C.Identity.UserCreateModel
Represents a model for creating a user in Microsoft B2C Identity. 

### Properties

#### FirstName
Gets or sets the first name of the user.
#### LastName
Gets or sets the last name of the user.
#### EmailAddress
Gets or sets the email address of the user.

## Class: Microsoft.B2C.Identity.UserIdentityModel
Represents a model for user identity information. 

### Properties

#### FirstName
Gets or sets the first name of the user.
#### LastName
Gets or sets the last name of the user.
#### EmailAddress
Gets or sets the email address of the user.
#### UserName
Gets or sets the username of the user.
#### Password
Gets or sets the password of the user.
#### ForcePasswordChangeNextSignIn
Gets or sets a value indicating whether the user should be forced to change their password at the next sign-in.