# Eliassen.System


## Class: System.Security.Cryptography.Md5Hash
Default hash of input value. Base64 encoded MD5 Hash 

### Methods


#### GetHash(System.String)
Computes the default hash of the input value using MD5. 


##### Parameters
* *value:* The input value to be hashed.




##### Return value
The Base64 encoded MD5 hash of the input value.



## Class: System.Security.Cryptography.Sha256Hash
Default hash of input value. Base64 encoded SHA256 Hash 

### Methods


#### GetHash(System.String)
Computes the default hash of the input value using SHA256. 


##### Parameters
* *value:* The input value to be hashed.




##### Return value
The Base64 encoded SHA256 hash of the input value.



## Class: System.Security.Cryptography.Sha512Hash
Default hash of input value. Base64 encoded SHA512 Hash 

### Methods


#### GetHash(System.String)
Computes the default hash of the input value using SHA512. 


##### Parameters
* *value:* The input value to be hashed.




##### Return value
The Base64 encoded SHA512 hash of the input value.



## Class: System.ServiceCollectionExtensions
Suggested IOC configurations 

### Methods


#### TryAddSystemExtensions(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration,Eliassen.System.Security.Cryptography.HashTypes,Eliassen.System.Text.SerializerTypes)
This will add all available extensions to the IOC container 


##### Parameters
* *services:* 
* *config:* 
* *defaultHashType:* 
* *defaultSerializerType:* 




##### Return value




#### TryAddSearchQueryExtensions(Microsoft.Extensions.DependencyInjection.IServiceCollection)
Add support for shared SearchQuery Extensions 


##### Parameters
* *services:* 




##### Return value




#### TrySecurityExtensions(Microsoft.Extensions.DependencyInjection.IServiceCollection,Eliassen.System.Security.Cryptography.HashTypes)
Add support for shared security extensions 


##### Parameters
* *services:* 
* *defaultHashType:* 




##### Return value




#### TrySerializerExtensions(Microsoft.Extensions.DependencyInjection.IServiceCollection,Eliassen.System.Text.SerializerTypes)
Add support for shared Serializer 


##### Parameters
* *services:* 
* *defaultSerializerType:* 




##### Return value




#### TryTemplatingExtensions(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration)
Add support for shared Templating 


##### Parameters
* *services:* 
* *config:* 




##### Return value




## Class: System.Text.Json.BsonDateTimeOffsetConverter
System.Text.Json converter to support BsonDatetimeOffset 

### Methods


#### CanConvert(System.Type)
Determines whether this converter can convert the specified type. 


##### Parameters
* *typeToConvert:* The type to check for conversion support.




##### Return value
true if the converter can convert the specified type; otherwise, false.



#### Read(System.Text.Json.Utf8JsonReader@,System.Type,System.Text.Json.JsonSerializerOptions)
Reads the JSON representation of the object. 


##### Parameters
* *reader:* The reader to read from.
* *typeToConvert:* The type of the object to convert.
* *options:* The serializer options to use during conversion.




##### Return value
The deserialized object value.



#### Write(System.Text.Json.Utf8JsonWriter,System.Object,System.Text.Json.JsonSerializerOptions)
Writes the JSON representation of the object. 


##### Parameters
* *writer:* The writer to write to.
* *value:* The value to convert.
* *options:* The serializer options to use during conversion.




## Class: System.Text.Json.BsonIdConverter
This type converter for System.Text.Json to support BSON ObjectID to JSON safe export/import 

### Methods


#### Read(System.Text.Json.Utf8JsonReader@,System.Type,System.Text.Json.JsonSerializerOptions)
read value from Bson and if object id is bson object id convert it to string 


##### Parameters
* *reader:* 
* *typeToConvert:* 
* *options:* 




##### Return value




##### Exceptions

* *System.NotSupportedException:* 




#### Write(System.Text.Json.Utf8JsonWriter,System.String,System.Text.Json.JsonSerializerOptions)
write object id to Bson object 


##### Parameters
* *writer:* 
* *value:* 
* *options:* 




## Class: System.Text.Json.BsonTypeInfoResolver
Resolves JSON type information for BSON serialization. 

### Methods


#### GetTypeInfo(System.Type,System.Text.Json.JsonSerializerOptions)
Gets the JSON type information for the specified type during BSON serialization. 


##### Parameters
* *type:* The type for which to get JSON type information.
* *options:* The used for serialization.




##### Return value
The JSON type information for the specified type.



