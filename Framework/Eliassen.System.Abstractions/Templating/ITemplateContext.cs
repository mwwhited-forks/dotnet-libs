namespace Eliassen.System.Templating
{
    public interface ITemplateContext
    {
        public string TemplateName { get; }
        public string TemplateContentType { get; }
        public string TemplateFileExtension { get; }
        public ITemplateSource TemplateSource { get; }

        public string TemplateReference { get; }
        public Func<Stream> OpenTemplate { get; }

        public string TargetContentType { get; }
        public string TargetFileExtension { get; }

        public int Priority { get; }
    }
}