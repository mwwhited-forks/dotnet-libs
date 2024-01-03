# Swagger Description - Eliassen.WebApi

*Version*: 0.1.58.55

## Endpoints

### /api/Communications/public


Sends an email publicly without requiring authentication.

HTTP Method: *post* \
Anonymous:   *True*



Request:     *#/components/schemas/Eliassen.Communications.Models.EmailMessageModel*

The email message model.



### /api/Communications/queued


Enqueues an email message to be processed asynchronously.

HTTP Method: *post* \
Anonymous:   *True*



Request:     *#/components/schemas/Eliassen.Communications.Models.EmailMessageModel*

The email message model.



### /api/Communications/private


Sends an email with authorization, requiring the caller to be authenticated.

HTTP Method: *post* \
Anonymous:   *False*



Request:     *#/components/schemas/Eliassen.Communications.Models.EmailMessageModel*

The email message model.



### /api/MessageQueueing/public


Sends a message to the queue publicly without requiring authentication.

HTTP Method: *post* \
Anonymous:   *True*



Request:     *#/components/schemas/Eliassen.WebApi.Models.ExampleMessageModel*

The example message model.



### /api/MessageQueueing/private


Sends a message to the queue with authorization, requiring the caller to be authenticated.

HTTP Method: *post* \
Anonymous:   *False*



Request:     *#/components/schemas/Eliassen.WebApi.Models.ExampleMessageModel*

The example message model.



### /api/TextTemplate/SupportedTemplates


Gets the list of supported template file types.

HTTP Method: *post* \
Anonymous:   *True*





### /api/TextTemplate/Apply


Applies a text template with the specified name and data.

HTTP Method: *post* \
Anonymous:   *True*



Request:     *#/components/schemas/System.Text.Json.Nodes.JsonNode*

The JSON data used for template processing.



## Models

### Eliassen.Communications.Models.AttachmentReferenceModel


#### Properties
| Name | Type | other |
|------|------|-------|
| containerName | string? | Gets the name of the container where the attachment is stored. | 
| documentKey | string? | Gets the key or identifier of the document associated with the attachment. | 


### Eliassen.Communications.Models.EmailMessageModel


#### Properties
| Name | Type | other |
|------|------|-------|
| referenceId | string? | Gets or sets the reference ID of the email message. | 
| fromAddress | string? | Gets or sets the sender's email address. | 
| toAddresses | string[]? | Gets or sets the list of recipient email addresses. | 
| ccAddresses | string[]? | Gets or sets the list of carbon copy (CC) email addresses. | 
| bccAddresses | string[]? | Gets or sets the list of blind carbon copy (BCC) email addresses. | 
| subject | string? | Gets or sets the subject of the email message. | 
| textContent | string? | Gets or sets the plain text content of the email message. | 
| htmlContent | string? | Gets or sets the HTML content of the email message. | 
| headers | object? | Gets or sets the headers of the email message. | 
| attachments | array? | Gets or sets the list of attachment references in the email message. | 


### Eliassen.System.Text.Templating.FileType


#### Properties
| Name | Type | other |
|------|------|-------|
| extension | string? | Gets or sets the file extension associated with the file type. | 
| contentType | string? | Gets or sets the content type associated with the file type. | 
| isTemplateType | boolean | Gets or sets a value indicating whether the file type is a template type. | 


### Eliassen.WebApi.Models.ExampleMessageModel


#### Properties
| Name | Type | other |
|------|------|-------|
| input | string? | Gets or sets the input string. Default value is &quot;Default Value&quot;. | 
| data | System.Text.Json.Nodes.JsonNode |  | 


### System.Text.Json.Nodes.JsonNode


#### Properties
| Name | Type | other |
|------|------|-------|
| options | System.Text.Json.Nodes.JsonNodeOptions |  | 
| parent | System.Text.Json.Nodes.JsonNode |  | 
| root | System.Text.Json.Nodes.JsonNode |  | 


### System.Text.Json.Nodes.JsonNodeOptions


#### Properties
| Name | Type | other |
|------|------|-------|
| propertyNameCaseInsensitive | boolean |  | 


