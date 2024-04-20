using System.Threading.Tasks;

namespace Eliassen.Search;

/// <summary>
/// Represents a provider for storing content.
/// </summary>
public interface IStoreContent
{
    /// <summary>
    /// Attempts to store the content associated with the specified file.
    /// </summary>
    /// <param name="full">The full content to store.</param>
    /// <param name="file">The file name associated with the content.</param>
    /// <param name="pathHash">The hash of the file path.</param>
    /// <returns>A task representing the asynchronous operation. The task result indicates whether the content was successfully stored.</returns>
    Task<bool> TryStoreAsync(string full, string file, string pathHash);
}
