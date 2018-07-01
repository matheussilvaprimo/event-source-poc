using System;
using Events.ValueObjects;

namespace Events
{
    public class CreatedUserEvent : BaseUserEvent
    {
        protected CreatedUserEvent(UserInformation userInfo, Address registrationAddress, string userName, DateTime eventDate, string source,
                                   string version) : base(userName, eventDate, source, version)
        {
            UserInformation = userInfo;
            RegistrationAddress = registrationAddress;
        }

        public UserInformation UserInformation { get; }
        public Address RegistrationAddress { get; }
    }
}
