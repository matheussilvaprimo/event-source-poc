using System;
using ECommerce.Events.ValueObjects;

namespace Ecommerce.Events.Users
{
    public class UserUpdatedEvent : BaseUserEvent
    {
        public UserUpdatedEvent(UserInformation userInformation, string userName, DateTime eventDate, int version, string source) 
      : base(userName, eventDate, version, source)
        {
            UserInformation = userInformation;
        }

        public UserInformation UserInformation { get; }
    }
}
