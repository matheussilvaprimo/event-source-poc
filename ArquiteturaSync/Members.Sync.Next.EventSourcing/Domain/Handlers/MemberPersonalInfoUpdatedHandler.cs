using System.Threading.Tasks;
using Members.Sync.Next.EventSourcing.Domain.Events;
using Members.Sync.Next.EventSourcing.Infra;

namespace Members.Sync.Next.EventSourcing.Domain.Handlers
{
    public class MemberPersonalInfoUpdatedHandler
    {
        public MemberPersonalInfoUpdatedHandler(IMemberEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        private readonly IMemberEventStore _eventStore;

        public async Task HandleMemberAsync(MemberPersonalInfoUpdatedEvent @event)
        {
            //TODO: Tratar o evento
            await _eventStore.SaveEventAsync("im an AggregateRoot ID", @event);
        }
    }
}
