using System.Collections.Generic;
using System.Text.Json;
using System.Xml;

namespace Eliassen.System.Text.Json;

/// <summary>
/// shared extension methods for System.Text.Json
/// </summary>
public static class JsonDocumentExtensions
{
    /// <summary>
    /// Convert System.Test.Json.JsonDocument to System.Xml.XmlDocument
    /// </summary>
    /// <param name="json"></param>
    /// <param name="rootName"></param>
    /// <returns></returns>
    public static XmlDocument ToXmlDocument(this JsonElement json, string? rootName = default)
    {
        if (string.IsNullOrWhiteSpace(rootName)) rootName = json.ValueKind.ToString();
        rootName = XmlConvert.EncodeName(rootName);

        var document = new XmlDocument();
        var element = document.CreateElement(rootName);
        var children = GetChildren(document, "", json);

        foreach (var (_, node) in children)
        {
            if (node is XmlAttribute attribute)
                element.Attributes.Append(attribute);
            else
                element.AppendChild(node);
        }

        return document;
    }

    private static IEnumerable<(string name, XmlNode node)> GetChildren(XmlDocument document, string name, JsonElement json)
    {
        var nodeName = XmlConvert.EncodeName(string.IsNullOrWhiteSpace(name) ? json.ValueKind.ToString() : name);
        switch (json.ValueKind)
        {
            case JsonValueKind.Object:
                {
                    //var element = document.CreateElement(nodeName);

                    foreach (var item in json.EnumerateObject())
                    {
                        var children = GetChildren(document, item.Name, item.Value);
                        foreach (var child in children)
                        {
                            if (child.node is XmlText attribute)
                            {
                                if (attribute.Value != null)
                                {
                                    var attElement = document.CreateAttribute(XmlConvert.EncodeName(attribute.Name));
                                    attElement.InnerText = attribute.Value;
                                    yield return (attribute.Name, attElement);
                                    //element.Attributes.Append(attElement);
                                }
                            }
                            else
                            {
                                yield return (child.name, child.node);
                            }
                        }
                    }

                    //yield return ("object", element);
                }
                break;
            case JsonValueKind.Array:
                {
                    foreach (var item in json.EnumerateArray())
                    {
                        var array = document.CreateElement(nodeName);
                        var children = GetChildren(document, nodeName, item);
                        foreach (var child in children)
                        {
                            if (child.node is XmlAttribute attribute)
                            {
                                var attElement = document.CreateElement(attribute.Name);
                                attElement.InnerText = attribute.Value;
                                array.AppendChild(attElement);
                            }
                            else
                            {
                                array.AppendChild(child.node);
                            }
                        }
                        yield return ("item", array);
                    }
                }
                break;

            case JsonValueKind.String:
            case JsonValueKind.Number:
            case JsonValueKind.True:
            case JsonValueKind.False:
                {
                    var attribute = document.CreateTextNode(json.ToString());
                    yield return (nodeName, attribute);
                };
                break;

            case JsonValueKind.Undefined:
            case JsonValueKind.Null:
            default:
                break;
        }

    }



    //private XmlElement  


    //private static IEnumerable<XmlNode> Gather(XmlDocument document, string name, JsonElement json)
    //{
    //    if (string.IsNullOrWhiteSpace(name)) name = json.ValueKind.ToString();
    //    name = XmlConvert.EncodeName(name);
    //    switch (json.ValueKind)
    //    {
    //        case JsonValueKind.Object:
    //            {
    //                //var element = document.CreateElement(name);

    //                //foreach (var item in json.EnumerateObject())
    //                //{
    //                //    var children = Gather(document, item.Name, item.Value);
    //                //    foreach (var child in children)
    //                //    {
    //                //        if (child is XmlAttribute attribute)
    //                //        {
    //                //            element.Attributes.Append(attribute);
    //                //        }
    //                //        else
    //                //        {
    //                //            element.AppendChild(child);
    //                //        }
    //                //    }
    //                //}

    //               // yield return element;


    //                //var children = Gather(document, "", json);

    //                //foreach (var child in children)
    //                //{
    //                //    if (child is XmlAttribute attribute)
    //                //        element.Attributes.Append(attribute);
    //                //    else
    //                //        element.AppendChild(child);
    //                //}

    //                //return document;

    //                //foreach (var item in json.EnumerateObject())
    //                //{
    //                //    yield return document.CreateElement(name).AppendChildren(
    //                //        Gather(document, item.Name, item.Value)
    //                //        );
    //                //}

    //            }
    //            break;
    //        case JsonValueKind.Array:
    //            {
    //                var array = document.CreateElement(name);
    //                foreach (var item in json.EnumerateArray())
    //                {
    //                    //var itemElement = document.CreateElement(name);
    //                    var children = Gather(document, "", item);
    //                    foreach (var child in children)
    //                    {
    //                        if (child is XmlAttribute attribute)
    //                        {
    //                            var attElement = document.CreateElement(attribute.Name);
    //                            attElement.InnerText = attribute.Value;
    //                            array.AppendChild(attElement);
    //                        }
    //                        else
    //                        {
    //                            array.AppendChild(child);
    //                        }
    //                    }
    //                }
    //                yield return array;
    //            }
    //            break;

    //        case JsonValueKind.String:
    //        case JsonValueKind.Number:
    //        case JsonValueKind.True:
    //        case JsonValueKind.False:
    //            {
    //                var attribute = document.CreateAttribute(name);
    //                attribute.Value = json.ToString();
    //                yield return attribute;
    //            };
    //            break;

    //        case JsonValueKind.Undefined:
    //        case JsonValueKind.Null:
    //        default:
    //            break;
    //    }
    //}
}
