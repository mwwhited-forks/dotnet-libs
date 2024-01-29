namespace Eliassen.WebApi.Models;

public record ClaimModel
{
    public required string Issuer { get; init; }
    public required string Value { get; init; }
    public required string ValueType { get; init; }
    public required string Type { get; init; }
    public required string OriginalIssuer { get; init; }

    public string? SubjectName { get; init; }
    public string? SubjectLabel { get; init; }
    public string? SubjectAuthenticationType { get; init; }
}
