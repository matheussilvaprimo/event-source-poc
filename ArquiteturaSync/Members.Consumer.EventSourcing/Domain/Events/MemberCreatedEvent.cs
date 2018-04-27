using System;

namespace Members.Consumer.EventSourcing.Domain.Events
{
    public class MemberCreatedEvent : BaseMemberEvent
    {
        public MemberCreatedEvent(string ID, DateTime Date, string FingerPrint, string Source) : base(ID, Date, FingerPrint, Source)
        {
        }
    }
}
