using System.Threading.Tasks;

namespace Dharma.EventSourcing
{
    public interface IEventPublisher<TEvent> where TEvent : Event
    {
        Task PublishAsync(TEvent @event);
    }
}
