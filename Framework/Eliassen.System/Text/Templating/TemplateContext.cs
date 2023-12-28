using System;
using System.IO;

namespace Eliassen.System.Text.Templating;

/// <summary>
/// Represents the context of a template, providing information about the template and its processing.
/// </summary>
public record TemplateContext : ITemplateContext
{
    /// <summary>
    /// Gets or sets the name of the template.
    /// </summary>
    public string TemplateName { get; set; } = null!;

    /// <summary>
    /// Gets or sets the content type of the template.
    /// </summary>
    public string TemplateContentType { get; set; } = null!;

    /// <summary>
    /// Gets or sets the file extension of the template.
    /// </summary>
    public string TemplateFileExtension { get; set; } = null!;

    /// <summary>
    /// Gets or sets the source of the template.
    /// </summary>
    public ITemplateSource TemplateSource { get; set; } = null!;

    /// <summary>
    /// Gets or sets the reference identifier of the template.
    /// </summary>
    public string TemplateReference { get; set; } = null!;

    /// <summary>
    /// Gets or sets the function to open the template as a stream.
    /// </summary>
    public Func<ITemplateContext, Stream> OpenTemplate { get; set; } = null!;

    /// <summary>
    /// Gets or sets the content type of the target.
    /// </summary>
    public string TargetContentType { get; set; } = null!;

    /// <summary>
    /// Gets or sets the file extension of the target.
    /// </summary>
    public string TargetFileExtension { get; set; } = null!;

    /// <summary>
    /// Gets or sets the priority of the template.
    /// </summary>
    public int Priority { get; set; }

    /// <summary>
    /// Returns a string representation of the template context.
    /// </summary>
    /// <returns>A string representation of the template context.</returns>
    public override string ToString() =>
        string.Join("",
            TemplateName,
            TargetFileExtension == TemplateFileExtension ? null : TargetFileExtension,
            TemplateFileExtension,
            $" ({TemplateContentType} -> {TargetContentType})"
        );
}
