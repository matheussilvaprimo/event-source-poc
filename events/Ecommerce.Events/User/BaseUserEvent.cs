using System;

namespace Ecommerce.Events.User
{
    public class BaseUserEvent : BaseEvent
    {
        public BaseUserEvent(string userName, DateTime eventDate, int version, string source) : base(eventDate, version, source)
        {
            UserName = userName;
        }
        public string UserName { get; }
    }
}
