# Eliassen.Extensions


## Class: Extensions.Accessors.Accessor`1
Represents an accessor for a value of type 
. 
The type of the value to be accessed. 

### Properties

#### Value
Gets or sets the value associated with this accessor.

## Class: Extensions.Configuration.ConfigurationBuilderExtensions
Extension methods for adding in-memory collections to the 
 *See: T:Microsoft.Extensions.Configuration.IConfigurationBuilder*. 

### Methods


#### AddInMemoryCollection(Microsoft.Extensions.Configuration.IConfigurationBuilder,System.Collections.Generic.IEnumerable{System.ValueTuple{System.String,System.String}})
Adds an in-memory collection to the 
 *See: T:Microsoft.Extensions.Configuration.IConfigurationBuilder*using the specified initial data. 


##### Parameters
* *configurationBuilder:* The to add the in-memory collection to.
* *initialData:* The initial data to populate the in-memory collection.




##### Return value
The modified .



#### AddInMemoryCollection(Microsoft.Extensions.Configuration.IConfigurationBuilder,System.ValueTuple{System.String,System.String},System.ValueTuple{System.String,System.String}[])
Adds an in-memory collection to the 
 *See: T:Microsoft.Extensions.Configuration.IConfigurationBuilder*using the specified initial data. 


##### Parameters
* *configurationBuilder:* The to add the in-memory collection to.
* *item:* The first item of the in-memory collection.
* *initialData:* Additional initial data to populate the in-memory collection.




##### Return value
The modified .



## Class: Extensions.ServiceCollectionExtensions
Suggested IOC configurations 

### Methods


#### AddAccessor``1(Microsoft.Extensions.DependencyInjection.IServiceCollection)
Register accessor type that is scoped to as AsyncLocal 


##### Parameters
* *services:* 




##### Return value




#### AddConfiguration``1(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration)
Extend configuration options 


##### Parameters
* *services:* 
* *config:* 




##### Return value




#### GetSingletonInstance``2(Microsoft.Extensions.DependencyInjection.IServiceCollection,``1@)
Get singleton instance from IOC container 


##### Parameters
* *services:* 
* *instance:* 




##### Return value




## Class: System.Configuration.CommandLine
builder pattern for command parameter arguments 

### Methods


#### AddParameters``1(System.Collections.Generic.IDictionary{System.String,System.String})
add additional configurable parameters 


##### Parameters
* *items:* 




##### Return value




#### BuildParameters``1
entry point or defining configurable parameters 


##### Return value




## Class: System.IO.StreamJsonDeserializeExtensions
Set of extension method to centralize deserialize of stream using System.Text.Json 

### Methods


#### AsJsonAsync``1(System.IO.Stream,System.Text.Json.JsonSerializerOptions)
Convert JSON Stream to .Net Object 


##### Parameters
* *stream:* 
* *options:* 




##### Return value




#### AsJson``1(System.IO.Stream,System.Text.Json.JsonSerializerOptions)
Convert JSON Stream to .Net Object 


##### Parameters
* *stream:* 
* *options:* 




##### Return value




#### AsJsonAsync(System.IO.Stream,System.Type,System.Text.Json.JsonSerializerOptions)
Convert JSON Stream to .Net Object 


##### Parameters
* *stream:* 
* *type:* 
* *options:* 




##### Return value




#### AsJson(System.IO.Stream,System.Type,System.Text.Json.JsonSerializerOptions)
Convert JSON Stream to .Net Object 


##### Parameters
* *stream:* 
* *type:* 
* *options:* 




##### Return value




## Class: System.IO.StreamXmlDeserializeExtensions
Set of extension method to centralize deserialize of stream using System.Xml 

### Methods


#### AsXmlAsync``1(System.IO.Stream,System.Type[])
Convert XML Stream to .Net Object 


##### Parameters
* *stream:* 
* *extraTypes:* 




##### Return value




#### AsXml``1(System.IO.Stream,System.Type[])
Convert XML Stream to .Net Object 


##### Parameters
* *stream:* 
* *extraTypes:* 




##### Return value




#### AsXmlAsync(System.IO.Stream,System.Type,System.Type[])
Convert XML Stream to .Net Object 


##### Parameters
* *stream:* 
* *type:* 
* *extraTypes:* 




##### Return value




#### AsXml(System.IO.Stream,System.Type,System.Type[])
Convert XML Stream to .Net Object 


##### Parameters
* *stream:* 
* *type:* 
* *extraTypes:* 




##### Return value


