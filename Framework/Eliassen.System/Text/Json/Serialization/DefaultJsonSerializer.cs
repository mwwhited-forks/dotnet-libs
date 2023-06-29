using Eliassen.System.Text.Json.Serialization;
using System;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Nucleus.Dataloader.Cli
{
    public class DefaultJsonSerializer : IJsonSerializer
    {
        public static JsonSerializerOptions DefaultOptions => new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true,
            IgnoreReadOnlyFields = true,
            IgnoreReadOnlyProperties = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };
        public const string DefaultContentType = "text/json";
        public string ContentType => DefaultContentType;

        private JsonSerializerOptions _options;

        public DefaultJsonSerializer(
            JsonSerializerOptions? options = null
            )
        {
            _options = options ?? DefaultOptions;
        }

        public string Serialize<T>(T obj) => JsonSerializer.Serialize(obj, _options);
        public string Serialize(object obj, Type type) => JsonSerializer.Serialize(obj, type, _options);

        public async Task SerializeAsync<T>(T obj, Stream stream, CancellationToken cancellationToken = default) =>
            await JsonSerializer.SerializeAsync(stream, obj, _options, cancellationToken);
        public async Task SerializeAsync(object obj, Type type, Stream stream, CancellationToken cancellationToken = default) =>
            await JsonSerializer.SerializeAsync(stream, obj, _options, cancellationToken);

        public T? Deserialize<T>(Stream stream) => JsonSerializer.Deserialize<T>(stream, _options);
        public object? Deserialize(Stream stream, Type type) => JsonSerializer.Deserialize(stream, type, _options);

        public async ValueTask<T?> DeserializeAsync<T>(Stream stream, CancellationToken cancellationToken = default) =>
            await JsonSerializer.DeserializeAsync<T>(stream, _options, cancellationToken);

        public async ValueTask<object?> DeserializeAsync(Stream stream, Type type, CancellationToken cancellationToken = default) =>
            await JsonSerializer.DeserializeAsync(stream, type, _options, cancellationToken);

        public T? Deserialize<T>(string input) => JsonSerializer.Deserialize<T>(input, _options);
        public object? Deserialize(string input, Type type) => JsonSerializer.Deserialize(input, type, _options);

    }
}