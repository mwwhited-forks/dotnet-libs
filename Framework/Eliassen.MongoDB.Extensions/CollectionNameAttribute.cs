using System;

namespace Eliassen.MongoDB.Extensions
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CollectionNameAttribute : Attribute
    {
        public string CollectionName { get; }

        public CollectionNameAttribute (
            string collectionName)
        {
            CollectionName = collectionName;
        }
    }
}