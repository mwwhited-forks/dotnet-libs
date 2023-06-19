using Eliassen.System.Configuration;

namespace Nucleus.TemplateEngine.Cli;

[ConfigurationSection("TemplateEngine")]
public class TemplateEngineSettings
{
    [CommandParameter(Value = "input")]
    public string? InputFile { get; set; }

    [CommandParameter(Value = "input-type")]
    public FileTypes? InputFileType { get; set; }

    [CommandParameter(Value = "output")]
    public string? OutputFile { get; set; }

    [CommandParameter(Value = "template")]
    public string? TemplateFile { get; set; }
}
