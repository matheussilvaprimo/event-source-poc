using System.Threading.Tasks;
using DotzNext.EventSourcing;

namespace DotzNext.EventBus
{
    public interface IEventBus<TEvent> where TEvent : Event
    {
        Task<bool> PublishEventAsync(TEvent @event);        
    }
}
