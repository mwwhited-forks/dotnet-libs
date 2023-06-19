using Eliassen.System.Configuration;

namespace Eliassen.System.Templating
{
    [ConfigurationSection("FileTemplating")]
    public class FileTemplatingSettings
    {
        [CommandParameter(Value = "file-template-path")]
        public string TemplatePath { get; set; } = "./";
        [CommandParameter(Value = "file-template-sandbox")]
        public string? SandboxPath { get; set; } = null;
        [CommandParameter(Value = "file-template-priority")]
        public int Priority { get; set; } = 100;
    }
}