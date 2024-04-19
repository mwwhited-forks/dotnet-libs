namespace Eliassen.Search.Models;

public record ContentChunk(
    string Data,
    int Sequence,
    long Start,
    int Length
    )
{
}
