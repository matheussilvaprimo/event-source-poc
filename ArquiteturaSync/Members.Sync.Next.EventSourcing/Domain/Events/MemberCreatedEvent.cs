using System;
using System.Collections.Generic;

namespace Members.Sync.Next.EventSourcing.Domain.Events
{
    public class MemberCreatedEvent : BaseMemberEvent
    {
        public MemberCreatedEvent(string Identifier, int IdentifierType, string MemberID, string LegacyID, string FullName, long Age, string CellNumber,
                                  DateTime DateOfBirth, string EventType, List<AddressCreatedEvent> Addresses, string fingerPrint, string ID, DateTime Date,
                                  string Source) : base(fingerPrint, ID, Date, Source)
        {
            this.Identifier = Identifier;
            this.IdentifierType = IdentifierType;
            this.MemberID = MemberID;
            this.LegacyID = LegacyID;
            this.FullName = FullName;
            this.Age = Age;
            this.CellNumber = CellNumber;
            this.DateOfBirth = DateOfBirth;
            this.EventType = EventType;
            this.Addresses = Addresses;
        }

        public string Identifier { get; }
        public int IdentifierType { get; }
        public string MemberID { get; }
        public string LegacyID { get; }
        public string FullName { get; }
        public long Age { get; }
        public string CellNumber { get; }
        public DateTime DateOfBirth { get; }
        public string EventType { get; }
        public List<AddressCreatedEvent> Addresses { get; }
    }
}
