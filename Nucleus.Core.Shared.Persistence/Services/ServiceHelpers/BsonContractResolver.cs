using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Reflection;

namespace Nucleus.Core.Shared.Persistence.Services.ServiceHelpers
{
    public class BsonContractResolver : DefaultContractResolver
    {
        public static readonly BsonContractResolver Instance = new();

        public BsonContractResolver() =>
            NamingStrategy = new CamelCaseNamingStrategy();

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            if (string.Equals(property?.PropertyName, member.ReflectedType?.Name.Replace("Model", string.Empty) + "Id", StringComparison.OrdinalIgnoreCase))
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                property.PropertyName = "_id";
#pragma warning disable CS8603 // Possible null reference return.
            return property;
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
