# Eliassen.Azure.StorageAccount


## Class: Azure.StorageAccount.BlobStorage.AzureBlobContainerOptions
Represents the options for configuring an Azure Blob Storage container. 

### Properties

#### ContainerName
Gets or sets the name of the container. This property is required and specifies the name of the Azure Blob Storage container.
#### ConnectionString
Gets or sets the connection string for the Azure Storage account. This property is required and specifies the connection string used to connect to the Azure Storage account.

## Class: Azure.StorageAccount.BlobStorage.BlobContainerProvider
Implementation of 
 *See: T:Eliassen.Azure.StorageAccount.BlobStorage.IDocumentProvider*for handling blob containers in Azure Storage. 
Initializes a new instance of the 
 *See: T:Eliassen.Azure.StorageAccount.BlobStorage.BlobContainerProvider*class. 

### Methods


#### Constructor
Implementation of 
 *See: T:Eliassen.Azure.StorageAccount.BlobStorage.IDocumentProvider*for handling blob containers in Azure Storage. 


##### Parameters
* *config:* The configuration.
* *logger:* The logger.




#### ListAsync
Lists all blobs in the container. 


##### Return value
A list of representing the blobs in the container.



#### UploadAsync(Eliassen.Azure.StorageAccount.BlobStorage.DocumentModel,System.IO.Stream)
Uploads a blob to the container. 


##### Parameters
* *document:* The document model.
* *content:* The content stream.




##### Return value
A representing the result of the upload operation.



#### DownloadAsync(System.String)
Downloads a blob from the container. 


##### Parameters
* *blobFilename:* The name of the blob.




##### Return value
A representing the downloaded blob or null if the blob does not exist.



#### DeleteAsync(System.String)
Deletes a blob from the container. 


##### Parameters
* *blobFilename:* The name of the blob.




##### Return value
A representing the result of the delete operation.



## Class: Azure.StorageAccount.MessageQueueing.AzureStorageQueueMessageProvider
Provides functionality for sending and receiving messages using Azure Storage Queues. 
Initializes a new instance of the 
 *See: T:Eliassen.Azure.StorageAccount.MessageQueueing.AzureStorageQueueMessageProvider*class. 

### Methods


#### Constructor
Provides functionality for sending and receiving messages using Azure Storage Queues. 


##### Parameters
* *serializer:* The JSON serializer for message serialization and deserialization.
* *clientFactory:* The factory for creating Azure Storage Queue clients.
* *logger:* The logger for logging messages.




#### SendAsync(System.Object,Eliassen.MessageQueueing.Services.IMessageContext)
Sends a message asynchronously to an Azure Storage Queue. 


##### Parameters
* *message:* The message to be sent.
* *context:* The message context containing additional information.




##### Return value
The message ID if the send operation is successful; otherwise, null.



#### SetHandlerProvider(Eliassen.MessageQueueing.Services.IMessageHandlerProvider)
Sets the message handler provider for processing received messages. 


##### Parameters
* *handlerProvider:* The message handler provider.




##### Return value
The current instance of .



#### RunAsync(System.Threading.CancellationToken)
Runs the message receiver asynchronously, continuously listening for incoming messages. 


##### Parameters
* *cancellationToken:* The cancellation token to stop the receiver.




##### Return value
A task representing the asynchronous operation.



## Class: Azure.StorageAccount.MessageQueueing.IQueueClientFactory
Factory for creating instances of 
 *See: T:Azure.Storage.Queues.QueueClient*for Azure Storage Queues. 

### Methods


#### Create(Microsoft.Extensions.Configuration.IConfigurationSection)
Creates a new instance of 
 *See: T:Azure.Storage.Queues.QueueClient*based on the provided configuration section. 


##### Parameters
* *config:* The configuration section containing connection string and queue name.




##### Return value
A new instance of for the specified Azure Storage Queue.



##### Exceptions

* *System.ApplicationException:* Thrown if the required configuration values ("ConnectionString" or "QueueName") are missing.




## Class: Azure.StorageAccount.MessageQueueing.QueueClientFactory
Factory for creating instances of 
 *See: T:Azure.Storage.Queues.QueueClient*for Azure Storage Queues. 

### Methods


#### Create(Microsoft.Extensions.Configuration.IConfigurationSection)
Creates a new instance of 
 *See: T:Azure.Storage.Queues.QueueClient*based on the provided configuration section. 


##### Parameters
* *config:* The configuration section containing connection string and queue name.




##### Return value
A new instance of for the specified Azure Storage Queue.



##### Exceptions

* *System.ApplicationException:* Thrown if the required configuration values ("ConnectionString" or "QueueName") are missing.




## Class: Azure.StorageAccount.ServiceCollectionExtensions
Provides extension methods for configuring Azure Storage services in the 
 *See: T:Microsoft.Extensions.DependencyInjection.IServiceCollection*. 

### Methods


#### TryAddAzureStorageServices(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration,System.String)
Tries to add Azure Storage services including blob and queue services to the specified 
 *See: T:Microsoft.Extensions.DependencyInjection.IServiceCollection*. 


##### Parameters
* *services:* The to add services to.
* *configuration:* The to add services to.
* *azureBlobContainerConfigurationSection:* The name for the ConfigurationSectionName.




##### Return value
The modified .



#### TryAddAzureStorageBlobServices(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration,System.String)
Tries to add Azure Storage blob services to the specified 
 *See: T:Microsoft.Extensions.DependencyInjection.IServiceCollection*. 


##### Parameters
* *services:* The to add services to.
* *configuration:* The to add services to.
* *configurationSection:* The name for the ConfigurationSectionName.




##### Return value
The modified .



#### TryAddAzureStorageQueueServices(Microsoft.Extensions.DependencyInjection.IServiceCollection)
Tries to add Azure Storage queue services to the specified 
 *See: T:Microsoft.Extensions.DependencyInjection.IServiceCollection*. 


##### Parameters
* *services:* The to add services to.




##### Return value
The modified .

