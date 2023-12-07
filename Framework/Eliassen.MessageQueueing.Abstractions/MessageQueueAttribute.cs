namespace Eliassen.MessageQueueing;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
public sealed class MessageQueueAttribute : Attribute
{
    public MessageQueueAttribute(string? simpleName)
    {
        SimpleName = simpleName;
    }

    /// <summary>
    /// Simple name allows for named targeting for the configuration value
    /// </summary>
    public string? SimpleName { get;  }

    public override object TypeId => this;
}
