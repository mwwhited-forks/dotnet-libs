using Eliassen.Documents.Models;
using System;
using System.Threading.Tasks;

namespace Eliassen.Documents.Depercated;

/// <summary>
/// Represents a provider for content retrieval and summarization.
/// </summary>
[Obsolete]
public interface IContentProvider
{
    //TODO: this should really be based on a collection name being passed in

    /// <summary>
    /// Downloads the content referenced by the specified file.
    /// </summary>
    /// <param name="file">The file to download.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains a reference to the downloaded content, or null if the content could not be downloaded.</returns>
    Task<ContentReference?> DownloadAsync(string file);

    /// <summary>
    /// Generates a summary for the content referenced by the specified file.
    /// </summary>
    /// <param name="file">The file for which to generate a summary.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains a reference to the summarized content, or null if a summary could not be generated.</returns>
    Task<ContentReference?> SummaryAsync(string file);
}
