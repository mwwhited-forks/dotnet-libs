using System.Threading;

namespace Eliassen.System.Accessors;

public class Accessor<T> : IAccessor<T>
{
    private readonly AsyncLocal<T?> _local = new();

    public T? Value
    {
        get => _local.Value;
        set => _local.Value = value;
    }
}
