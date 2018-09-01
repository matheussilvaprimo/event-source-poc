using System;

namespace Ecommerce.Events
{
    public abstract class Event
    {
        protected Event(DateTime eventDate, int version, string source)
        {
            EventDate = eventDate;
            Version = version;
            Source = source;
        }

        public DateTime EventDate { get; }
        public int Version { get; }
        public string Source { get; }
    }
}
