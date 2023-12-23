# Eliassen.MessageQueueing.Hosting


## Class: WebApi.Workers.MessageReceiverHost
Hosted service responsible for starting and stopping message receivers based on the configured providers.
Initializes a new instance of the class.
    **logger:** The logger.

    **factory:** The message receiver provider factory.

### Methods


####Constructor
Initializes a new instance of the class.
Hosted service responsible for starting and stopping message receivers based on the configured providers.
    #####Parameters
    **logger:** The logger.

    **factory:** The message receiver provider factory.


#### Dispose
Disposes of the resources used by the .

#### StartAsync(System.Threading.CancellationToken)
Starts the message receiver host.
    #####Parameters
    **cancellationToken:** The cancellation token.

    ##### Return value
    A task representing the start operation.

#### StopAsync(System.Threading.CancellationToken)
Stops the message receiver host.
    #####Parameters
    **cancellationToken:** The cancellation token.

    ##### Return value
    A task representing the stop operation.