## Class: System.Text.Json.ConfigurationJsonConverter`1
JsonConverter for serializing and deserializing IConfiguration instances. 
The type of IConfiguration. 

### Methods


#### Read(System.Text.Json.Utf8JsonReader@,System.Type,System.Text.Json.JsonSerializerOptions)
Reads the JSON representation of an IConfiguration instance and converts it. 


##### Parameters
* *reader:* The reader to read from.
* *typeToConvert:* The type to convert.
* *options:* The serializer options.




##### Return value
The converted IConfiguration instance.



#### Write(System.Text.Json.Utf8JsonWriter,`0,System.Text.Json.JsonSerializerOptions)
Writes the JSON representation of an IConfiguration instance. 


##### Parameters
* *writer:* The writer to write to.
* *value:* The IConfiguration instance to write.
* *options:* The serializer options.




## Class: System.Text.Json.DictionaryStringObjectJsonConverter
Custom JSON converter for dictionaries with string keys and object values. 

### Methods


#### CanConvert(System.Type)
Determines whether this converter can convert the specified type. 


##### Parameters
* *typeToConvert:* The type to convert.




##### Return value
true if the converter can convert the specified type; otherwise, false.



#### Read(System.Text.Json.Utf8JsonReader@,System.Type,System.Text.Json.JsonSerializerOptions)
Reads the JSON representation of a 
 *See: T:System.Collections.Generic.Dictionary`2*with string keys and object values. 


##### Parameters
* *reader:* The reader to read from.
* *typeToConvert:* The type to convert.
* *options:* The serializer options.




##### Return value
The converted dictionary.



#### Write(System.Text.Json.Utf8JsonWriter,System.Collections.Generic.Dictionary{System.String,System.Object},System.Text.Json.JsonSerializerOptions)
Writes the JSON representation of a 
 *See: T:System.Collections.Generic.Dictionary`2*with string keys and object values. 


##### Parameters
* *writer:* The writer to write to.
* *value:* The dictionary to write.
* *options:* The serializer options.




## Class: System.Text.Json.JsonDocumentExtensions
shared extension methods for System.Text.Json 

### Methods


#### ToXmlDocument(System.Text.Json.JsonElement,System.String)
Convert System.Test.Json.JsonDocument to System.Xml.XmlDocument 


##### Parameters
* *json:* 
* *rootName:* 




##### Return value




## Class: System.Text.Json.Serialization.DefaultBsonSerializer
Default serializer for BSON (Binary JSON). 

### Fields

#### DefaultContentType
The default content type for BSON.
### Properties

#### ContentType
Gets the content type for BSON, which is "application/json".
### Methods


#### Constructor
Initializes a new instance of the 
 *See: T:Eliassen.System.Text.Json.Serialization.DefaultBsonSerializer*class. 


## Class: System.Text.Json.Serialization.DefaultJsonSerializer
Default serializer for JSON. 

Initializes a new instance of the class.
### Fields

#### DefaultContentType
Gets the default content type for JSON.
#### _options
The JSON serializer options.
### Properties

#### DefaultOptions
Gets the default JSON serializer options.
#### ContentType
Gets the content type for JSON.
### Methods


#### Constructor
Initializes a new instance of the class.
Default serializer for JSON. 


##### Parameters
* *options:* Optional JSON serializer options.




#### Serialize``1(``0)
Serializes an object to a JSON string. 


#### Serialize(System.Object,System.Type)
Serializes an object of a given type to a JSON string. 


#### SerializeAsync``1(``0,System.IO.Stream,System.Threading.CancellationToken)
Asynchronously serializes an object to a JSON string. 


#### SerializeAsync(System.Object,System.Type,System.IO.Stream,System.Threading.CancellationToken)
Asynchronously serializes an object of a given type to a JSON string. 


#### Deserialize``1(System.IO.Stream)
Deserializes a JSON stream to an object of type T. 


#### Deserialize(System.IO.Stream,System.Type)
Deserializes a JSON stream to an object of a given type. 


#### DeserializeAsync``1(System.IO.Stream,System.Threading.CancellationToken)
Asynchronously deserializes a JSON stream to an object of type T. 


#### DeserializeAsync(System.IO.Stream,System.Type,System.Threading.CancellationToken)
Asynchronously deserializes a JSON stream to an object of a given type. 


#### Deserialize``1(System.String)
Deserializes a JSON string to an object of type T. 


#### Deserialize(System.String,System.Type)
Deserializes a JSON string to an object of a given type. 


