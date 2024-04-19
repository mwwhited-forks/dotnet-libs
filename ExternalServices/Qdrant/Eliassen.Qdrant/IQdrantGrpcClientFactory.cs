using Qdrant.Client.Grpc;

namespace Eliassen.Qdrant;

public interface IQdrantGrpcClientFactory
{
    QdrantGrpcClient Create();
}
