Here is the documentation for the Eliassen.Extensions project:

**Eliassen.Extensions Namespace**

The Eliassen.Extensions namespace provides a collection of extension methods and utility classes for common tasks such as accessing values, configuration, file operations, stream manipulation, reflection, and string manipulation.

**Key Classes and Extensions**

* **Accessor<T>**: A class that represents an accessor for a value of type T, providing a property to get or set the associated value.
* **CommandLine**: A class that provides a builder pattern for command parameter arguments, with methods for adding and building configurable parameters.
* **ConfigurationBuilderExtensions**: A set of extension methods for building and configuring an instance of `IConfigurationBuilder`.
* **FileTools**: A set of methods for working with files, including asynchronous splitting of files into chunks.
* **StreamExtensions**: A set of methods for working with streams, including creating an in-memory copy of a stream and splitting a stream into chunks.
* **StreamJsonDeserializeExtensions**: A set of extension methods for deserializing JSON streams using System.Text.Json.
* **StreamXmlDeserializeExtensions**: A set of extension methods for deserializing XML streams using System.Xml.
* **AsyncEnumerableExtensions**: A set of extensions to add async support to existing `IEnumerable<T>`, including methods for converting async enumerable sequences to lists and sets.
* **DictionaryExtensions**: A set of reusable extensions for generic dictionaries, including methods for getting values with a custom comparer and changing the dictionary comparer.
* **EnumerableExtensions**: A set of extension methods for asynchronous enumerables, including methods for converting async enumerable sequences to sets.
* **ReflectionExtensions**: A set of extensions for reflection and common patterns, including methods for getting method parameters, attributes, and static or instance methods.
* **ResourceExtensions**: A set of extension methods for working with embedded resources, including methods for getting resource streams and content as strings.
* **ServiceCollectionExtensions**: A set of extension methods for the `IServiceCollection` interface, including methods for registering accessor types and getting singleton instances from the IOC container.
* **StringTools**: A set of utility methods for string manipulation, including methods for splitting strings into lines and concatenating lines with newline separators.

**Getting Started**

To use the Eliassen.Extensions namespace, simply include the namespace in your project and start using the provided classes and extensions in your code.

**Example Usage**

Here are some examples of using the various classes and extensions in the Eliassen.Extensions namespace:

```csharp
// Example of using StreamExtensions to split a file into chunks
var filename = "example.txt";
var chunkLength = 1024;
var overlap = 128;
await using var fileStream = File.OpenRead(filename);
await foreach (var chunk in fileStream.SplitStreamAsync(chunkLength, overlap))
{
    // Process each chunk asynchronously
}

// Example of using ReflectionExtensions to get method parameters
var methodInfo = typeof(MyClass).GetMethod("MyMethod");
var parameters = methodInfo.GetParametersTypes();

// Example of using ServiceCollectionExtensions to register accessor types
services.AddAccessor<MyClass>();

// Example of using StringTools to split a string into lines
var input = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
var lines = input.SplitBy(20); // Split into lines of max 20 characters
```

**Class Diagrams**

Here are the class diagrams for the Eliassen.Extensions namespace using PlantUML:

```
@startuml
class Accessor<T> {
    +getValue(): T
    +setValue(value: T): void
}
class CommandLine {
    +addParameter(name: string, value: string): void
    +build(): CommandLine
}
class ConfigurationBuilderExtensions {
    +addInMemoryCollection<T>(collection: T): IConfigurationBuilder
}
class FileTools {
    +splitFile(filename: string, chunkLength: int): void
}
class StreamExtensions {
    +createInMemoryCopy(stream: Stream): Stream
    +splitStream(stream: Stream, chunkLength: int): void
}
class StreamJsonDeserializeExtensions {
    +deserializeJson(stream: Stream): T
}
class StreamXmlDeserializeExtensions {
    +deserializeXml(stream: Stream): T
}
class AsyncEnumerableExtensions {
    +toList<T>( enumerable: AsyncEnumerable<T>): List<T>
    +toSet<T>(enumerable: AsyncEnumerable<T>): Set<T>
}
class DictionaryExtensions {
    +getWithCustomComparer<TKey, TValue>(dictionary: Dictionary<TKey, TValue>, key: TKey, comparer: IEqualityComparer<TKey>): TValue
    +changeComparer<TKey, TValue>(dictionary: Dictionary<TKey, TValue>, comparer: IEqualityComparer<TKey>): void
}
class EnumerableExtensions {
    +toList<T>( enumerable: IEnumerable<T>): List<T>
    +toSet<T>(enumerable: IEnumerable<T>): Set<T>
}
class ReflectionExtensions {
    +getParameterTypes(methodInfo: MethodInfo): Type[]
    +getAttribute(attributeType: Type, attribute: object): object
}
class ResourceExtensions {
    +getResourceStream(resourceName: string): Stream
    +getResourceContent(resourceName: