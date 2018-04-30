using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Members.Sync.Next.EventSourcing.Domain.Aggregates;
using Members.Sync.Next.EventSourcing.Domain.Events;
using Members.Sync.Next.EventSourcing.Infra;

namespace Members.Sync.Next.EventSourcing.Tests
{
    public class MockEventStore : ICassandraEventStore
    {
        public MockEventStore()
        {
            //TODO: Implement seed
            _aggregates = new List<MemberAggregateRoot>();
            _events = new List<BaseMemberEvent>();
        }

        private static List<MemberAggregateRoot> _aggregates;
        private static List<BaseMemberEvent> _events;

        public async Task<IEnumerable<BaseMemberEvent>> GetEventsAsync(string aggregateId)
        {
            return await Task.Run(() => _aggregates.Where(x => x.ID == aggregateId).SelectMany(e => e.Events).ToList());
        }

        public async Task SaveAggregateAsync(MemberAggregateRoot aggregate)
        {
            await Task.Run(() => _aggregates.Add(aggregate));
        }

        public Task SaveEventAsync(string aggregateId, BaseMemberEvent @event)
        {
            var aggregate = _aggregates.FirstOrDefault(x => x.ID == aggregateId);
            if (aggregate == null) return null;

            return Task.Run(() => aggregate.AddEventToStream(@event));
        }

        public async Task SaveEventAsync(BaseMemberEvent @event)
        {
            await Task.Run(() => { _events.Add(@event); });
        }

        public async Task<MemberAggregateRoot> GetAggregateAsync(Func<MemberAggregateRoot, bool> predicate)
        {
            return await Task.Run(() => { return _aggregates.FirstOrDefault(predicate); });
        }
    }
}
