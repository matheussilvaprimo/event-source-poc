using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Members.Sync.Next.EventSourcing.Domain.Aggregates;
using Members.Sync.Next.EventSourcing.Domain.Events;

namespace Members.Sync.Next.EventSourcing.Infra
{
    public class CassandraEventStore : ICassandraEventStore
    {
        private readonly CassandraProvider _provider;
        public CassandraEventStore(CassandraProvider provider)
        {
            _provider = provider;
        }

        public Task<MemberAggregateRoot> GetAggregateAsync(Func<MemberAggregateRoot, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BaseMemberEvent>> GetEventsAsync(string aggregateId)
        {
            throw new NotImplementedException();
        }

        public Task SaveAggregateAsync(MemberAggregateRoot aggregate)
        {
            throw new NotImplementedException();
        }

        public Task SaveEventAsync(BaseMemberEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
