using System;
using System.Collections.Generic;
using DotzNext.EventSourcing;
using Members.Sync.Next.EventSourcing.Domain.Events;

namespace Members.Sync.Next.EventSourcing.Domain.Aggregates
{
    public class MemberAggregateRoot : AggregateRoot<BaseMemberEvent>
    {
        public string MemberID { get; set; }
        public string LegacyID { get; set; }

        /// <summary>
        /// This property contains the current Member state rebuilt by the event stream serialized
        /// </summary>
        public string Member { get; set; }

        /// <summary>
        /// This property contains the current Member Addresses state rebuilt by the event stream serialized
        /// </summary>
        public string Addresses { get; set; }
        /// <summary>
        /// This property contains the current Member state rebuilt by the event stream deserialized 
        /// </summary>
        public Member MemberState { get; set; }
        /// <summary>
        /// This property contains the current Addresses state rebuilt by the event stream deserialized
        /// </summary>
        public List<Address> AddressState { get; set; }

        public override void AddEventToStream(BaseMemberEvent e)
        {
            throw new NotImplementedException();
        }

        public override void RebuildEventStream()
        {
            throw new NotImplementedException();
        }
    }
}
