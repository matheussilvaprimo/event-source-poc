using System;

namespace Members.Sync.EventSourcing.Domain.Events
{
    public class MemberPersonalInfoUpdatedEvent : BaseMemberEvent
    {
        public MemberPersonalInfoUpdatedEvent(string fingerPrint, string ID, DateTime Date, string Source) : base(fingerPrint, ID, Date, Source)
        {
        }
    }
}
