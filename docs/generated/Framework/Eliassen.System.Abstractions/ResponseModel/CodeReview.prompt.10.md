Review the follow source code as a senior software engineer / solutions architect.   
Suggest changes to coding patterns, methods, structure and class to make the code 
more maintainable.  

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
