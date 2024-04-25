using Eliassen.Documents.Models;
using System.Threading.Tasks;
using System.Web;

namespace Eliassen.Documents.Depercated;

/// <summary>
/// Represents a content provider for downloading and summarizing content.
/// </summary>
public class ContentProvider : IContentProvider
{
    private readonly IGetContent<ContentReference> _content;
    private readonly IGetSummary<ContentReference> _summary;

    /// <summary>
    /// Initializes a new instance of the <see cref="ContentProvider"/> class with the specified content and summary providers.
    /// </summary>
    /// <param name="content">The provider for retrieving content.</param>
    /// <param name="summary">The provider for retrieving content summaries.</param>
    public ContentProvider(
        IGetContent<ContentReference> content,
        IGetSummary<ContentReference> summary
        )
    {
        _content = content;
        _summary = summary;
    }

    /// <summary>
    /// Downloads the specified content asynchronously.
    /// </summary>
    /// <param name="file">The name of the file to download.</param>
    /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The task result contains the downloaded content reference, or null if the content does not exist.</returns>
    public async Task<ContentReference?> DownloadAsync(string file) =>
        await _content.GetContentAsync(HttpUtility.UrlDecode(file));

    /// <summary>
    /// Retrieves a summary of the specified content asynchronously.
    /// </summary>
    /// <param name="file">The name of the file to summarize.</param>
    /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The task result contains the content summary, or null if the content does not exist.</returns>
    public async Task<ContentReference?> SummaryAsync(string file) =>
        await _summary.GetSummaryAsync(HttpUtility.UrlDecode(file));
}
