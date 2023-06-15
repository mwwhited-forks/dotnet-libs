namespace Nucleus.Core.Contracts.Providers
{
    public interface IBlobContentResult
    {
        byte[]? Content { get; }
        string? ContentType { get; }
        string? FileName { get; }
    }
}
