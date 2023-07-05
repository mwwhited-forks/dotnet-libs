using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Eliassen.System.Text.Xml.Serialization;

//TODO: finish this serializer

/// <inheritdoc />
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

    /// <inheritdoc />
    public DefaultXmlSerializer(
        // JsonSerializerOptions? options = null
        )
    {
        //_options = options ?? DefaultOptions;
    }

    /// <inheritdoc />
    public const string DefaultContentType = "text/xml";
    /// <inheritdoc />
    public string ContentType => DefaultContentType;

    /// <inheritdoc />
    public T? Deserialize<T>(Stream stream) =>
        (T?)new XmlSerializer(typeof(T)).Deserialize(stream);

    /// <inheritdoc />
    public object? Deserialize(Stream stream, Type type) =>
        new XmlSerializer(type).Deserialize(stream);

    /// <inheritdoc />
    public T? Deserialize<T>(string input)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public object? Deserialize(string input, Type type)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public ValueTask<T?> DeserializeAsync<T>(Stream stream, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public ValueTask<object?> DeserializeAsync(Stream stream, Type type, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public string Serialize(object? obj, Type type)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public string Serialize<T>(T obj)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task SerializeAsync(object? obj, Type type, Stream stream, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
    
    /// <inheritdoc />
    public Task SerializeAsync<T>(T obj, Stream stream, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}