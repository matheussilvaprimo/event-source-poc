using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dharma.EventSourcing;

namespace Members.EventStore.Infra
{
    public class CassandraEventStore<TEvent> : ICassandraStore, IEventStore where TEvent : Event
    {
        public CassandraEventStore()
        {
            
        }

        public Task<TAggregate> GetAggregateAsync<TAggregate, TEvent1>(string aggregateID)
            where TAggregate : AggregateRoot<TEvent1>, new()
            where TEvent1 : Event
        {
            throw new NotImplementedException();
        }

        public Task<TAggregate> GetAggregateAsync<TAggregate, TEvent1>(Expression<Func<TAggregate, bool>> predicate)
            where TAggregate : AggregateRoot<TEvent1>, new()
            where TEvent1 : Event
        {
            throw new NotImplementedException();
        }

        public Task<List<Event>> GetEventsAsync(string aggregateId)
        {
            throw new NotImplementedException();
        }

        public Task InsertAggregateAsync<TAggregate, TEvent1>(TAggregate aggregate)
            where TAggregate : AggregateRoot<TEvent1>, new()
            where TEvent1 : Event
        {
            throw new NotImplementedException();
        }

        public Task SaveEventAsync(string aggregateId, Event @event)
        {
            throw new NotImplementedException();
        }        
    }
}
