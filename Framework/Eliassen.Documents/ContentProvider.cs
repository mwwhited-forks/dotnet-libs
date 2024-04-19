using Eliassen.Documents.Models;
using System.Threading.Tasks;
using System.Web;

namespace Eliassen.Documents;

public class ContentProvider : IContentProvider
{
    private readonly IGetContent<ContentReference> _content;
    private readonly IGetSummary<ContentReference> _summary;

    public ContentProvider(
        IGetContent<ContentReference> content,
        IGetSummary<ContentReference> summary
        )
    {
        _content = content;
        _summary = summary;
    }

    public async Task<ContentReference?> DownloadAsync(string file) =>
        await _content.GetContentAsync(HttpUtility.UrlDecode(file));

    public async Task<ContentReference?> SummaryAsync(string file) =>
        await _summary.GetSummaryAsync(HttpUtility.UrlDecode(file));
}
