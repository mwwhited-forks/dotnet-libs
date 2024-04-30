
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Eliassen.EntityFrameworkCore.Qdrant.ValueGeneration.Internal;

public interface IQdrantValueGeneratorCache : IValueGeneratorCache
{
    QdrantSequenceValueGeneratorState GetOrAddSequenceState(
        IProperty property,
        IRelationalConnection connection);
}
