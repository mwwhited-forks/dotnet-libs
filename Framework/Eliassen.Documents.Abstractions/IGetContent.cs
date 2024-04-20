using System.Threading.Tasks;

namespace Eliassen.Documents;

/// <summary>
/// Represents a provider for retrieving content of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of content to retrieve.</typeparam>
public interface IGetContent<T>
{
    /// <summary>
    /// Retrieves the content of type <typeparamref name="T"/> associated with the specified file.
    /// </summary>
    /// <param name="file">The file for which to retrieve the content.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the content of type <typeparamref name="T"/>, or null if the content could not be retrieved.</returns>
    Task<T?> GetContentAsync(string file);
}
