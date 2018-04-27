using System;
using Dharma.EventSourcing;

namespace Members.Consumer.EventSourcing.Domain.Aggregates
{
    public class MemberAggregateRoot : AggregateRoot<Event>
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

        public override void AddEventToStream(Event e)
        {
            throw new NotImplementedException();
        }

        public override void RebuildEventStream()
        {
            throw new NotImplementedException();
        }
    }
}
