using Eliassen.System.Configuration;
using System.ComponentModel.DataAnnotations;

namespace Eliassen.TemplateEngine.Cli;

public class TemplateEngineOptions
{
    [CommandParameter(Value = "input")]
    public string? InputFile { get; set; }

    [Required]
    public required string Template { get; set; }

    [CommandParameter(Value = "input-type")]
    public FileTypes? InputFileType { get; set; }

    [CommandParameter(Value = "output")]
    public string? OutputFile { get; set; }
}
