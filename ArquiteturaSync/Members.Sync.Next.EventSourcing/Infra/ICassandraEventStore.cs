using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DotzNext.EventStore;
using Members.Sync.Next.EventSourcing.Domain.Aggregates;
using Members.Sync.Next.EventSourcing.Domain.Events;

namespace Members.Sync.Next.EventSourcing.Infra
{
    public interface ICassandraEventStore : IEventStore<MemberAggregateRoot, BaseMemberEvent> 
    {
        Task SaveEventAsync(string aggregateId, string userID, string legacyID, BaseMemberEvent @event);
        Task<MemberAggregateRoot> GetAggregateAsync(Expression<Func<MemberAggregateRoot, bool>> predicate);
    }
}
