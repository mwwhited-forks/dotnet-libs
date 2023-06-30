using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Eliassen.System.ResponseModel
{
    /// <inheritdoc/>
    public class CaptureResultMessage : ICaptureResultMessage
    {
        private readonly ConcurrentStack<ResultMessage> _stack = new();

        /// <inheritdoc/>
        public void Publish(params ResultMessage[] resultMessage) =>_stack.PushRange(resultMessage);

        /// <inheritdoc/>
        public IReadOnlyCollection<ResultMessage> Peek() => _stack.ToArray();

        /// <inheritdoc/>
        public void Clear() => _stack.Clear();

        /// <inheritdoc/>
        public IReadOnlyCollection<ResultMessage> Capture()
        {
            var captured = _stack.ToArray();
            _stack.Clear();
            return captured;
        }

        private static ICaptureResultMessage? _default;
        public static ICaptureResultMessage Default => _default ??= new CaptureResultMessage();
    }
}
