using Eliassen.System.ComponentModel;
using Eliassen.System.Text.Json.Serialization;
using System.Text.Json.Serialization;

namespace Eliassen.System.ResponseModel;

[JsonConverter(typeof(JsonStringEnumConverterEx<MessageLevels>))]
public enum MessageLevels
{
    [EnumValue("trace")]
    Trace,
    [EnumValue("debug")]
    Debug,
    [EnumValue("info")]
    Information,
    [EnumValue("warning")]
    Warning,
    [EnumValue("error")]
    Error,
    [EnumValue("fatal")]
    Critical,
    [EnumValue("unknown")]
    None,
}
