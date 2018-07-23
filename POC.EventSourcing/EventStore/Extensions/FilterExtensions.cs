using System;
using System.Linq;
using EventStore.Attributes;
using Google.Cloud.Datastore.V1;

namespace EventStore.Extensions
{
    public static class FilterExtensions
    {
        public static Filter GetFilter(this object o)
        {
            var properties = o.GetType().GetProperties().Where(x => x.CustomAttributes.Any(n => n.AttributeType == typeof(QueryableFieldAttribute))).ToList();

            if (properties == null) throw new Exception("This object contains no queryable fields.");

            var filter = new Filter();

            foreach(var field in properties)
            {                
                filter = Filter.Equal(field.Name, (string)field.GetValue(o));
            }

            return new Filter(filter);
        }
    }
}
