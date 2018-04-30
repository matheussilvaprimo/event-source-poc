using System;
using System.Threading.Tasks;
using Members.Sync.Next.EventSourcing.Domain.Aggregates;
using Members.Sync.Next.EventSourcing.Domain.Events;
using Members.Sync.Next.EventSourcing.Infra;

namespace Members.Sync.Next.EventSourcing.Domain.Handlers
{
    public class MemberCreatedHandler
    {
        public MemberCreatedHandler(ICassandraEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        private readonly ICassandraEventStore _eventStore;

        public async Task<bool> HandleEventAsync(MemberCreatedEvent @event)
        {
            if (@event == null)
            {
                return false;
            }

            try
            {
                var agg = _eventStore.GetAggregateAsync(x => x.MemberIdentifier == @event.Identifier && x.MemberIdentifierType == @event.IdentifierType).Result
                        ?? MemberAggregateRoot.New();

                bool handleEvent = !agg.HasEvent(@event);

                if (handleEvent)
                {
                    await _eventStore.SaveEventAsync("im an AggregateRoot ID", @event);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                //TODO: Handle Exceptions
                return false;
            }
        }
    }
}
