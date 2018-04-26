using System;
using Dharma.EventSourcing;

namespace Members.EventStore
{
    public class CommonMemberEvent : Event
    {
        public CommonMemberEvent(string ID, DateTime Date, string FingerPrint, string Source) : base(ID, Date, FingerPrint, Source) { }
    }
}
