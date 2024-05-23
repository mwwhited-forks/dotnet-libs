using System;

namespace Eliassen.System.IO;

/// <summary>
/// temp file handle
/// </summary>
public interface ITempFile : IDisposable
{
    /// <summary>
    /// path to temp file
    /// </summary>
    string FilePath { get; }
}
