using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

            var serializer = new global::System.Xml.Serialization.XmlSerializer(data.GetType());
            using var xml = new MemoryStream();
            serializer.Serialize(xml, data);
            xml.Position = 0;
            var document = await XDocument.LoadAsync(xml, LoadOptions.None, CancellationToken.None);
            var navigator = document.CreateNavigator();

            using var writer = XmlWriter.Create(target, new XmlWriterSettings
            {
                CloseOutput = false,
            });
            xslt.Transform(navigator, writer);
            return true;
        }

        /// <inheritdoc />
        public bool CanApply(ITemplateContext context) =>
            string.Equals(context.TemplateContentType, ContentType, StringComparison.InvariantCultureIgnoreCase);
    }
}
