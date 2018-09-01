using System;

namespace Ecommerce.Events
{
    public abstract class BaseEvent
    {
        protected BaseEvent(DateTime eventDate, int version, string source)
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
