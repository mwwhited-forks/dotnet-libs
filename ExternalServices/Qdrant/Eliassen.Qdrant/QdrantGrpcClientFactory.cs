using Microsoft.Extensions.Options;
using Qdrant.Client.Grpc;

namespace Eliassen.Qdrant;

/// <summary>
/// Factory for creating instances of the Qdrant gRPC client.
/// </summary>
public class QdrantGrpcClientFactory : IQdrantGrpcClientFactory
{
    private readonly IOptions<QdrantOptions> _options;

    /// <summary>
    /// Creates a new instance of the Qdrant gRPC client.
    /// </summary>
    /// <returns>A new instance of the Qdrant gRPC client.</returns>
    public QdrantGrpcClientFactory(IOptions<QdrantOptions> options)
    {
        _options = options;
    }

    /// <summary>
    /// Creates a new instance of the Qdrant gRPC client.
    /// </summary>
    /// <returns>A new instance of the Qdrant gRPC client.</returns>
    public QdrantGrpcClient Create() => new(QdrantChannel.ForAddress(_options.Value.Url));
}
