using System;
using System.IO;

namespace Eliassen.System.Text.Templating;

public record TemplateContext : ITemplateContext
{
    public string TemplateName { get; set; } = null!;
    public string TemplateContentType { get; set; } = null!;
    public string TemplateFileExtension { get; set; } = null!;
    public ITemplateSource TemplateSource { get; set; } = null!;

    public string TemplateReference { get; set; } = null!;
    public Func<ITemplateContext, Stream> OpenTemplate { get; set; } = null!;
    public string TargetContentType { get; set; } = null!;
    public string TargetFileExtension { get; set; } = null!;
    public int Priority { get; set; }
    public override string ToString() =>
        string.Join("",
            TemplateName,
            TargetFileExtension == TemplateFileExtension ? null : TargetFileExtension,
            TemplateFileExtension,
            $" ({TemplateContentType} -> {TargetContentType})"
            );
}