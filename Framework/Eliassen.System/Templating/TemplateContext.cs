using System;
using System.IO;

namespace Eliassen.System.Templating
{
    public record TemplateContext : ITemplateContext
    {
        public string TemplateName { get; set; }
        public string TemplateContentType { get; set; }
        public string TemplateFileExtension { get; set; }
        public ITemplateSource TemplateSource { get; set; }

        public string TemplateReference { get; set; }
        public Func<Stream> OpenTemplate { get; set; }

        public string TargetContentType { get; set; }
        public string TargetFileExtension { get; set; }
        public int Priority { get; set; }
    }
}