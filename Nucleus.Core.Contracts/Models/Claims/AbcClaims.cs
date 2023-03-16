using System;
using System.Collections.Generic;
using System.Text;

namespace Nucleus.Core.Contracts.Models
{
    public static class Claims
    {
        public static readonly string UserId = "app__user_id";
        public static readonly string Culture = "app__user_culture";
        public static readonly string Rights = "app__application_right";
        public static readonly string ExtendedProperties = "app__extended_property";
    }
}
