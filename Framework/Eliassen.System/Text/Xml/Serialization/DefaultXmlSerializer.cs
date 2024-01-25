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


    public DefaultXmlSerializer(
        // JsonSerializerOptions? options = null
        )
    {
        //_options = options ?? DefaultOptions;
    }


    public const string DefaultContentType = "text/xml";

    public string ContentType => DefaultContentType;


    public T? Deserialize<T>(Stream stream) =>
        (T?)new XmlSerializer(typeof(T)).Deserialize(stream);


    public object? Deserialize(Stream stream, Type type) =>
        new XmlSerializer(type).Deserialize(stream);


    public T? Deserialize<T>(string input) => throw new NotImplementedException();


    public object? Deserialize(string input, Type type) => throw new NotImplementedException();


    public ValueTask<T?> DeserializeAsync<T>(Stream stream, CancellationToken cancellationToken = default) => throw new NotImplementedException();


    public ValueTask<object?> DeserializeAsync(Stream stream, Type type, CancellationToken cancellationToken = default) => throw new NotImplementedException();


    public string Serialize(object? obj, Type type) => throw new NotImplementedException();


    public string Serialize<T>(T obj) => throw new NotImplementedException();


    public Task SerializeAsync(object? obj, Type type, Stream stream, CancellationToken cancellationToken = default) => throw new NotImplementedException();


    public Task SerializeAsync<T>(T obj, Stream stream, CancellationToken cancellationToken = default) => throw new NotImplementedException();
}
