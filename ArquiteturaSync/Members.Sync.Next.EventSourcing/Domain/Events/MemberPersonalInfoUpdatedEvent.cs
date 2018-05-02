﻿using System;

namespace Members.Sync.Next.EventSourcing.Domain.Events
{
    public class MemberPersonalInfoUpdatedEvent : BaseMemberEvent
    {

        public MemberPersonalInfoUpdatedEvent(string Identifier, int IdentifierType, string MemberID, string LegacyID, string FullName, long Age, string CellNumber,
                                  DateTime DateOfBirth, string EventType, string fingerPrint, string ID, string AggregateID, DateTime Date, string Source) : base(Identifier, IdentifierType, fingerPrint, ID, AggregateID, Date, Source)
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
    }
}
