using System;

namespace Nucleus.Core.Contracts.Providers
{
    public interface IBlobContentInfoResult
    {
        string? ContentType { get; }
        string? FileName { get; }
        long? FileSize { get; }
        DateTimeOffset? LastModified { get; }
    }
}
