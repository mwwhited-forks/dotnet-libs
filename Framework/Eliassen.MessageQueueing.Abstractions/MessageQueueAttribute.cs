namespace Eliassen.MessageQueueing;

/// <summary>
/// Attribute used to mark a class as a message queue handler and provide configuration options.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
public sealed class MessageQueueAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MessageQueueAttribute"/> class with the specified simple name.
    /// </summary>
    /// <param name="simpleName">The simple name used for named targeting in the configuration value.</param>
    public MessageQueueAttribute(string? simpleName)
    {
        SimpleName = simpleName;
    }

    /// <summary>
    /// Gets the simple name used for named targeting in the configuration value.
    /// </summary>
    public string? SimpleName { get; }

    /// <summary>
    /// Gets a unique identifier for this attribute.
    /// </summary>
    public override object TypeId => this;
}