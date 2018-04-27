using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DotzNext.EventSourcing;
using Members.Sync.EventSourcing.Domain.Aggregates;

namespace Members.Sync.EventSourcing.Infra
{
    public class CassandraEventStore<TEvent>
            where TEvent : Event
    {
        private readonly CassandraProvider _provider;
        public CassandraEventStore(CassandraProvider provider)
        {
            _provider = provider;
        }

        public Task<MemberAggregateRoot> GetAggregateAsync(Expression<Func<MemberAggregateRoot, bool>> predicate)
        {
            //var ret = _provider.FindSomeThingAsync()..
            throw new NotImplementedException();
        }

        public Task<List<Event>> GetEventsAsync(string aggregateId)
        {
            //var ret = _provider.FindSomeThingAsync()..
            throw new NotImplementedException();
        }

        public Task SaveAggregateAsync(MemberAggregateRoot aggregate)
        {
            //await_provider.InsertSomeThingAsync()..
            throw new NotImplementedException();
        }

        public Task SaveEventAsync(string aggregateId, Event @event)
        {
            //await _provider.SaveSomeThingAsync()..
            throw new NotImplementedException();
        }
    }
}
