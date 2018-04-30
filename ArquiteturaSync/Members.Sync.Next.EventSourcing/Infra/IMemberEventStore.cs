using Members.Sync.Next.EventSourcing.Domain.Aggregates;
using Members.Sync.Next.EventSourcing.Domain.Events;

namespace Members.Sync.Next.EventSourcing.Infra
{
    public interface IMemberEventStore : ICassandraEventStore<MemberAggregateRoot, BaseMemberEvent>
    {
    }
}
