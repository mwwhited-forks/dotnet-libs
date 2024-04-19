using Eliassen.Documents.Models;

namespace Eliassen.Documents;

public interface IContentProvider
{
    Task<ContentReference?> DownloadAsync(string file);
    Task<ContentReference?> SummaryAsync(string file);
}
