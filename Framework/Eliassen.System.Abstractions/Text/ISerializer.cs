namespace Nucleus.Dataloader.Cli
{
    public interface ISerializer
    {
        string Serialize(object obj, Type type);
        string Serialize<T>(T obj);
        Task SerializeToAsync(object obj, Type type, Stream stream, CancellationToken cancellationToken = default);
        Task SerializeToAsync<T>(T obj, Stream stream, CancellationToken cancellationToken = default);

        T? Deserialize<T>(Stream stream);
        object? Deserialize(Stream stream, Type type);
        ValueTask<T?> DeserializeToAsync<T>(Stream stream, CancellationToken cancellationToken = default);
        ValueTask<object?> DeserializeToAsync(Stream stream, Type type, CancellationToken cancellationToken = default);

        T? Deserialize<T>(string input);
        object? Deserialize(string input, Type type);

        string ContentType { get; }
    }
}