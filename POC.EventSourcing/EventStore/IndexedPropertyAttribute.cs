using System;

namespace EventStore
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class IndexedPropertyAttribute : Attribute
    {
    }
}
