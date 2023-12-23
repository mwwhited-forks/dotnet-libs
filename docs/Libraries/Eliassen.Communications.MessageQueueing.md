# Eliassen.Communications.MessageQueueing


## Class: Communications.MessageQueueing.EmailMessageHandler
Represents a message handler for handling and sending email messages.
### Methods


####Constructor
Initializes a new instance of the class.
    #####Parameters
    **email:** The communication sender for email messages.

    **logger:** The logger.


#### HandleAsync(Eliassen.Communications.Models.EmailMessageModel,Eliassen.MessageQueueing.Services.IMessageContext)
Handles the specified email message asynchronously.
    #####Parameters
    **message:** The email message to handle.

    **context:** The message context.

    ##### Return value
    A task representing the asynchronous operation.

#### HandleAsync(System.Object,Eliassen.MessageQueueing.Services.IMessageContext)
Handles the specified message asynchronously.
    #####Parameters
    **message:** The message to handle.

    **context:** The message context.

    ##### Return value
    A task representing the asynchronous operation.