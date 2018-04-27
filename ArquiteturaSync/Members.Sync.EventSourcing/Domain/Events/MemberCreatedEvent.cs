using System;

namespace Members.Sync.EventSourcing.Domain.Events
{
    public class MemberCreatedEvent : BaseMemberEvent
    {
        public MemberCreatedEvent(string fingerPrint, string ID, DateTime Date, string Source) : base(fingerPrint, ID, Date, Source)
        {
        }
        public string MemberID { get; }
        public string LegacyID { get; }
        public string FullName { get; }
        public long Age { get; }
        public string CellNumber { get; }
        public DateTime DateOfBirth { get; }
        public string EventType { get; }
    }
}
