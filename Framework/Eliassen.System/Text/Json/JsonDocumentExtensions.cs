using System.Collections.Generic;
using System.Text.Json;
using System.Xml;

namespace Eliassen.System.Text.Json
{
    public static class JsonDocumentExtensions
    {
        public static XmlDocument ToXmlDocument(this JsonElement json, string? rootName = default)
        {
            if (string.IsNullOrWhiteSpace(rootName)) rootName = json.ValueKind.ToString();
            rootName = XmlConvert.EncodeName(rootName);

            var document = new XmlDocument();
            document.AppendChild(
                document.CreateElement(rootName).AppendChildren(
                    Gather(document, "", json)
                    )
            );

            return document;
        }

        private static XmlElement AppendChildren(this XmlElement element, IEnumerable<XmlNode> children)
        {
            foreach (var child in children)
            {
                if (child is XmlAttribute attribute)
                    element.Attributes.Append(attribute);
                else
                    element.AppendChild(child);
            }
            return element;
        }

        private static IEnumerable<XmlNode> Gather(XmlDocument document, string name, JsonElement json)
        {
            if (string.IsNullOrWhiteSpace(name)) name = json.ValueKind.ToString();
            name = XmlConvert.EncodeName(name);
            switch (json.ValueKind)
            {
                case JsonValueKind.Object:
                    {
                        foreach (var item in json.EnumerateObject())
                            yield return document.CreateElement(name).AppendChildren(
                                Gather(document, item.Name, item.Value)
                                );
                    }
                    break;
                case JsonValueKind.Array:
                    {
                        var array = document.CreateElement(name);
                        foreach (var item in json.EnumerateArray())
                        {
                            //var itemElement = document.CreateElement(name);
                            var children = Gather(document, "", item);
                            foreach (var child in children)
                            {
                                if (child is XmlAttribute attribute)
                                {
                                    var attElement = document.CreateElement(attribute.Name);
                                    attElement.InnerText = attribute.Value;
                                    array.AppendChild(attElement);
                                }
                                else
                                {
                                    array.AppendChild(child);
                                }
                            }
                        }
                        yield return array;
                    }
                    break;

                case JsonValueKind.String:
                case JsonValueKind.Number:
                case JsonValueKind.True:
                case JsonValueKind.False:
                    {
                        var attribute = document.CreateAttribute(name);
                        attribute.Value = json.ToString();
                        yield return attribute;
                    };
                    break;

                case JsonValueKind.Undefined:
                case JsonValueKind.Null:
                default:
                    break;
            }
        }
    }
}
