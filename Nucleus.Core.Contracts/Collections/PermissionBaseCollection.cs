using MongoDB.Bson.Serialization.Attributes;

namespace Nucleus.Core.Contracts.Collections
{
    public class PermissionBaseCollection
    {
        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonElement("code")]
        public string? Code { get; set; }
    }
}
