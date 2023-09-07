using System.Reflection;

namespace Eliassen.System.ComponentModel
{
    public interface IVersionProvider
    {
        string? Title { get; }
        string? Version { get; }

        string? Description { get; }

        Assembly? Assembly { get; }
    }
}
