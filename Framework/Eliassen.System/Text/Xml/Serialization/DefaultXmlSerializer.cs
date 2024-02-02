using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Eliassen.System.Text.Xml.Serialization;

#warning TODO: finish this serializer

/// <summary>
/// Default XmlSerializer, 
/// </summary>
public class DefaultXmlSerializer : IXmlSerializer
{
    //public static JsonSerializerOptions DefaultOptions => new JsonSerializerOptions
    //{
    //    WriteIndented = true,
    //    PropertyNameCaseInsensitive = true,
    //    IgnoreReadOnlyFields = true,
    //    IgnoreReadOnlyProperties = true,
    //    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    //};
    //private JsonSerializerOptions _options;

    /// <summary>
    /// Initializes a new instance of the <see cref="DefaultXmlSerializer"/> class.
    /// </summary>
    // <param name="options">JSON serialization options (optional).</param>
    public DefaultXmlSerializer(
    // JsonSerializerOptions? options = null
    )
    {
        //_options = options ?? DefaultOptions;
    }

    /// <summary>
    /// Gets the default content type for XML serialization.
    /// </summary>
    public const string DefaultContentType = "text/xml";

    /// <summary>
    /// Gets the content type used for XML serialization.
    /// </summary>
    public string ContentType => DefaultContentType;

    /// <summary>
    /// convert stream into object
    /// </summary>
    /// <typeparam name="T">template model to deserialize</typeparam>
    /// <param name="stream"></param>
    /// <returns></returns>
    public T? Deserialize<T>(Stream stream) =>
        (T?)new XmlSerializer(typeof(T)).Deserialize(stream);

    /// <summary>
    /// convert stream into object
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="type">template model to deserialize</param>
    /// <returns></returns>
    public object? Deserialize(Stream stream, Type type) =>
        new XmlSerializer(type).Deserialize(stream);

    /// <summary>
    /// convert stream into object
    /// </summary>
    /// <typeparam name="T">template model to deserialize</typeparam>
    /// <param name="input"></param>
    /// <returns></returns>
    public T? Deserialize<T>(string input) => throw new NotImplementedException();

    /// <summary>
    /// convert stream into object
    /// </summary>
    /// <param name="input"></param>
    /// <param name="type">template model to deserialize</param>
    /// <returns></returns>
    public object? Deserialize(string input, Type type) => throw new NotImplementedException();

    /// <summary>
    /// convert stream into object
    /// </summary>
    /// <typeparam name="T">template model to deserialize</typeparam>
    /// <param name="stream"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<T?> DeserializeAsync<T>(Stream stream, CancellationToken cancellationToken = default) => throw new NotImplementedException();

    /// <summary>
    /// convert stream into object
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="type">template model to deserialize</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public ValueTask<object?> DeserializeAsync(Stream stream, Type type, CancellationToken cancellationToken = default) => throw new NotImplementedException();

    /// <summary>
    /// convert the object based on the type definition
    /// </summary>
    /// <param name="obj">object to serialize</param>
    /// <param name="type">template model to serialize</param>
    /// <returns></returns>
    public string Serialize(object? obj, Type type) => throw new NotImplementedException();

    /// <summary>
    /// convert the object based on the type definition
    /// </summary>
    /// <typeparam name="T">template model to serialize</typeparam>
    /// <param name="obj">object to serialize</param>
    /// <returns></returns>
    public string Serialize<T>(T obj) => throw new NotImplementedException();

    /// <summary>
    /// convert the object based on the type definition
    /// </summary>
    /// <param name="obj">object to serialize</param>
    /// <param name="type">template model to serialize</param>
    /// <param name="stream"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task SerializeAsync(object? obj, Type type, Stream stream, CancellationToken cancellationToken = default) => throw new NotImplementedException();

    /// <summary>
    /// convert the object based on the type definition
    /// </summary>
    /// <param name="obj">object to serialize</param>
    /// <param name="stream"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task SerializeAsync<T>(T obj, Stream stream, CancellationToken cancellationToken = default) => throw new NotImplementedException();
}
