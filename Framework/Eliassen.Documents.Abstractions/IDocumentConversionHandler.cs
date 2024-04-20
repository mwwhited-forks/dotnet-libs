namespace Eliassen.Documents;

/// <summary>
/// Represents a handler for document conversion.
/// </summary>
public interface IDocumentConversionHandler : IDocumentConversion
{
    /// <summary>
    /// Gets the supported source content types for document conversion.
    /// </summary>
    string[] Sources { get; }

    /// <summary>
    /// Determines whether the specified content type is supported as a source for document conversion.
    /// </summary>
    /// <param name="contentType">The content type to check.</param>
    /// <returns>True if the content type is supported; otherwise, false.</returns>
    bool SupportedSource(string contentType);

    /// <summary>
    /// Gets the supported destination content types for document conversion.
    /// </summary>
    string[] Destinations { get; }

    /// <summary>
    /// Determines whether the specified content type is supported as a destination for document conversion.
    /// </summary>
    /// <param name="contentType">The content type to check.</param>
    /// <returns>True if the content type is supported; otherwise, false.</returns>
    bool SupportedDestination(string contentType);
}
