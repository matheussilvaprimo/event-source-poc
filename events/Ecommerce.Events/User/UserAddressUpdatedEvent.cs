using System;
using Ecommerce.Events.ValueObjects;

namespace Ecommerce.Events.User
{
    public class UserAddressUpdatedEvent : BaseUserEvent
    {
        public UserAddressUpdatedEvent(string platformID, Address address, string userName, DateTime eventDate, int version, string source)
      : base(userName, eventDate, version, source)
        {
            PlatformID = platformID;
            Address = address;
        }

        public string PlatformID { get; }
        public Address Address { get; }
    }
}
