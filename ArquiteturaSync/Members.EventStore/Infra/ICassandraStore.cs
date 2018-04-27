using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dharma.EventSourcing;

namespace Members.EventStore.Infra
{
    public interface ICassandraStore
    {
        Task InsertAggregateAsync<TAggregate, TEvent>(TAggregate aggregate) where TAggregate : AggregateRoot<TEvent>, new() where TEvent : Event;
        Task<TAggregate> GetAggregateAsync<TAggregate, TEvent>(string aggregateID) where TAggregate : AggregateRoot<TEvent>, new() where TEvent : Event;
        Task<TAggregate> GetAggregateAsync<TAggregate, TEvent>(Expression<Func<TAggregate, bool>> predicate) where TAggregate : AggregateRoot<TEvent>, new() where TEvent : Event;
    }
}
