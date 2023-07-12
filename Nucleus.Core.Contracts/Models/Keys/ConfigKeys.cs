namespace Nucleus.Core.Contracts.Models.Keys
{
    public static class ConfigKeys
    {
        public static class Azure
        {
#pragma warning disable VSSpell001 // Spell Check
            public static class ADB2C
#pragma warning restore VSSpell001 // Spell Check
            {
                public const string ClientID = "Azure:AdB2C:ClientId";
                public const string Issuer = "Azure:AdB2C:Issuer";
                public const string ClientSecret = "Azure:AdB2C:ClientSecret";
                public const string Tenant = "Azure:AdB2C:Tenant";
                public const string Domain = "Azure:AdB2C:Domain";
            }

        }
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
}
