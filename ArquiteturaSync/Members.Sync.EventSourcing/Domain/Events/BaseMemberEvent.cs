using System;
using DotzNext.EventSourcing;

namespace Members.Sync.EventSourcing.Domain.Events
{
    public class BaseMemberEvent : Event
    {
        public BaseMemberEvent(string fingerPrint, string ID, DateTime Date, string Source) : base(ID, Date, Source)
        {
            FingerPrint = fingerPrint;
        }

        /// <summary>
        /// Finger print of the message that generated this event
        /// </summary>
        protected string FingerPrint { get; }

        public override Object GetVersion()
        {
            return FingerPrint;
        }
    }
}
