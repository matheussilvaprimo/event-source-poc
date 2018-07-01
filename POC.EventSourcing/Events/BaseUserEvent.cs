using System;

namespace Events
{
    public abstract class BaseUserEvent : BaseEvent
    {
        protected BaseUserEvent(string userName, DateTime eventDate, string source, string version) : base(eventDate, source, version)
        {
            UserName = userName;
        }

        public string UserName { get; }
    }
}
