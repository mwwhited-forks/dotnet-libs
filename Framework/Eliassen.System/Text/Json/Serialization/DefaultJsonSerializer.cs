using System;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Eliassen.System.Text.Json.Serialization
{
    /// <summary>
    /// Default serializer for JSON
    /// </summary>
    public class DefaultJsonSerializer : IJsonSerializer
    {
        /// <inheritdoc />
        public static JsonSerializerOptions DefaultOptions => new()
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true,
            IgnoreReadOnlyFields = true,
            IgnoreReadOnlyProperties = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };
        /// <inheritdoc />
        public const string DefaultContentType = "text/json";
        /// <inheritdoc />
        public string ContentType => DefaultContentType;

        private readonly JsonSerializerOptions _options;

        /// <inheritdoc />
        public DefaultJsonSerializer(
            JsonSerializerOptions? options = null
            )
        {
            _options = options ?? DefaultOptions;
        }

        /// <inheritdoc />
        public string Serialize<T>(T obj) => Serialize(obj, typeof(T));
        /// <inheritdoc />
        public string Serialize(object? obj, Type type) =>
            JsonSerializer.Serialize(obj, type, _options);

        /// <inheritdoc />
        public Task SerializeAsync<T>(T obj, Stream stream, CancellationToken cancellationToken = default) =>
             SerializeAsync(obj, typeof(T), stream, cancellationToken);
        /// <inheritdoc />
        public async Task SerializeAsync(object? obj, Type type, Stream stream, CancellationToken cancellationToken = default) =>
            await JsonSerializer.SerializeAsync(stream, obj, _options, cancellationToken);

        /// <inheritdoc />
        public T? Deserialize<T>(Stream stream) => (T?)Deserialize(stream, typeof(T));
        /// <inheritdoc />
        public object? Deserialize(Stream stream, Type type) =>
            JsonSerializer.Deserialize(stream, type, _options);

        /// <inheritdoc />
        public async ValueTask<T?> DeserializeAsync<T>(Stream stream, CancellationToken cancellationToken = default) => (T?)await DeserializeAsync(stream, typeof(T), cancellationToken);
        /// <inheritdoc />
        public async ValueTask<object?> DeserializeAsync(Stream stream, Type type, CancellationToken cancellationToken = default) =>
            await JsonSerializer.DeserializeAsync(stream, type, _options, cancellationToken);

        /// <inheritdoc />
        public T? Deserialize<T>(string input) => (T?)Deserialize(input, typeof(T));
        /// <inheritdoc />
        public object? Deserialize(string input, Type type) =>
            JsonSerializer.Deserialize(input, type, _options);

        /// <summary>
        /// Use the configured property naming policy to change provided value
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public string AsPropertyName(string propertyName) =>
            (_options.PropertyNamingPolicy ?? JsonNamingPolicy.CamelCase).ConvertName(propertyName);
    }
}