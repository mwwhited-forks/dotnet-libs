namespace Eliassen.MessageQueueing;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
public sealed class MessageQueueAttribute : Attribute
{
    /// <summary>
    /// Simple name allows for named targeting for the configuration value
    /// </summary>
    public string? SimpleName { get; set; }

    public override object TypeId => this;
}
