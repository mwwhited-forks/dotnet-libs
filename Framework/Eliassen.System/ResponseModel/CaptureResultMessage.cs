using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Eliassen.System.ResponseModel
{
    /// <inheritdoc/>
    public class CaptureResultMessage : ICaptureResultMessage
    {
        private readonly ConcurrentBag<ResultMessage> _stack = new();

        /// <inheritdoc/>
        public void Publish(params ResultMessage[] resultMessages)
        {
            foreach (var resultMessage in resultMessages)
                _stack.Add(resultMessage);
        }

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

        /// <summary>
        /// Default instance for CaptureResultMessage
        /// </summary>
        public static ICaptureResultMessage Default => _default ??= new CaptureResultMessage();
    }
}
