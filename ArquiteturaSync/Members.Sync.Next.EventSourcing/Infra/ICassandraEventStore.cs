using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DotzNext.EventSourcing;
using DotzNext.EventStore;

namespace Members.Sync.Next.EventSourcing.Infra
{
    public interface ICassandraEventStore<TAggregate, TEvent> : IEventStore<TAggregate, TEvent> 
                                    where TAggregate : AggregateRoot<TEvent>, new() where TEvent : Event
    {
        Task SaveEventAsync(string aggregateId, string userID, string legacyID, TEvent @event);
        Task<TAggregate> GetAggregateAsync(Expression<Func<TAggregate, bool>> predicate);
    }
}
