namespace Nucleus.External.Azure.StorageAccount;

public static class ConfigKeys
{
    public static class Container
    {
        public const string DefaultProvider = "StorageContainer:DefaultProvider";
        public const string DefaultConnectionString = "StorageContainer:ConnectionString";
        public const string DefaultContainerName = "StorageContainer:ContainerName";

        public static class Directories
        {
            public const string _Base = "StorageContainer:ContainerDirectories:";
            public const string Misc = "StorageContainer:ContainerDirectories:Misc";
        }
    }
}
