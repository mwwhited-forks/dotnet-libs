using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Eliassen.EntityFrameworkCore.Qdrant.ValueGeneration.Internal;

public class QdrantSequenceValueGeneratorState : HiLoValueGeneratorState
{

    public QdrantSequenceValueGeneratorState(ISequence sequence)
        : base(sequence.IncrementBy)
    {
        Sequence = sequence;
    }

    public virtual ISequence Sequence { get; }
}
