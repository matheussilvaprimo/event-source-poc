using Members.Sync.Next.EventSourcing.Domain.Aggregates;
using Members.Sync.Next.EventSourcing.Domain.Events;

namespace Members.Sync.Next.EventSourcing.Tests
{
    public class MockMemberAggregateRoot : MemberAggregateRoot
    {
        public override void AddEventToStream(BaseMemberEvent e)
        {
            Events.Add(e);
        }        
    }
}