using System.Threading.Tasks;
using Dharma.EventSourcing;
using Members.EventStore.Domain.Events;

namespace Members.EventStore.Domain.Handlers
{
    public class MemberCreatedHandler
    {
        public MemberCreatedHandler(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        private readonly IEventStore _eventStore;

        public async Task HandleMemberAsync(MemberCreatedEvent @event)
        {
            //TODO: Tratar o evento
            await _eventStore.SaveEventAsync("im an AggregateRoot ID", @event);
        }
    }
}
