using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Eliassen.System.ResponseModel;

public class CaptureResultMessage : ICaptureResultMessage
{
    private readonly ConcurrentBag<ResultMessage> _stack = [];

    public void Publish(params ResultMessage[] resultMessages)
    {
        foreach (var resultMessage in resultMessages)
            _stack.Add(resultMessage);
    }

    public IReadOnlyCollection<ResultMessage> Peek() => _stack.ToArray();

    public void Clear() => _stack.Clear();

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
