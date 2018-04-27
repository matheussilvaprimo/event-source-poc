using System.Threading.Tasks;
using Members.Sync.EventSourcing.Domain.Events;
using Members.Sync.EventSourcing.Infra;

namespace Members.Sync.EventSourcing.Domain.Handlers
{
    public class MemberCreatedHandler
    {
        public MemberCreatedHandler(CassandraEventStore<MemberCreatedEvent> eventStore)
        {
            _eventStore = eventStore;
        }

        private readonly CassandraEventStore<MemberCreatedEvent> _eventStore;

        public async Task HandleMemberAsync(MemberCreatedEvent @event)
        {
            //TODO: Tratar o evento
            await _eventStore.SaveEventAsync("im an AggregateRoot ID", @event);
        }
    }
}
