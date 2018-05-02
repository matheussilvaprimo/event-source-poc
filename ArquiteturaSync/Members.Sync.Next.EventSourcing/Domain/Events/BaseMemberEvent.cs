using System;
using DotzNext.EventSourcing;

namespace Members.Sync.Next.EventSourcing.Domain.Events
{
    public class BaseMemberEvent : Event
    {
        public BaseMemberEvent(string memberIdentifier, int memberIdentifierType,  string fingerPrint, 
                               string ID, string AggregateID, DateTime Date, string Source) : base(ID, AggregateID, Date, Source)
        {
            MemberIdentifier = memberIdentifier;
            MemberIdentifierType = memberIdentifierType;
            FingerPrint = fingerPrint;
        }
        public string MemberIdentifier { get; }
        public int MemberIdentifierType { get; }
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
