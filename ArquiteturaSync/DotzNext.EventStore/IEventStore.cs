using System.Collections.Generic;
using System.Threading.Tasks;
using DotzNext.EventSourcing;

namespace DotzNext.EventStore
{
    public interface IEventStore<TAggregate, TEvent> where TAggregate : AggregateRoot<TEvent>, new() where TEvent : Event
    {
        Task<IEnumerable<TEvent>> GetEventsAsync(string aggregateId);
        Task SaveAggregateAsync(TAggregate aggregate);
        Task SaveEventAsync(string aggregateId, TEvent @event);
    }
}
