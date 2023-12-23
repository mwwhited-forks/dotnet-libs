namespace Eliassen.Microsoft.B2C.Identity;

/// <summary>
/// Contains constant keys for Azure-related configuration settings.
/// </summary>
public static class ConfigKeys
{
    /// <summary>
    /// Contains keys related to Azure configuration.
    /// </summary>
    public static class Azure
    {
        /// <summary>
        /// Contains keys related to Azure Active Directory B2C configuration.
        /// </summary>
        public static class ADB2C
        {
            /// <summary>
            /// Represents the key for the Azure AD B2C client ID configuration.
            /// </summary>
            public const string ClientID = "Azure:AdB2C:ClientId";

            /// <summary>
            /// Represents the key for the Azure AD B2C issuer configuration.
            /// </summary>
            public const string Issuer = "Azure:AdB2C:Issuer";

            /// <summary>
            /// Represents the key for the Azure AD B2C client secret configuration.
            /// </summary>
            public const string ClientSecret = "Azure:AdB2C:ClientSecret";

            /// <summary>
            /// Represents the key for the Azure AD B2C tenant configuration.
            /// </summary>
            public const string Tenant = "Azure:AdB2C:Tenant";

            /// <summary>
            /// Represents the key for the Azure AD B2C domain configuration.
            /// </summary>
            public const string Domain = "Azure:AdB2C:Domain";
        }
    }
}