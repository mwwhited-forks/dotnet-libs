﻿using System.Collections.Concurrent;

namespace Eliassen.System.ResponseModel;

/// <summary>
/// Implementation of <see cref="ICaptureResultMessage"/> for capturing and publishing result messages.
/// </summary>
public class CaptureResultMessage : ICaptureResultMessage
{
    private readonly ConcurrentBag<ResultMessage> _stack = [];

    /// <summary>
    /// Publishes result messages to the capture stack.
    /// </summary>
    /// <param name="resultMessages">The result messages to be published.</param>
    public void Publish(params ResultMessage[] resultMessages)
    {
        foreach (var resultMessage in resultMessages)
            _stack.Add(resultMessage);
    }

    /// <summary>
    /// Peeks at the current contents of the capture stack without clearing it.
    /// </summary>
    /// <returns>The current result messages in the capture stack.</returns>
    public IReadOnlyCollection<ResultMessage> Peek() => _stack.ToArray();

    /// <summary>
    /// Gets the default instance of <see cref="ICaptureResultMessage"/>.
    /// </summary>
    public void Clear() => _stack.Clear();

    /// <summary>
    /// Gets the default instance of <see cref="ICaptureResultMessage"/>.
    /// </summary>
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