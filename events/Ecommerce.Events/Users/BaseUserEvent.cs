using System;

namespace Ecommerce.Events.Users
{
    public abstract class BaseUserEvent : Event
    {
        public BaseUserEvent(string userName, DateTime eventDate, int version, string source) : base(eventDate, version, source)
        {
            UserName = userName;
        }
        public string UserName { get; }
    }
}
