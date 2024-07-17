namespace Eliassen.GroqCloud;

public record GroqCloudApiClientOptions
{
    public string? ApiKey { get; set; }
    public string Model { get; set; } = "llama3-8b-8192";
}
