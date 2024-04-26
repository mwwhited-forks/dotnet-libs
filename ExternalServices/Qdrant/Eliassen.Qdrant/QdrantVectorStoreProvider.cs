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

        return Array.Empty<string>();  //TODO: want to return IDs 
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


    ///// <summary>
    ///// Stores content in the semantic store asynchronously.
    ///// </summary>
    ///// <param name="full">The full content.</param>
    ///// <param name="file">The file name.</param>
    ///// <param name="pathHash">The path hash.</param>
    ///// <returns>A task representing the asynchronous operation. Returns true if the content is stored successfully, otherwise false.</returns>
    //public async Task<bool> TryStoreAsync(string full, string file, string pathHash)
    //{
    //    if ((await _vectoreStore.Points.ScrollAsync(new()
    //    {
    //        CollectionName = _collectionName,
    //        Limit = 1,
    //        Filter = new Filter
    //        {
    //            Must =
    //                {
    //                    new Condition
    //                    {
    //                        Field = new FieldCondition
    //                        {
    //                            Key= "PathHash",
    //                            Match = new Match
    //                            {
    //                                Text = pathHash,
    //                            }
    //                        }
    //                    },
    //                    new Condition
    //                    {
    //                        Field = new FieldCondition
    //                        {
    //                            Key= "ContentType",
    //                            Match = new Match
    //                            {
    //                                Text = _forSummary? "Summary": "Content",
    //                            }
    //                        }
    //                    }
    //                }
    //        }
    //    })).Result.Count != 0)
    //    {
    //        return false;
    //    }

    //    // check if file indexed in vector store
    //    //  if not chunk file and index with embeddings 

    //    Console.WriteLine($"embedding and index -> {file}");

    //    var embeddings = new Collection<PointStruct>();

    //    // generate embedding for file name
    //    if (!_forSummary)
    //    {
    //        var value = await _embedding.GetEmbeddingAsync(file);
    //        embeddings.Add(new PointStruct
    //        {
    //            Id = new PointId { Uuid = Guid.NewGuid().ToString() },
    //            Payload = {
    //                        ["File"]= file,
    //                        ["OriginalFile"]= full,
    //                        ["PathHash"] = pathHash,

    //                        ["FileName"]= Path.GetFileNameWithoutExtension(file),
    //                        ["Directory"]= Path.GetDirectoryName(file)??"",
    //                        ["Extensions"]= Path.GetExtension(file),

    //                        ["Content"] = file,
    //                        ["ContentType"] = "FileName",

    //                        ["Sequence"] = 0,
    //                        ["Start"] = 0,
    //                        ["Length"] = file.Length,

    //                    },
    //            Vectors = new Vectors()
    //            {
    //                Vector = value
    //            },
    //        });
    //    }

    //    //break content and generate embeddings
    //    await foreach (var chunk in FileTools.SplitFileAsync(full, _embedding.Length, 0))
    //    {
    //        var value = await _embedding.GetEmbeddingAsync(chunk.Data);
    //        embeddings.Add(new PointStruct
    //        {
    //            Id = new PointId { Uuid = Guid.NewGuid().ToString() },
    //            Payload = {
    //                        ["File"]= file,
    //                        ["OriginalFile"]= full,
    //                        ["PathHash"] = pathHash,

    //                        ["FileName"]= Path.GetFileNameWithoutExtension(file),
    //                        ["Directory"]= Path.GetDirectoryName(file)??"",
    //                        ["Extensions"]= Path.GetExtension(file),

    //                        ["Content"] = chunk.Data,
    //                        ["ContentType"] =_forSummary? "Summary": "Content",

    //                        [nameof(chunk.Sequence)] = chunk.Sequence,
    //                        [nameof(chunk.Start)] = chunk.Start,
    //                        [nameof(chunk.Length)] = chunk.Length,
    //                    },
    //            Vectors = new Vectors()
    //            {
    //                Vector = value
    //            },
    //        });
    //    }

    //    await _vectoreStore.Points.UpsertAsync(new()
    //    {
    //        CollectionName = _collectionName,
    //        Points = { embeddings },
    //    });

    //    return true;
    //}
}
