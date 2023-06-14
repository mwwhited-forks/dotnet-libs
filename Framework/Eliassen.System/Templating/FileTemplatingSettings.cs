using Eliassen.System.Configuration;

namespace Eliassen.System.Templating
{
    [ConfigurationSection("FileTemplating")]
    public class FileTemplatingSettings
    {
        public string TemplatePath { get; set; } = "./";
    }
}