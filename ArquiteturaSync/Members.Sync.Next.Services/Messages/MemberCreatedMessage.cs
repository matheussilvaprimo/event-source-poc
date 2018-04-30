using System;
using System.Collections.Generic;

namespace Members.Sync.Next.Services.Messages
{
    public class MemberCreatedMessage
    {
        public string Identifier { get; set; }
        public int IdentifierType { get; set; }
        public string MemberID { get; set; }
        public string LegacyID { get; set; }
        public string FullName { get; set; }
        public long Age { get; set; }
        public string CellNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EventType { get; set; }
        public DateTime EventDate { get; set; }
        public string Source { get; set; }
        public List<AddressCreatedMessage> Addresses { get; set; }
    }

    public class AddressCreatedMessage
    {
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