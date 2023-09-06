namespace Nucleus.External.Microsoft.B2C.Identity;

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
}
