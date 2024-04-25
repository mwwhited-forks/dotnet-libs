using System;
using System.Threading.Tasks;

namespace Eliassen.Search;

/// <summary>
/// Represents a provider for summarizing content.
/// </summary>
[Obsolete]
public interface ISummarizeContent
{
    /// <summary>
    /// Generates a summary for the specified input content asynchronously.
    /// </summary>
    /// <param name="input">The input content for which to generate the summary.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the generated summary.</returns>
    Task<string> GenerateSummaryAsync(string input);
}
