namespace Eliassen.System.IO;

public record ContentChunk(
    string Data,
    int Sequence,
    long Start,
    int Length
    )
{
}
