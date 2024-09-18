Create documentation for the follow source code. 

The files should be in markdown.
When reasonable include class diagrams, component models and sequence diagrams in Plant UML.
PlantUML blocks should all be identified with "```plantuml" and closed with "```"

## Source Files

```ResultMessage.cs
namespace Eliassen.System.ResponseModel;

/// <summary>
/// additional details about response
/// </summary>
public record ResultMessage
{
    /// <summary>
    /// importance level related to response
    /// </summary>
    public MessageLevels Level { get; init; } = MessageLevels.Information;

    /// <summary>
    /// Simple English message about issue. 
    /// </summary>
    public required string Message { get; init; }

    /// <summary>
    /// unique code that may be used to assist in translating issue
    /// </summary>
    public string? MessageCode { get; init; }

    /// <summary>
    /// Property or path related to this message 
    /// </summary>
    public string? Context { get; init; }

    /// <summary>
    /// additional properties related to response
    /// </summary>
    public object? MetaData { get; init; }
}

```
