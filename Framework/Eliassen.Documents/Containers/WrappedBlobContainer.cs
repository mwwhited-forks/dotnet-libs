using Eliassen.Documents.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eliassen.Documents.Containers;

public class WrappedBlobContainer : IBlobContainer
{
    private readonly IBlobContainer _wrapped;

    public WrappedBlobContainer(
        IBlobContainer wrapped
        ) => _wrapped = wrapped;

    public Task<ContentReference> GetContentAsync(string path) =>
        _wrapped.GetContentAsync(path);
    public Task<ContentMetaDataReference> GetContentMetaDataAsync(string path) =>
        _wrapped.GetContentMetaDataAsync(path);
    public IQueryable<ContentMetaDataReference> QueryContent() =>
        _wrapped.QueryContent();
    public Task StoreContentAsync(ContentReference reference, IDictionary<string, string>? metadata = null) =>
        _wrapped.StoreContentAsync(reference, metadata);
}

public class WrappedBlobContainer<T> : WrappedBlobContainer, IBlobContainer<T>
{
    public WrappedBlobContainer(IBlobContainerFactory factory) : base(factory.Create<T>()) { }
}
