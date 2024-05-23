﻿namespace Eliassen.AI.Models;

/// <summary>
/// Represents a completion response.
/// </summary>
public record CompletionResponse
{
    /// <summary>
    /// Gets or sets the context for the completion response.
    /// </summary>
    public required long[] Context { get; init; }

    /// <summary>
    /// Gets or sets the response generated by the completion process.
    /// </summary>
    public required string Response { get; init; }
}