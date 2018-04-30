using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

        public Task<MemberAggregateRoot> GetAggregateAsync(Expression<Func<MemberAggregateRoot, bool>> predicate)
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

        public Task SaveEventAsync(string aggregateId, string userID, string legacyID, BaseMemberEvent @event)
        {
            throw new NotImplementedException();
        }

        public Task SaveEventAsync(string aggregateId, BaseMemberEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
