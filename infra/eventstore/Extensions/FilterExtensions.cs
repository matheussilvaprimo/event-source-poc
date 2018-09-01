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

            foreach (var field in properties)
            {
                filter = Filter.Equal(field.Name, GetValueFromType(field.GetValue(o)));
            }

            return new Filter(filter);
        }

        private static Value GetValueFromType(object o)
        {
            var type = o.GetType();
            Value val = null;

            if (type == typeof(string))
            {
                val = (string)o;
            }
            else if (type == typeof(Guid))
            {
                val = ((Guid)o).ToString();
            }
            else if (type == typeof(DateTime))
            {
                val = ((DateTime)o).ToUniversalTime();
            }
            else if (type == typeof(int))
            {
                val = (int)o;
            }
            else if (type == typeof(long))
            {
                val = (long)o;
            }
            else if (type == typeof(byte))
            {
                val = (byte)o;
            }
            else if (type == typeof(Enum))
            {
                val = (byte)o;
            }
            else if (type == typeof(bool))
            {
                val = (bool)o;
            }
            else if (type == typeof(double))
            {
                val = (double)o;
            }

            return val;
        }
    }
}
