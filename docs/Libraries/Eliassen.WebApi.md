# Eliassen.WebApi


## Class: WebApi.ApplicationServiceCollectionBuilder
Provides extension methods for configuring application services in the 
 *See: T:Microsoft.Extensions.DependencyInjection.IServiceCollection*. 

### Methods


#### AddApplicationServices(Microsoft.Extensions.DependencyInjection.IServiceCollection)
Adds application services to the specified 
 *See: T:Microsoft.Extensions.DependencyInjection.IServiceCollection*. 


##### Parameters
* *services:* The instance.




##### Return value
The updated instance.



## Class: WebApi.Controllers.CommunicationsController
Controller for handling communication-related operations, such as sending emails and messages to a queue. 

Initializes a new instance of the class.
### Methods


#### Constructor
Initializes a new instance of the class.
Controller for handling communication-related operations, such as sending emails and messages to a queue. 


##### Parameters
* *email:* The email communication sender.
* *queue:* The message queue sender.




#### SendAnonymous(Eliassen.Communications.Models.EmailMessageModel)
Sends an email publicly without requiring authentication. 


##### Parameters
* *model:* The email message model.




##### Return value
A task representing the asynchronous operation and containing a string result.



#### Enqueue(Eliassen.Communications.Models.EmailMessageModel)
Enqueues an email message to be processed asynchronously. 


##### Parameters
* *model:* The email message model.




##### Return value
A task representing the asynchronous operation and containing a string result.



#### SendAuthorize(Eliassen.Communications.Models.EmailMessageModel)
Sends an email with authorization, requiring the caller to be authenticated. 


##### Parameters
* *model:* The email message model.




##### Return value
A task representing the asynchronous operation and containing a string result.



## Class: WebApi.Controllers.MessageQueueingController
Controller for handling message queueing operations. 

Initializes a new instance of the class.
### Methods


#### Constructor
Initializes a new instance of the class.
Controller for handling message queueing operations. 


##### Parameters
* *provider:* The example message provider.




#### PublicSend(Eliassen.WebApi.Models.ExampleMessageModel,System.String)
Sends a message to the queue publicly without requiring authentication. 


##### Parameters
* *model:* The example message model.
* *correlationId:* Optional correlation ID for tracking purposes.




##### Return value
A task representing the asynchronous operation and containing a string result.



#### AuthenticatedSend(Eliassen.WebApi.Models.ExampleMessageModel,System.String)
Sends a message to the queue with authorization, requiring the caller to be authenticated. 


##### Parameters
* *model:* The example message model.
* *correlationId:* Optional correlation ID for tracking purposes.




##### Return value
A task representing the asynchronous operation and containing a string result.



## Class: WebApi.Controllers.TextTemplateController
Controller for handling text template operations. 
Initializes a new instance of the 
 *See: T:Eliassen.WebApi.Controllers.TextTemplateController*class. 

### Methods


#### Constructor
Controller for handling text template operations. 


##### Parameters
* *engine:* The template engine for processing text templates.
* *fileTypes:* The collection of file types supported by the controller.




#### SupportedTemplates
Gets the list of supported template file types. 


##### Return value
An enumeration of supported file types.



#### Apply(System.String,System.Text.Json.Nodes.JsonNode)
Applies a text template with the specified name and data. 


##### Parameters
* *templateName:* The name of the text template to apply.
* *data:* The JSON data used for template processing.




##### Return value
An action result containing the processed template content as a downloadable file.



## Class: WebApi.Controllers.UserController
Initializes a new instance of the 
 *See: T:Eliassen.WebApi.Controllers.UserController*class. 

### Methods


#### Constructor
Initializes a new instance of the 
 *See: T:Eliassen.WebApi.Controllers.UserController*class. 


##### Parameters
* *claimsPrincipal:* The claims principal representing the current user.




#### GetClaims
Gets the claims associated with the current user. 


##### Return value
An enumerable collection of representing the user's claims.



## Class: WebApi.Models.ClaimModel
Represents a model for a claim. 

### Properties

#### Issuer
Gets or sets the issuer of the claim. This property is required.
#### Value
Gets or sets the value of the claim. This property is required.
#### ValueType
Gets or sets the value type of the claim. This property is required.
#### Type
Gets or sets the type of the claim. This property is required.
#### OriginalIssuer
Gets or sets the original issuer of the claim. This property is required.
#### SubjectName
Gets or sets the subject name associated with the claim. This property is optional.
#### SubjectLabel
Gets or sets the subject label associated with the claim. This property is optional.
#### SubjectAuthenticationType
Gets or sets the authentication type of the subject associated with the claim. This property is optional.

## Class: WebApi.Models.ExampleMessageModel
Represents an example message model. 

### Properties

#### Input
Gets or sets the input string. Default value is "Default Value".
#### Data
Gets or sets the JSON data associated with the message.

## Class: WebApi.Program
primary entry point 

### Methods


#### Main(System.String[])
primary entry point 


## Class: WebApi.Provider.ExampleMessageProvider
Implementation of 
 *See: T:Eliassen.WebApi.Provider.IExampleMessageProvider*and 
 *See: T:Eliassen.MessageQueueing.IMessageQueueHandler`1*for handling and sending example messages. 

Initializes a new instance of the class.
### Methods


#### Constructor
Initializes a new instance of the class.
Implementation of 
 *See: T:Eliassen.WebApi.Provider.IExampleMessageProvider*and 
 *See: T:Eliassen.MessageQueueing.IMessageQueueHandler`1*for handling and sending example messages. 


##### Parameters
* *sender:* The message queue sender for sending messages.
* *logger:* The logger for logging messages.




#### PostAsync(System.Object,System.String)
Posts an example message asynchronously. 


##### Parameters
* *message:* The message to be sent.
* *correlationId:* The optional correlation ID.




##### Return value
The message ID.



#### HandleAsync(System.Object,Eliassen.MessageQueueing.Services.IMessageContext)
Handles an example message asynchronously. 


##### Parameters
* *message:* The received message.
* *context:* The message context.




##### Return value
A task representing the asynchronous operation.



## Class: WebApi.Provider.IExampleMessageProvider
Interface for providing asynchronous operations related to example messages. 

### Methods


#### PostAsync(System.Object,System.String)
Posts an example message asynchronously. 


##### Parameters
* *message:* The message object to be posted.
* *correlationId:* Optional correlation ID for tracking purposes.




##### Return value
A task representing the asynchronous operation and containing a string result.

