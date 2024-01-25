# Eliassen.Extensions


## Class: Extensions.Accessors.Accessor`1
Represents an accessor for a value of type 
. 
The type of the value to be accessed. 

### Properties

#### Value
Gets or sets the value associated with this accessor.

## Class: Extensions.Configuration.CommandLine
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



## Class: Extensions.IO.StreamJsonDeserializeExtensions
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




## Class: Extensions.IO.StreamXmlDeserializeExtensions
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




## Class: Extensions.Linq.AsyncEnumerableExtensions
Extensions to add async support to existing IEnumerable{T} 

### Methods


#### ToListAsync``1(System.Linq.IQueryable{``0},System.Threading.CancellationToken)
Process IQueryable{T} to a List{T} as async 


##### Parameters
* *source:* 
* *cancellationToken:* 




##### Return value




#### AsEnumerableAsync``1(System.Collections.Generic.IAsyncEnumerable{``0},System.Threading.CancellationToken)
Convert IAsyncEnumerable{TModel} to Task{IEnumerable{TModel}} 


##### Parameters
* *items:* 
* *token:* 




##### Return value




#### AsAsyncEnumerable``1(System.Threading.Tasks.Task{System.Collections.Generic.IEnumerable{``0}},System.Threading.CancellationToken)
Convert Task{IEnumerable{TModel}} to IAsyncEnumerable{TModel} 


##### Parameters
* *items:* 
* *cancellationToken:* 




##### Return value




#### AsAsyncEnumerable``1(System.Collections.Generic.IEnumerable{``0},System.Threading.CancellationToken)
Convert IEnumerable{TModel} to IAsyncEnumerable{TModel} 


##### Parameters
* *items:* 
* *cancellationToken:* 




##### Return value




## Class: Extensions.Linq.DictionaryExtensions
Reusable extensions for Generic Dictionaries 

### Methods


#### TryGetValue``2(System.Collections.Generic.IDictionary{``0,``1},``0,``1@,System.Collections.Generic.IEqualityComparer{``0})
extend try get value to allow for using a different IEqualityComparer{TKey} 


##### Parameters
* *dictionary:* 
* *key:* 
* *value:* 
* *comparer:* 




##### Return value




#### ChangeComparer``2(System.Collections.Generic.IDictionary{``0,``1},System.Collections.Generic.IEqualityComparer{``0})
Rebuild dictionary to use a different IEqualityComparer{TKey} 


##### Parameters
* *dictionary:* 
* *comparer:* 




##### Return value




## Class: Extensions.Reflection.ReflectionExtensions
Extensions for reflection and common patterns. 

### Fields

#### PublicProperties
flag combination to select public instance properties
#### PublicStaticMethod
flag combination to select public static methods
#### PublicInstanceMethod
flag combination to select public instance methods
### Methods


#### GetKeyValue(System.Object)
lookup key values for provided entity 


##### Parameters
* *item:* 




##### Return value




#### MakeSafeArray(System.Type,System.Array)
safely create new array for a given element type. 


##### Parameters
* *type:* 
* *inputs:* 




##### Return value




#### MakeSafe(System.Type,System.Object)
Make safe will try to convert input to target type as best as possible. 


##### Parameters
* *type:* 
* *input:* 




##### Return value




#### TryParse(System.Type,System.String,System.Object@)
Use best possible match for parsing to provided type 


##### Parameters
* *type:* 
* *toParse:* 
* *parsed:* 




##### Return value




#### GetShortTypeName(System.Type)
Type name with full namespace, name and assembly. version is not included 


##### Parameters
* *type:* 




##### Return value




#### GetAttributes(System.Type)
Get all attributes for type 


##### Parameters
* *type:* 




##### Return value




#### GetAttributes``1(System.Type)
Get all attributes of selected style for reflected type 


##### Parameters
* *type:* 




##### Return value




#### GetPropertiesByAttribute``1(System.Type)
get property info where attribute matches 


##### Parameters
* *type:* 




##### Return value




#### GetStaticMethod(System.Type,System.String,System.Type[])
get static method 


##### Parameters
* *type:* 
* *methodName:* 
* *parameterTypes:* 




##### Return value




#### GetInstanceMethod(System.Type,System.String,System.Type[])
get instance method 


##### Parameters
* *type:* 
* *methodName:* 
* *parameterTypes:* 




##### Return value




#### GetParametersTypes(System.Reflection.MethodInfo)
get parameters for method 


##### Parameters
* *method:* 




##### Return value




## Class: Extensions.Reflection.ResourceExtensions
Set of extension methods for embedded resources 

### Methods


#### GetResourceStream(System.Object,System.String)
Lookup resource stream based on filename relative the scope of context 


##### Parameters
* *context:* 
* *resourceName:* 




##### Return value




#### GetResourceStream(System.Type,System.String)
Lookup resource stream based on filename relative the scope of Type 


##### Parameters
* *type:* 
* *resourceName:* 




##### Return value




#### GetResourceStream(System.Reflection.Assembly,System.String)
Lookup resource stream based on filename relative the scope of Type 


##### Parameters
* *assembly:* 
* *resourceName:* 




##### Return value




#### GetResourceAsStringAsync(System.Object,System.String)
Lookup resource content based on filename relative the scope of context 


##### Parameters
* *context:* 
* *resourceName:* 




##### Return value




#### GetResourceAsString(System.Object,System.String)
Lookup resource content based on filename relative the scope of context 


##### Parameters
* *context:* 
* *resourceName:* 




##### Return value




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


