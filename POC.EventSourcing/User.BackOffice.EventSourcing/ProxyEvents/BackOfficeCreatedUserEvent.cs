using System;
using Events;
using Events.ValueObjects;
using EventSourcing;
using User.BackOffice.EventSourcing.Entities;

namespace User.BackOffice.EventSourcing.ProxyEvents
{
    public class BackOfficeCreatedUserEvent : UserCreatedEvent, IEvent
    {
        public BackOfficeCreatedUserEvent(UserInformation userInfo, Address registrationAddress, string userName, DateTime eventDate, string source, string version)
                                                      : base(userInfo, registrationAddress, userName, eventDate, source, version)
        {
        }

        public void ApplyState(object target)
        {
            if (target is UserAggregateRootEntity agg)
            {
                MapUserInfo(agg.UserInfo);
                MapAddress(agg.Address);
            }
        }

        private void MapUserInfo(VOs.UserInformation user)
        {
            user.DateOfBirth = UserInformation.DateOfBirth;
            user.Email = UserInformation.Email;
            user.FullName = UserInformation.FullName;
            user.Gender = (VOs.Gender)UserInformation.Gender;
        }

        private void MapAddress(VOs.Address address)
        {
            address = new VOs.Address
            {
                AdditionalInformation = RegistrationAddress.AdditionalInformation,
                AddressNumber = RegistrationAddress.AddressNumber,
                City = RegistrationAddress.City,
                Country = RegistrationAddress.Country,
                District = RegistrationAddress.District,
                PostalCode = RegistrationAddress.PostalCode,
                ReferencePoint = RegistrationAddress.ReferencePoint,
                State = RegistrationAddress.State,
                StreetName = RegistrationAddress.StreetName
            };
        }
    }
}
