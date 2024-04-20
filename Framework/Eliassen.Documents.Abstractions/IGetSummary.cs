using System.Threading.Tasks;

namespace Eliassen.Documents;

/// <summary>
/// Represents a provider for retrieving summaries of content of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of content summary to retrieve.</typeparam>
public interface IGetSummary<T>
{
    /// <summary>
    /// Retrieves the summary of content of type <typeparamref name="T"/> associated with the specified file.
    /// </summary>
    /// <param name="file">The file for which to retrieve the summary.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the summary of content of type <typeparamref name="T"/>, or null if the summary could not be retrieved.</returns>
    Task<T?> GetSummaryAsync(string file);
}
