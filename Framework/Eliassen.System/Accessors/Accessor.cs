using System.Threading;

namespace Eliassen.System.Accessors
{
    /// <inheritdoc/>
    public class Accessor<T> : IAccessor<T>
    {
        private readonly AsyncLocal<T?> _local = new();

        /// <inheritdoc/>
        public T? Value
        {
            get => _local.Value;
            set => _local.Value = value;
        }
    }
}
