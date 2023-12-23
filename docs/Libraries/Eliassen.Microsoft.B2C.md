# Eliassen.Microsoft.B2C


## Class: Microsoft.B2C.Identity.ManageGraphUser
Implementation of and for managing users in Microsoft Graph.
### Methods


####Constructor
Initializes a new instance of the class.
    #####Parameters
    **log:** The logger.

    **config:** The configuration.


#### GetAuthProvider
Gets the authentication provider for Microsoft Graph.
    ##### Return value
    The authentication provider.

## Class: Microsoft.B2C.Identity.UserManagementProvider
Represents a provider for user management operations.
### Methods


####Constructor
Initializes a new instance of the class.
    #####Parameters
    **user:** The user manager for managing graph users.


#### CreateAccountAsync(Eliassen.Microsoft.B2C.Identity.UserCreateModel)
Creates a new user account asynchronously.
    #####Parameters
    **model:** The model containing user information for account creation.

    ##### Return value
    A task representing the asynchronous operation. The result is a model containing the created user's information.

## Class: Microsoft.B2C.ServiceCollectionEx
Extension methods for adding Microsoft B2C services to the service collection.
### Methods


#### AddMicrosoftB2CServices(Microsoft.Extensions.DependencyInjection.IServiceCollection)
Adds Microsoft B2C services to the service collection.
    #####Parameters
    **services:** The service collection to which Microsoft B2C services should be added.

    ##### Return value
    The modified service collection.