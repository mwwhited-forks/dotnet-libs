namespace Nucleus.Api
{
    public static class Constants
    {
        public static class ClaimTypes
        {
            public const string Scope = "scp";
            public const string Roles = "roles";
        }

        public static class AuthorizationPolicies
        {
            public const string ReadIdentity = nameof(ReadIdentity);
            public const string ReadWriteIdentity = nameof(ReadWriteIdentity);
        }

        public static class Scopes
        {
            public const string IdentityRead = nameof(IdentityRead);
            public const string IdentityReadWrite = nameof(IdentityReadWrite);
        }

        public static class Roles
        {
            public const string IdentityReader = nameof(IdentityReader);
        }
    }
}
