using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleus.Core.Persistence.Providers
{
    public interface IBlobContentInfoResult
    {
        string? ContentType { get; }
        string? FileName { get; }
        long? FileSize { get; }
        DateTimeOffset? LastModified { get; }
    }
}
