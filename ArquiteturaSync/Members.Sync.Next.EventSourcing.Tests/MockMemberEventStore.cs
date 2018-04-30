using DotzNext.EventStore;
using Members.Sync.Next.EventSourcing.Domain.Events;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Members.Sync.Next.EventSourcing.Tests
{
    public class MockMemberEventStore : IEventStore<MockMemberAggregateRoot, BaseMemberEvent>
    {
        private static List<MockMemberAggregateRoot> _aggregates = new List<MockMemberAggregateRoot>();

        public Task<IEnumerable<BaseMemberEvent>> GetEventsAsync(string aggregateId)
        {
            return Task.Run(() => _aggregates.AsQueryable().Where(x => x.ID == aggregateId).SelectMany(x => x.Events).AsEnumerable());
        }

        public Task SaveAggregateAsync(MockMemberAggregateRoot aggregate)
        {
            return Task.Run(() => _aggregates.Add(aggregate));
        }

        public Task SaveEventAsync(string aggregateId, BaseMemberEvent @event)
        {
            var aggregate = _aggregates.FirstOrDefault(x => x.ID == aggregateId);
            if (aggregate == null) return null;

            return Task.Run(() => aggregate.AddEventToStream(@event));
        }
    }
}