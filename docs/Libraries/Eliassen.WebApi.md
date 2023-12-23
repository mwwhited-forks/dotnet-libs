# Eliassen.WebApi


## Class: WebApi.Controllers.CommunicationsController
Controller for handling communication-related operations, such as sending emails and messages to a queue.
### Methods


####Constructor
Initializes a new instance of the class.
    #####Parameters
    **email:** The email communication sender.

    **queue:** The message queue sender.


#### SendAnonymous(Eliassen.Communications.Models.EmailMessageModel)
Sends an email publicly without requiring authentication.
    #####Parameters
    **model:** The email message model.

    ##### Return value
    A task representing the asynchronous operation and containing a string result.

#### Enqueue(Eliassen.Communications.Models.EmailMessageModel)
Enqueues an email message to be processed asynchronously.
    #####Parameters
    **model:** The email message model.

    ##### Return value
    A task representing the asynchronous operation and containing a string result.

#### SendAuthorize(Eliassen.Communications.Models.EmailMessageModel)
Sends an email with authorization, requiring the caller to be authenticated.
    #####Parameters
    **model:** The email message model.

    ##### Return value
    A task representing the asynchronous operation and containing a string result.

## Class: WebApi.Controllers.MessageQueueingController
Controller for handling message queueing operations.
### Methods


####Constructor
Initializes a new instance of the class.
    #####Parameters
    **provider:** The example message provider.


#### PublicSend(Eliassen.WebApi.Models.ExampleMessageModel,System.String)
Sends a message to the queue publicly without requiring authentication.
    #####Parameters
    **model:** The example message model.

    **correlationId:** Optional correlation ID for tracking purposes.

    ##### Return value
    A task representing the asynchronous operation and containing a string result.

#### AuthenticatedSend(Eliassen.WebApi.Models.ExampleMessageModel,System.String)
Sends a message to the queue with authorization, requiring the caller to be authenticated.
    #####Parameters
    **model:** The example message model.

    **correlationId:** Optional correlation ID for tracking purposes.

    ##### Return value
    A task representing the asynchronous operation and containing a string result.

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
Implementation of and for handling and sending example messages.
### Methods


####Constructor
Initializes a new instance of the class.
    #####Parameters
    **sender:** The message queue sender for sending messages.

    **logger:** The logger for logging messages.


## Class: WebApi.Provider.IExampleMessageProvider
Interface for providing asynchronous operations related to example messages.
### Methods


#### PostAsync(System.Object,System.String)
Posts an example message asynchronously.
    #####Parameters
    **message:** The message object to be posted.

    **correlationId:** Optional correlation ID for tracking purposes.

    ##### Return value
    A task representing the asynchronous operation and containing a string result.