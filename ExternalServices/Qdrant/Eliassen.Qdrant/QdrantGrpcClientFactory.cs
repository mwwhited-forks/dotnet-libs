using Microsoft.Extensions.Options;
using Qdrant.Client.Grpc;

namespace Eliassen.Qdrant;

public class QdrantGrpcClientFactory : IQdrantGrpcClientFactory
{
    private readonly IOptions<QdrantOptions> _options;

    public QdrantGrpcClientFactory(IOptions<QdrantOptions> options)
    {
        _options = options;
    }

    public QdrantGrpcClient Create() => new(QdrantChannel.ForAddress(_options.Value.Url));
}
