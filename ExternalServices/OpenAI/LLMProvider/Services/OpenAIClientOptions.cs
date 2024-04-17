
namespace LLMProvider.Services;
public class OpenAIOptions
{
    /// <summary>
    /// Gets or sets the APIKey to be used.
    /// </summary>
    public required string APIKey { get; set; }

    /// <summary>
    /// Gets or sets the deployment model to be used for the text generation.
    /// </summary>
    public required string DeploymentName { get; set; }
}
