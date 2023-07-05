using System;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Eliassen.System.Text.Json.Serialization
{
    public class DefaultJsonSerializer : IJsonSerializer
    {
        public static JsonSerializerOptions DefaultOptions => new()
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true,
            IgnoreReadOnlyFields = true,
            IgnoreReadOnlyProperties = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };
        public const string DefaultContentType = "text/json";
        public string ContentType => DefaultContentType;

        private readonly JsonSerializerOptions _options;

        public DefaultJsonSerializer(
            JsonSerializerOptions? options = null
            )
        {
            _options = options ?? DefaultOptions;
        }

        public string Serialize<T>(T obj) => Serialize(obj, typeof(T));
        public string Serialize(object obj, Type type) =>
            JsonSerializer.Serialize(obj, type, _options);

        public Task SerializeAsync<T>(T obj, Stream stream, CancellationToken cancellationToken = default) =>
             SerializeAsync(obj, typeof(T), stream, cancellationToken);
        public async Task SerializeAsync(object obj, Type type, Stream stream, CancellationToken cancellationToken = default) =>
            await JsonSerializer.SerializeAsync(stream, obj, _options, cancellationToken);

        public T? Deserialize<T>(Stream stream) => (T?)Deserialize(stream, typeof(T));
        public object? Deserialize(Stream stream, Type type) =>
            JsonSerializer.Deserialize(stream, type, _options);

        public async ValueTask<T?> DeserializeAsync<T>(Stream stream, CancellationToken cancellationToken = default) => (T?)await DeserializeAsync(stream, typeof(T), cancellationToken);
        public async ValueTask<object?> DeserializeAsync(Stream stream, Type type, CancellationToken cancellationToken = default) =>
            await JsonSerializer.DeserializeAsync(stream, type, _options, cancellationToken);

        public T? Deserialize<T>(string input) => (T?)Deserialize(input, typeof(T));
        public object? Deserialize(string input, Type type) =>
            JsonSerializer.Deserialize(input, type, _options);
    }
}