using System;
using System.IO;

namespace Eliassen.System.Text.Templating
{
    /// <inheritdoc/>
    public record TemplateContext : ITemplateContext
    {
        /// <inheritdoc/>
        public string TemplateName { get; set; } = null!;
        /// <inheritdoc/>
        public string TemplateContentType { get; set; } = null!;
        /// <inheritdoc/>
        public string TemplateFileExtension { get; set; } = null!;
        /// <inheritdoc/>
        public ITemplateSource TemplateSource { get; set; } = null!;

        /// <inheritdoc/>
        public string TemplateReference { get; set; } = null!;
        /// <inheritdoc/>
        public Func<ITemplateContext, Stream> OpenTemplate { get; set; } = null!;

        /// <inheritdoc/>
        public string TargetContentType { get; set; } = null!;
        /// <inheritdoc/>
        public string TargetFileExtension { get; set; } = null!;

        /// <inheritdoc/>
        public int Priority { get; set; }

        /// <inheritdoc/>
        public override string ToString() =>
            string.Join("",
                TemplateName,
                TargetFileExtension == TemplateFileExtension ? null : TargetFileExtension,
                TemplateFileExtension,
                $" ({TemplateContentType} -> {TargetContentType})"
                );
    }
}