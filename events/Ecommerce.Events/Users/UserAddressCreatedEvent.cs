using System;
using ECommerce.Events.ValueObjects;

namespace Ecommerce.Events.Users
{
    public class UserAddressCreatedEvent : BaseUserEvent
    {
        public UserAddressCreatedEvent(string AddressID, Address address, string userName, DateTime eventDate, int version, string source) 
      : base(userName, eventDate, version, source)
        {
            this.AddressID = AddressID;
            Address = address;
        }

        public string AddressID { get; }
        public Address Address { get; }
    }
}
