using System;

namespace Members.Sync.Next.EventSourcing.Domain.Events
{
    public class AddressCreatedEvent : BaseMemberEvent
    {
        public AddressCreatedEvent(string aggregateID, string memberIdentifier, int memberIdentifierType, string streetName, int streetNumber, string referencePoint, string city, string state, 
            string country, bool defaultAddress, string type, string fingerPrint, string ID, DateTime Date, string Source) : base(memberIdentifier, memberIdentifierType, fingerPrint, ID, aggregateID, Date, Source)
        {           
            StreetName = streetName;
            StreetNumber = streetNumber;
            ReferencePoint = referencePoint;
            City = city;
            State = state;
            Country = country;
            DefaultAddress = defaultAddress;
            Type = type;
        }
        public string StreetName { get; }
        public int StreetNumber { get; }
        public string ReferencePoint { get; }
        public string City { get; }
        public string State { get; }
        public string Country { get; }
        public bool DefaultAddress { get; }
        public string Type { get; }
    }
}
