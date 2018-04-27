using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dharma.EventSourcing;
using Members.Sync.EventSourcing.Domain.Aggregates;

namespace Members.Sync.EventSourcing.Infra
{
    public class CassandraEventStore<TEvent>
            where TEvent : Event
    {
        public CassandraEventStore()
        {

        }

        public Task<MemberAggregateRoot> GetAggregateAsync(Expression<Func<MemberAggregateRoot, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<Event>> GetEventsAsync(string aggregateId)
        {
            throw new NotImplementedException();
        }

        public Task InsertAggregateAsync(MemberAggregateRoot aggregate)
        {
            throw new NotImplementedException();
        }

        public Task SaveEventAsync(string aggregateId, Event @event)
        {
            throw new NotImplementedException();
        }
    }
}
