using Eliassen.Documents.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eliassen.Documents;

public interface IBlobContainer
{
    Task<ContentReference?> GetContentAsync(string path);
    Task<ContentMetaDataReference?> GetContentMetaDataAsync(string path);
    Task StoreContentAsync(ContentReference reference, IDictionary<string, string>? metadata = null, bool overwrite = false);
    Task<bool> StoreContentMetaDataAsync(ContentMetaDataReference reference);
    IQueryable<ContentMetaDataReference> QueryContent();
    Task DeleteContentAsync(string path);
}
public interface IBlobContainer<T> : IBlobContainer
{
}
