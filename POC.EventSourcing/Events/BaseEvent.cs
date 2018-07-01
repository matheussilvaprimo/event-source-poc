using System;

namespace Events
{
    public abstract class BaseEvent
    {
        protected BaseEvent(DateTime eventDate, string source, string version)
        {
            EventDate = eventDate;
            Source = source;
            Version = version;
        }

        public DateTime EventDate { get; }
        public string Source { get; }
        public string Version { get; }


        public virtual string SerializeEvent()
        {
            return ToString();
        }
    }
}
