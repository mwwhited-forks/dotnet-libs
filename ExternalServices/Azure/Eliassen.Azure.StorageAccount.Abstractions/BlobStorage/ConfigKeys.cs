namespace Eliassen.Azure.StorageAccount.BlobStorage;

/// <summary>
/// Contains constant keys for configuration settings.
/// </summary>
public static class ConfigKeys
{
    /// <summary>
    /// Contains keys related to storage container configuration.
    /// </summary>
    public static class Container
    {
        /// <summary>
        /// Represents the key for the default storage provider configuration.
        /// </summary>
        public const string DefaultProvider = "StorageContainer:DefaultProvider";

        /// <summary>
        /// Represents the key for the default storage connection string configuration.
        /// </summary>
        public const string DefaultConnectionString = "StorageContainer:ConnectionString";

        /// <summary>
        /// Represents the key for the default storage container name configuration.
        /// </summary>
        public const string DefaultContainerName = "StorageContainer:ContainerName";

        /// <summary>
        /// Contains keys related to storage container directories configuration.
        /// </summary>
        public static class Directories
        {
            /// <summary>
            /// Represents the base key for container directories configuration.
            /// </summary>
            public const string _Base = "StorageContainer:ContainerDirectories:";

            /// <summary>
            /// Represents the key for the miscellaneous directory within the storage container.
            /// </summary>
            public const string Misc = "StorageContainer:ContainerDirectories:Misc";
        }
    }
}
