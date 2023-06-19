using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Stream? Apply(string templateContentType, Stream template, object? context, object data)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public bool CanApply(string templateContentType, object? context) =>
            string.Equals(templateContentType, ContentType, StringComparison.InvariantCultureIgnoreCase);
    }
}
