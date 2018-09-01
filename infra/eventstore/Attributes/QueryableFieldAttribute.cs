using System;

namespace EventStore.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class QueryableFieldAttribute : Attribute
    {
        public int Order { get; set; }
    }
}
