namespace Nucleus.Dataloader.Cli
{
    public interface ISerializer
    {
        string Serialize(object? obj, Type type);
        string Serialize<T>(T obj);
        Task SerializeAsync(object? obj, Type type, Stream stream, CancellationToken cancellationToken = default);
        Task SerializeAsync<T>(T obj, Stream stream, CancellationToken cancellationToken = default);

        T? Deserialize<T>(Stream stream);
        object? Deserialize(Stream stream, Type type);
        ValueTask<T?> DeserializeAsync<T>(Stream stream, CancellationToken cancellationToken = default);
        ValueTask<object?> DeserializeAsync(Stream stream, Type type, CancellationToken cancellationToken = default);

        T? Deserialize<T>(string input);
        object? Deserialize(string input, Type type);

        string ContentType { get; }
    }
}