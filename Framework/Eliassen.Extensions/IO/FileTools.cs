using Eliassen.System.IO;
using System.Collections.Generic;
using System.IO;

namespace Eliassen.Extensions.IO;

/// <summary>
/// Provides methods for working with files.
/// </summary>
public static class FileTools
{
    /// <summary>
    /// The default length of context used when splitting files.
    /// </summary>
    public const int DefaultContextLength = 4096;

    /// <summary>
    /// The default overlap between chunks when splitting files.
    /// </summary>
    public const int DefaultOverlap = 0;

    /// <summary>
    /// Asynchronously splits a file into chunks of specified length and overlap.
    /// </summary>
    /// <param name="filename">The path of the file to split.</param>
    /// <param name="contextLength">The length of each chunk.</param>
    /// <param name="overlap">The overlap between consecutive chunks.</param>
    /// <returns>An asynchronous enumerable sequence of <see cref="ContentChunk"/> representing the chunks of the file.</returns>
    public static async IAsyncEnumerable<ContentChunk> SplitFileAsync(
        string filename,
        int contextLength = DefaultContextLength,
        int overlap = DefaultOverlap
        )
    {
        using var file = File.OpenRead(filename);
        using var reader = new StreamReader(file);

        var buffer = new char[contextLength];

        int sequence = 0;
        while (file.Position < file.Length)
        {
            var start = file.Position;
            var read = await reader.ReadBlockAsync(buffer, 0, contextLength);
            if (read > 0)
                yield return new(new string(buffer, 0, read), sequence, start, read);
            else if (read < contextLength)
                break;
            file.Position -= overlap;
            sequence++;
        }
    }
}
