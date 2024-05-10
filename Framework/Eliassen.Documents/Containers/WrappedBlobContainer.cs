using Eliassen.Documents.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eliassen.Documents.Containers;

/// <summary>
/// Represents a wrapper for a blob container.
/// </summary>
public class WrappedBlobContainer : IBlobContainer
{
    private readonly IBlobContainer _wrapped;

    /// <summary>
    /// Initializes a new instance of the <see cref="WrappedBlobContainer"/> class.
    /// </summary>
    /// <param name="wrapped">The blob container to wrap.</param>
    public WrappedBlobContainer(
        IBlobContainer wrapped
        ) => _wrapped = wrapped;

    /// <summary>
    /// Deletes content asynchronously.
    /// </summary>
    /// <param name="path">The path to the content to be deleted.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task DeleteContentAsync(string path) =>
        _wrapped.DeleteContentAsync(path);

    /// <summary>
    /// Retrieves content asynchronously.
    /// </summary>
    /// <param name="path">The path to the content to be retrieved.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the reference to the content.</returns>
    public Task<ContentReference?> GetContentAsync(string path) =>
        _wrapped.GetContentAsync(path);

    /// <summary>
    /// Retrieves content metadata asynchronously.
    /// </summary>
    /// <param name="path">The path to the content.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the metadata reference.</returns>
    public Task<ContentMetaDataReference?> GetContentMetaDataAsync(string path) =>
        _wrapped.GetContentMetaDataAsync(path);

    /// <summary>
    /// Queries content metadata.
    /// </summary>
    /// <returns>An IQueryable representing the content metadata.</returns>
    public IQueryable<ContentMetaDataReference> QueryContent() =>
        _wrapped.QueryContent();

    /// <summary>
    /// Stores content asynchronously.
    /// </summary>
    /// <param name="reference">The reference to the content.</param>
    /// <param name="metadata">The metadata associated with the content.</param>
    /// <param name="overwrite">Determines whether to overwrite existing content with the same name.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task StoreContentAsync(
        ContentReference reference,
        Dictionary<string, string>? metadata = null,
        bool overwrite = false
        ) =>
        _wrapped.StoreContentAsync(reference, metadata, overwrite);

    /// <summary>
    /// Stores content metadata asynchronously.
    /// </summary>
    /// <param name="reference">The reference to the content metadata.</param>
    /// <returns>A task representing the asynchronous operation. The task result indicates whether the operation was successful.</returns>
    public Task<bool> StoreContentMetaDataAsync(ContentMetaDataReference reference) =>
        _wrapped.StoreContentMetaDataAsync(reference);
}

/// <summary>
/// Represents a typed wrapper for a blob container.
/// </summary>
/// <typeparam name="T">The type of objects stored in the blob container.</typeparam>
public class WrappedBlobContainer<T> : WrappedBlobContainer, IBlobContainer<T>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="WrappedBlobContainer{T}"/> class.
    /// </summary>
    /// <param name="factory">The factory used to create the wrapped blob container.</param>
    public WrappedBlobContainer(IBlobContainerFactory factory) : base(factory.Create<T>()) { }
}
