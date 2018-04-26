using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dharma.EventSourcing
{
    public interface IEventStore
    {
        Task SaveEventAsync(string aggregateId, Event @event);       
        Task<List<Event>> GetEventsAsync(string aggregateId);
    }
}
