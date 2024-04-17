namespace Eliassen.WebApi.Models;

public class GenAiRequestModel
{
    /// <summary>
    /// Gets or sets the prompt details.
    /// </summary>
    public required string PromptDetails { get; set; }

    /// <summary>
    /// Gets or sets the user input.
    /// </summary>
    public required string UserInput { get; set; }

    /// <summary>
    /// Gets or sets the input api key to use.
    /// </summary>
    public string? ApiKey { get; set; }
}
