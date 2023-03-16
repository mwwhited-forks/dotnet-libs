using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleus.Core.Contracts.Models.Keys
{
    public static class UserActionsConst
    {
        public static class IdentityActions
        {
            public const string NoAction = "no-action";
            public const string RetainIdentity = "retain-identity";
            public const string RemoveIdentity = "remove-identity";
            public const string RemoveAccount = "remove-account";
        }
    }
}
