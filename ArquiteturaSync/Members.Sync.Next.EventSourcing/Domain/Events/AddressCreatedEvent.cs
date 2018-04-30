using System;

namespace Members.Sync.Next.EventSourcing.Domain.Events
{
    public class AddressCreatedEvent : BaseMemberEvent
    {
        public AddressCreatedEvent(string iD, string memberID, string streetName, int streetNumber, string referencePoint, string city, string state, 
            string country, bool defaultAddress, string type, string fingerPrint, string ID, DateTime Date, string Source) : base(fingerPrint, ID, Date, Source)
        {
            ID = iD;
            MemberID = memberID;
            StreetName = streetName;
            StreetNumber = streetNumber;
            ReferencePoint = referencePoint;
            City = city;
            State = state;
            Country = country;
            DefaultAddress = defaultAddress;
            Type = type;
        }

        public string MemberID { get; set; }
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }
        public string ReferencePoint { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public bool DefaultAddress { get; set; }
        public string Type { get; set; }
    }
}
