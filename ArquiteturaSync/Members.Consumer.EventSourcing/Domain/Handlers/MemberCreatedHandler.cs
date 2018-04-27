using System.Threading.Tasks;
using Members.Consumer.EventSourcing.Domain.Events;
using Members.Consumer.EventSourcing.Infra;

namespace Members.Consumer.EventSourcing.Domain.Handlers
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
