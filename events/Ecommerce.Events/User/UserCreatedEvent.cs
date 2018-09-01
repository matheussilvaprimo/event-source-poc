using System;
using ECommerce.Events.ValueObjects;

namespace Ecommerce.Events.User
{
    public class UserCreatedEvent : BaseUserEvent
    {
        public UserCreatedEvent(UserInformation userInformation, Address registrationAddress, string userName, DateTime eventDate, int version, string source)
      : base(userName, eventDate, version, source)
        {
            UserInformation = userInformation;
            RegistrationAddress = registrationAddress;
        }

        public UserInformation UserInformation { get; }
        public Address RegistrationAddress { get; }
    }
}
