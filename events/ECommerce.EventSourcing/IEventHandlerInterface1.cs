using System.Threading.Tasks;
using Ecommerce.Events;

namespace ECommerce.EventSourcing
{
    public interface IEventHandler<TEvent> where TEvent : Event
    {
        bool HandleEvent(TEvent e);
        Task<bool> HandleEventAsync(TEvent e);
    }
}
