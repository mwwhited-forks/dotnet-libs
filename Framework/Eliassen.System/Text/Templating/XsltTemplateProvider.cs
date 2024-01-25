using Eliassen.System.Net.Mime;
using Eliassen.System.Text.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace Eliassen.System.Text.Templating;

/// <summary>
/// Provides template processing using XSLT (eXtensible Stylesheet Language Transformations).
/// </summary>
public class XsltTemplateProvider : ITemplateProvider
{
    /// <summary>
    /// Gets the collection of supported content types by the template provider.
    /// 
    /// application/xslt+xml
    /// </summary>
    public IReadOnlyCollection<string> SupportedContentTypes { get; } = new[]
    {
         ContentTypesExtensions.Application.XSLT,
    };

    /// <summary>
    /// Determines whether this template provider can apply template processing to the given context.
    /// </summary>
    /// <param name="context">The template context.</param>
    /// <returns><c>true</c> if the template processing can be applied; otherwise, <c>false</c>.</returns>
    public bool CanApply(ITemplateContext context) =>
        SupportedContentTypes.Any(type => string.Equals(context.TemplateContentType, type, StringComparison.InvariantCultureIgnoreCase));

    /// <summary>
    /// Applies the XSLT template associated with the specified context, using the provided data,
    /// and writes the result to the target stream asynchronously.
    /// </summary>
    /// <param name="context">The template context.</param>
    /// <param name="data">The data to apply to the template.</param>
    /// <param name="target">The stream where the result will be written.</param>
    /// <returns>A task representing the asynchronous operation, indicating whether the application was successful.</returns>
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
            ConformanceLevel = ConformanceLevel.Auto,
        });
        xslt.Transform(navigator, writer);
        return true;
    }

    private static async Task<IXPathNavigable> GetNavigatorAsync(object data)
    {
        if (data is IXPathNavigable navigable)
        {
            return navigable;
        }
        else if (data is JsonDocument jsonDocument)
        {
            data = jsonDocument.RootElement;
        }
        else if (data is XmlDocument xmlDocument)
        {
            return xmlDocument.CreateNavigator() ?? throw new NotSupportedException("xmlDocument.CreateNavigator()");
        }
        else if (data is XDocument XDocument)
        {
            return XDocument.CreateNavigator();
        }

        if (data is JsonElement jsonElement)
        {
            var built = jsonElement.ToXmlDocument();
            var builtNavigator = built?.CreateNavigator();
            if (builtNavigator != null)
                return builtNavigator;
        }

        var serializer = new global::System.Xml.Serialization.XmlSerializer(data.GetType());
        using var xml = new MemoryStream();
        serializer.Serialize(xml, data);
        xml.Position = 0;
        var document = await XDocument.LoadAsync(xml, LoadOptions.None, CancellationToken.None);
        var navigator = document.CreateNavigator();
        return navigator;
    }
}
