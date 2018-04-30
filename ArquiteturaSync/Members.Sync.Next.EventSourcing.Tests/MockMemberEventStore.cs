using DotzNext.EventStore;
using Members.Sync.Next.EventSourcing.Domain.Aggregates;
using Members.Sync.Next.EventSourcing.Domain.Events;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Members.Sync.Next.EventSourcing.Tests
{
    public class MockEventStore : IEventStore<MemberAggregateRoot, BaseMemberEvent>
    {
        public MockEventStore()
        {
            _aggregates = new List<MemberAggregateRoot>();
        }

        private static List<MemberAggregateRoot> _aggregates;

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
    }
}