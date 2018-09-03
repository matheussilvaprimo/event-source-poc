using System;
using ECommerce.Events.ValueObjects;

namespace Ecommerce.Events.Users
{
    public class UserAddressUpdatedEvent : BaseUserEvent
    {
        public UserAddressUpdatedEvent(string addressID, Address address, string userName, DateTime eventDate, int version, string source)
      : base(userName, eventDate, version, source)
        {
            AddressID = addressID;
            Address = address;
        }

        public string AddressID { get; }
        public Address Address { get; }
    }
}
