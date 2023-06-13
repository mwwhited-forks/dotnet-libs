using Eliassen.System.Configuration;

namespace Nucleus.Dataloader.Cli
{
    [ConfigurationSection(SectionGroup)]
    public class DataLoaderSettings
    {
        public const string SectionGroup = "DataLoader";

        public string SourcePath { get; set; } = @"./";
        public string IncludePath { get; set; } = @"**/*.json";
    }
}