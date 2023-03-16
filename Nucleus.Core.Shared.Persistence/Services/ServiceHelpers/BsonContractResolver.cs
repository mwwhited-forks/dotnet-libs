using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Reflection;

namespace Nucleus.Core.Shared.Persistence.Services.ServiceHelpers
{
    public class BsonContractResolver : DefaultContractResolver
    {
        public static readonly BsonContractResolver Instance = new BsonContractResolver();

        public BsonContractResolver() =>
            NamingStrategy = new CamelCaseNamingStrategy();

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            if (property.PropertyName.Equals(member.ReflectedType.Name.Replace("Model", string.Empty) + "Id", StringComparison.OrdinalIgnoreCase))
                property.PropertyName = "_id";
            return property;
        }
    }
}