#### AsPropertyName(System.String)
Use the configured property naming policy to change the provided value. 


##### Parameters
* *propertyName:* The property name to convert.




##### Return value
The converted property name.



## Class: System.Text.Templating.FileTemplateSource
Access template from file system 

### Methods


#### Constructor
Access template from file system 


#### Get(System.String)
Look up templates from a file system. 


##### Parameters
* *templateName:* 




##### Return value




## Class: System.Text.Templating.FileTemplatingSettings
Configuration settings for file templating engine 

### Properties

#### TemplatePath
template source path
#### SandboxPath
sandbox root path
#### Priority
template priority

## Class: System.Text.Templating.TemplateContext
Represents the context of a template, providing information about the template and its processing. 

### Properties

#### TemplateName
Gets or sets the name of the template.
#### TemplateContentType
Gets or sets the content type of the template.
#### TemplateFileExtension
Gets or sets the file extension of the template.
#### TemplateSource
Gets or sets the source of the template.
#### TemplateReference
Gets or sets the reference identifier of the template.
#### OpenTemplate
Gets or sets the function to open the template as a stream.
#### TargetContentType
Gets or sets the content type of the target.
#### TargetFileExtension
Gets or sets the file extension of the target.
#### Priority
Gets or sets the priority of the template.
### Methods


#### ToString
Returns a string representation of the template context. 


##### Return value
A string representation of the template context.



## Class: System.Text.Templating.TemplateEngine
Generate templating engine that will try to use best match for source and provider 

### Methods


#### Constructor
Generate templating engine that will try to use best match for source and provider 


##### Parameters
* *sources:* An enumerable collection of template sources.
* *providers:* An enumerable collection of template providers.
* *logger:* The logger for capturing log messages.




#### ApplyAsync(System.String,System.Object,System.IO.Stream)
Applies the template asynchronously to the provided data and writes the result to the target stream. 


##### Parameters
* *templateName:* The name of the template to apply.
* *data:* The data to apply to the template.
* *target:* The stream to write the result to.




##### Return value
The applied template context or null if no matching template is found.



#### ApplyAsync(Eliassen.System.Text.Templating.ITemplateContext,System.Object,System.IO.Stream)
Applies the template asynchronously to the provided data and writes the result to the target stream. 


##### Parameters
* *context:* The template context to apply.
* *data:* The data to apply to the template.
* *target:* The stream to write the result to.




##### Return value
true if the template is applied successfully; otherwise, false.



#### ApplyAsync(System.String,System.Object)
Applies the template asynchronously to the provided data and returns the result as a string. 


##### Parameters
* *templateName:* The name of the template to apply.
* *data:* The data to apply to the template.




##### Return value
The applied template as a string or null if no matching template is found.



#### ApplyAsync(Eliassen.System.Text.Templating.ITemplateContext,System.Object)
Applies the template asynchronously to the provided data and returns the result as a string. 


##### Parameters
* *context:* The template context to apply.
* *data:* The data to apply to the template.




##### Return value
The applied template as a string or null if the template cannot be applied.



#### Get(System.String)
Gets the template context with the specified name. 


##### Parameters
* *templateName:* The name of the template to retrieve.




##### Return value
The template context or null if no matching template is found.



#### GetAll(System.String)
Gets all template contexts with the specified name. 


##### Parameters
* *templateName:* The name of the template to retrieve.




##### Return value
An enumerable collection of template contexts.



## Class: System.Text.Templating.XsltTemplateProvider
Provides template processing using XSLT (eXtensible Stylesheet Language Transformations). 

### Properties

#### SupportedContentTypes
Gets the collection of supported content types by the template provider. application/xslt+xml
### Methods


#### CanApply(Eliassen.System.Text.Templating.ITemplateContext)
Determines whether this template provider can apply template processing to the given context. 


##### Parameters
* *context:* The template context.




##### Return value
true if the template processing can be applied; otherwise, false.



#### ApplyAsync(Eliassen.System.Text.Templating.ITemplateContext,System.Object,System.IO.Stream)
Applies the XSLT template associated with the specified context, using the provided data, and writes the result to the target stream asynchronously. 


##### Parameters
* *context:* The template context.
* *data:* The data to apply to the template.
* *target:* The stream where the result will be written.




##### Return value
A task representing the asynchronous operation, indicating whether the application was successful.



## Class: System.Text.Xml.Serialization.DefaultXmlSerializer
Default XmlSerializer, 
