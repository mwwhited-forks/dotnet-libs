using System.Collections.Generic;

namespace Eliassen.WebApi.Models;

/// <summary>
/// Represents the model used for generating AI responses.
/// </summary>
public class GenAiContextRequestModel
{
    /// <summary>
    /// Gets or sets the prompt details.
    /// </summary>
    public required List<string> PromptDetails { get; set; }

    /// <summary>
    /// Gets or sets the user input.
    /// </summary>
    public required List<string> UserInput { get; set; }
}
