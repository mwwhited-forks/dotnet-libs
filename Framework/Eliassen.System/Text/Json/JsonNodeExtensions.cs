using Eliassen.System.Text.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Xml.Linq;

namespace Eliassen.System.Text.Json;

/// <summary>
/// shared extension methods for System.Text.Json
/// </summary>
public static class JsonNodeExtensions
{
    public static XFragment? ToXFragment(this JsonObject? json, string? rootName = default) =>
        json switch
        {
            null => null,
            _ => new XFragment(new XElement(rootName ?? "x", ToXNodesInternal(json)))
        };
    public static XFragment? ToXFragment(this JsonArray? json, string? rootName = default) =>
        json switch
        {
            null => null,
            _ => new XFragment(new XElement(rootName ?? "x", ToXNodesInternal(json)))
        };

    private static IEnumerable<object> ToXNodesInternal(IEnumerable<JsonNode> nodes) =>
       from s in nodes
       where s != null
       let k = s.GetValueKind()
       where k != JsonValueKind.Null
       where k != JsonValueKind.Undefined
       select k == JsonValueKind.Object ?
        (object)s.AsObject().ToXFragment("i") :
        new XElement("i", s.ToXFragment())
       ;

    private static IEnumerable<object> ToXNodesInternal(IEnumerable<KeyValuePair<string, JsonNode>> nodes) =>
        nodes.Select(ToXNodeInternal);

    private static object ToXNodeInternal(KeyValuePair<string, JsonNode> e) =>
        e.Value.GetValueKind() switch
        {
            JsonValueKind.Number => new XAttribute(e.Key, e.Value.GetValue<double>()),
            JsonValueKind.String => new XAttribute(e.Key, e.Value.GetValue<string>()),
            JsonValueKind.True => new XAttribute(e.Key, "true"),
            JsonValueKind.False => new XAttribute(e.Key, "false"),
            JsonValueKind.Array => e.Value.AsArray().ToXFragment(e.Key),
            JsonValueKind.Object => e.Value.AsObject().ToXFragment(rootName: e.Key),
            _ => throw new NotSupportedException()
        };

    public static XFragment? ToXFragment(this JsonNode? json, string? rootName = default) =>
        json?.GetValueKind() switch
        {
            null => null,
            JsonValueKind.Null => null,
            JsonValueKind.Undefined => null,
            JsonValueKind.Number => new XFragment(new XText(json.GetValue<double>().ToString())),
            JsonValueKind.String => new XFragment(new XText(json.GetValue<string>())),
            JsonValueKind.Array => json.AsArray().ToXFragment(rootName),
            JsonValueKind.True => new XFragment(new XText("true")),
            JsonValueKind.False => new XFragment(new XText("false")),
            JsonValueKind.Object => json.AsObject().AsObject().ToXFragment(rootName),
            _ => throw new NotSupportedException()
        };
}
