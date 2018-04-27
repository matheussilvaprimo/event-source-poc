using System;
using Dharma.EventSourcing;

namespace Members.EventStore.Domain.Events
{
    public class BaseMemberEvent : Event
    {
        public BaseMemberEvent(string ID, DateTime Date, string FingerPrint, string Source) : base(ID, Date, FingerPrint, Source) { }
    }
}
