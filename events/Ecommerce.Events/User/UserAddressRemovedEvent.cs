using System;

namespace Ecommerce.Events.User
{
    public class UserAddressRemovedEvent : BaseUserEvent
    {
        public UserAddressRemovedEvent(string platformID, string userName, DateTime eventDate, int version, string source) : base(userName, eventDate, version, source)
        {
            PlatformID = platformID;
        }

        public string PlatformID { get; }
    }
}
