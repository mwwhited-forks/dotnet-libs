using Eliassen.System.Configuration;
using System.ComponentModel.DataAnnotations;

namespace Eliassen.TemplateEngine.Cli;

[ConfigurationSection("TemplateEngine")]
public class TemplateEngineSettings
{
    [CommandParameter(Value = "input")]
    public string? InputFile { get; set; }

    [Required]
    public string Template { get; set; } = null!;

    [CommandParameter(Value = "input-type")]
    public FileTypes? InputFileType { get; set; }

    [CommandParameter(Value = "output")]
    public string? OutputFile { get; set; }
}
