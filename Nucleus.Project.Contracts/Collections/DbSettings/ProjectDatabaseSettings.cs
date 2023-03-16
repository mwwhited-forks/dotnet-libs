namespace Nucleus.Project.Contracts.Collections.DbSettings
{
    public class ProjectDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string ProjectsCollectionName { get; set; } = null!;
    }
}
