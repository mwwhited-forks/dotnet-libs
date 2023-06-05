using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Eliassen.System.IO
{
    public static class StreamExtensions
    {
        public static async ValueTask<T?> AsJsonAsync<T>(this Stream? stream, JsonSerializerOptions? options = default) =>
            stream switch
            {
                null => default,
                _ => await JsonSerializer.DeserializeAsync<T>(stream, options)
            };

        public static T? AsJson<T>(this Stream? stream, JsonSerializerOptions? options = default) =>
            stream switch
            {
                null => default,
                _ => JsonSerializer.Deserialize<T>(stream, options)
            };

        public static async ValueTask<object?> AsJsonAsync(this Stream? stream, Type type, JsonSerializerOptions? options = default) =>
            stream switch
            {
                null => default,
                _ => await JsonSerializer.DeserializeAsync(stream, type, options)
            };

        public static object? AsJson(this Stream? stream, Type type, JsonSerializerOptions? options = default) =>
            stream switch
            {
                null => default,
                _ => JsonSerializer.Deserialize(stream, type, options)
            };

        public static ValueTask<T?> AsXmlAsync<T>(this Stream? stream, params Type[] extraTypes) =>
            ValueTask.FromResult(stream switch
            {
                null => default,
                _ => (T?)new XmlSerializer(typeof(T), extraTypes).Deserialize(stream)
            });

        public static T? AsXml<T>(this Stream? stream, params Type[] extraTypes) =>
            stream switch
            {
                null => default,
                _ => (T?)new XmlSerializer(typeof(T), extraTypes).Deserialize(stream)
            };

        public static ValueTask<object?> AsXmlAsync(this Stream? stream, Type type, params Type[] extraTypes) =>
             ValueTask.FromResult(stream switch
             {
                 null => default,
                 _ => new XmlSerializer(type, extraTypes).Deserialize(stream)
             });

        public static object? AsXml(this Stream? stream, Type type, params Type[] extraTypes) =>
             stream switch
             {
                 null => default,
                 _ => new XmlSerializer(type, extraTypes).Deserialize(stream)
             };

    }
}
