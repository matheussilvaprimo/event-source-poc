using System;
using Dharma.EventSourcing;

namespace Members.EventStore
{
    public class MemberAggregateRoot : AggregateRoot<Event>
    {
        string MemberID { get; set; }
        string LegacyID { get; set; }
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
