using Eliassen.Documents.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Eliassen.Documents.Containers;

public interface IBlobContainerProvider : IBlobContainer
{
    string ContainerName { get; set; }

    Task<ContentReference> GetContentAsync(string path);
    Task<ContentMetaDataReference?> GetContentMetaDataAsync(string path);
    Task StoreContentAsync(ContentReference reference, IDictionary<string, string>? metadata = null);
    IQueryable<ContentMetaDataReference> QueryContent();
}
