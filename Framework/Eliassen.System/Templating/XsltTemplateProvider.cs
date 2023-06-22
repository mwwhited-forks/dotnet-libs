using Eliassen.System.Reflection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace Eliassen.System.Templating
{
    /// <inheritdoc />
    public class XsltTemplateProvider : ITemplateProvider
    {
        /// <summary>
        /// HTTP Content Type Supported for this Provider
        /// </summary>
        public const string ContentType = "application/xslt+xml";

        /// <inheritdoc />
        public async Task<bool> ApplyAsync(ITemplateContext context, object data, Stream target)
        {
            using var readStream = context.OpenTemplate(context);

            var xslt = new XslCompiledTransform(false);
            using var styleSheet = XmlReader.Create(readStream, new XmlReaderSettings
            {
                DtdProcessing = DtdProcessing.Parse,
                ConformanceLevel = ConformanceLevel.Document,
                NameTable = new NameTable(),
            });
            var xsltSettings = new XsltSettings(false, false);
            xslt.Load(styleSheet);

            var navigator = await GetNavigatorAsync(data);

            using var writer = XmlWriter.Create(target, new XmlWriterSettings
            {
                CloseOutput = false,
            });
            xslt.Transform(navigator, writer);
            return true;
        }

        private async Task<IXPathNavigable> GetNavigatorAsync(object data)
        {
            if (data is IXPathNavigable navigable)
            {
                return navigable;
            }
            else if (data is JsonDocument jsonDocument)
            {
                data = jsonDocument.RootElement;
            }

            //if (data is JsonElement jsonElement)
            //{
            //    var built = jsonElement.ToXmlDocument();
            //    var builtNavigator = built?.CreateNavigator();
            //    if (builtNavigator != null)
            //        return builtNavigator;
            //}

            var serializer = new global::System.Xml.Serialization.XmlSerializer(data.GetType());
            using var xml = new MemoryStream();
            serializer.Serialize(xml, data);
            xml.Position = 0;
            var document = await XDocument.LoadAsync(xml, LoadOptions.None, CancellationToken.None);
            var navigator = document.CreateNavigator();
            return navigator;
        }

        /// <inheritdoc />
        public bool CanApply(ITemplateContext context) =>
            string.Equals(context.TemplateContentType, ContentType, StringComparison.InvariantCultureIgnoreCase);
    }

    //public static class XmlDocumentExtensions
    //{
    //    public static XmlDocument ToXmlDocument(this JsonElement json, string? rootName = default)
    //    {
    //        if (string.IsNullOrWhiteSpace(rootName)) rootName = json.ValueKind.ToString();
    //        rootName = XmlConvert.EncodeName(rootName);

    //        var document = new XmlDocument();
    //        document.AppendChild(
    //            AppendChildren(
    //                document.CreateElement(rootName),
    //                Gather(document, "", json)
    //                )
    //        );

    //        return document;
    //    }

    //    public static XmlElement AppendChildren(this XmlElement element, IEnumerable<XmlNode> children)
    //    {
    //        foreach (var child in children)
    //        {
    //            if (child is XmlAttribute attribute)
    //                element.Attributes.Append(attribute);
    //            else
    //                element.AppendChild(child);
    //        }
    //        return element;
    //    }

    //    private static IEnumerable<XmlNode> Gather(XmlDocument document, string name, JsonElement json)
    //    {
    //        if (string.IsNullOrWhiteSpace(name)) name = json.ValueKind.ToString();
    //        name = XmlConvert.EncodeName(name);
    //        switch (json.ValueKind)
    //        {
    //            case JsonValueKind.Object:
    //                {
    //                    foreach (var item in json.EnumerateObject())
    //                        yield return AppendChildren(
    //                            document.CreateElement(name),
    //                            Gather(document, item.Name, item.Value)
    //                            );
    //                }
    //                break;
    //            case JsonValueKind.Array:
    //                {
    //                    var array = document.CreateElement(name);
    //                    foreach (var item in json.EnumerateArray())
    //                    {
    //                        //var itemElement = document.CreateElement(name);
    //                        var children = Gather(document, "", item);
    //                        foreach (var child in children)
    //                        {
    //                            if (child is XmlAttribute attribute)
    //                            {
    //                                var attElement = document.CreateElement(attribute.Name);
    //                                attElement.InnerText = attribute.Value;
    //                                array.AppendChild(attElement);
    //                            }
    //                            else
    //                            {
    //                                array.AppendChild(child);
    //                            }
    //                        }
    //                    }
    //                    yield return array;
    //                }
    //                break;

    //            case JsonValueKind.String:
    //            case JsonValueKind.Number:
    //            case JsonValueKind.True:
    //            case JsonValueKind.False:
    //                {
    //                    var attribute = document.CreateAttribute(name);
    //                    attribute.Value = json.ToString();
    //                    yield return attribute;
    //                };
    //                break;

    //            case JsonValueKind.Undefined:
    //            case JsonValueKind.Null:
    //            default:
    //                break;
    //        }
    //    }
    //}
}
