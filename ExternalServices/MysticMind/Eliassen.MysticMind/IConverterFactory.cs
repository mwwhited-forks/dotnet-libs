using ReverseMarkdown;

namespace Eliassen.MysticMind;

/// <summary>
/// Interface for a factory that creates converters.
/// </summary>
public interface IConverterFactory
{
    /// <summary>
    /// Builds a new converter.
    /// </summary>
    /// <returns>A new instance of the converter.</returns>
    Converter Build();
}
