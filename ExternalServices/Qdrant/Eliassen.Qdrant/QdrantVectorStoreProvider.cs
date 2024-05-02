using Eliassen.Search.Models;
using Eliassen.Search.Semantic;
using Google.Protobuf.Collections;
using Qdrant.Client.Grpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eliassen.Qdrant;

/// <summary>
/// Provider for using Qdrant as a vector store.
/// </summary>
public class QdrantVectorStoreProvider : IVectorStoreProvider
{
    private readonly QdrantGrpcClient _client;
    private readonly string _collectionName = "keys";

    /// <summary>
    /// current container name
    /// </summary>
    public string ContainerName { get; set; }

    /// <summary>
    /// constructor for QdrantVectorStoreProvider
    /// </summary>
    /// <param name="client">instance of client</param>
    /// <param name="containerName">name of container</param>
    public QdrantVectorStoreProvider(
        QdrantGrpcClient client,
        string containerName
        )
    {
        _client = client;
        ContainerName = containerName;
    }

    //TODO: this should be done a different way
    private async Task EnsureCollectionExistsAsync(int vectorLength)
    {
        if (!(await _client.Collections.CollectionExistsAsync(new()
        {
            CollectionName = _collectionName,
        })).Result.Exists)
        {
            await _client.Collections.CreateAsync(new()
            {
                CollectionName = _collectionName,

                VectorsConfig = new()
                {
                    Params = new()
                    {
                        Size = (ulong)vectorLength,
                        Distance = Distance.Cosine, //TODO: these are configs or redefined
                    },
                }
            });
        }
    }

    /// <summary>
    /// Gets or sets the name of the container.
    /// </summary>
    public async Task<string[]> StoreVectorsAsync(IEnumerable<float[]> embeddings, Dictionary<string, object> metadata)
    {
        await EnsureCollectionExistsAsync(embeddings.First().Length); //TODO: do this better!

        //TODO: clean this up!
        var map = new MapField<string, Value>();
        foreach (var data in metadata)
        {
            var value = Convert(data.Value);
            if (value != null)
                map[data.Key] = value;
        }

        var points = from embedding in embeddings
                     select new PointStruct
                     {
                         Id = new PointId { Uuid = Guid.NewGuid().ToString() },
                         Payload =
                         {
                              map
                         },
                         Vectors = new Vectors()
                         {
                             Vector = embedding
                         },
                     };

        var response = await _client.Points.UpsertAsync(new()
        {
            CollectionName = _collectionName,
            Points = { points },
        });

        return [];  //TODO: want to return IDs 
    }

    private Value? Convert(object value) =>
         value switch
         {
             null => null,

             string str => new Value(str),
             string[] str => new Value(str),

             double str => new Value(str),
             float str => new Value(str),

             int str => new Value(str),
             long str => new Value(str),
             short str => new Value(str),
             byte str => new Value(str),

             uint str => new Value(str),
             ulong str => new Value(str),
             ushort str => new Value(str),
             sbyte str => new Value(str),

             _ when value.GetType().IsValueType => new Value(value.ToString() ?? ""),

             _ => throw new NotSupportedException($"{value.GetType()}"),
         };

    private object? Convert(Value value) =>
        value.KindCase switch
        {
            Value.KindOneofCase.BoolValue => value.BoolValue,
            Value.KindOneofCase.StringValue => value.StringValue,
            Value.KindOneofCase.IntegerValue => value.IntegerValue,
            Value.KindOneofCase.DoubleValue => value.DoubleValue,
            Value.KindOneofCase.ListValue => value.ListValue.Values, //TODO: fix this?
            Value.KindOneofCase.NullValue => null,
            Value.KindOneofCase.None => null,
            Value.KindOneofCase.StructValue => value.StructValue, //TODO: fix this?
            _ => throw new NotSupportedException($"{value.KindCase}"),
        };

    private Dictionary<string, object> Convert(MapField<string, Value> values)
    {
        var dict = new Dictionary<string, object>();
        foreach (var item in values)
        {
            var value = Convert(item.Value);
            if (value != null)
                dict.Add(item.Key, value);
        }
        return dict;
    }

    private SearchResultModel Convert(ScoredPoint point) =>
        new()
        {
            Score = point.Score,
            ItemId = point.Id.HasUuid ? point.Id.Uuid : point.Id.Num.ToString(),
            MetaData = Convert(point.Payload),
        };

    private SearchResultModel Convert(RetrievedPoint point) =>
        new()
        {
            Score = 0.0f,
            ItemId = point.Id.HasUuid ? point.Id.Uuid : point.Id.Num.ToString(),
            MetaData = Convert(point.Payload),
        };

    /// <summary>
    /// Finds nearest neighbors for a given vector.
    /// </summary>
    /// <returns>An asynchronous enumerable collection of search results representing nearest neighbors.</returns>
    public async IAsyncEnumerable<SearchResultModel> ListAsync()
    {
        var results = await _client.Points.ScrollAsync(new()
        {
            CollectionName = _collectionName,
            Limit = (uint)1000,
            WithPayload = true,
            // WithVectors = true,
        });
        foreach (var item in results.Result)
            yield return Convert(item);
    }

    /// <summary>
    /// Finds nearest neighbors for a given vector.
    /// </summary>
    /// <param name="find">The vector to search for neighbors.</param>
    /// <returns>An asynchronous enumerable collection of search results representing nearest neighbors.</returns>
    public async IAsyncEnumerable<SearchResultModel> FindNeighborsAsync(float[] find)
    {
        var results = await _client.Points.SearchAsync(new()
        {
            CollectionName = _collectionName,
            Limit = (uint)1000,
            Vector = { find },
            WithPayload = true,
            //  WithVectors = true,
        });
        foreach (var item in results.Result)
            yield return Convert(item);
    }

    /// <summary>
    /// Finds nearest neighbors for a given vector, grouped by a specified field.
    /// </summary>
    /// <param name="find">The vector to search for neighbors.</param>
    /// <param name="groupBy">The field to group the results by.</param>
    /// <returns>An asynchronous enumerable collection of search results representing nearest neighbors grouped by the specified field.</returns>
    public async IAsyncEnumerable<SearchResultModel> FindNeighborsAsync(float[] find, string groupBy)
    {
        var results = await _client.Points.SearchGroupsAsync(new()
        {
            CollectionName = _collectionName,
            Limit = (uint)1000,
            Vector = { find },
            WithPayload = true,
            // WithVectors = true,

            GroupBy = groupBy,
            GroupSize = 1,
        });
        foreach (var item in results.Result.Groups.SelectMany(h => h.Hits))
            yield return Convert(item);
    }
}
