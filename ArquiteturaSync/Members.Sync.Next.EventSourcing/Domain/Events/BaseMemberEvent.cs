using System;
using System.Collections.Generic;
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

        public override bool Equals(object obj)
        {
            var x = obj as BaseMemberEvent;

            if (x == null) return false;

            return x.Date.Equals(Date) && x.GetVersion().Equals(GetVersion());            
        }

        public override int GetHashCode()
        {
            var hashCode = 735347539;
            hashCode = hashCode * -1521134295 + EqualityComparer<DateTime>.Default.GetHashCode(Date);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FingerPrint);
            return hashCode;
        }
    }
}
