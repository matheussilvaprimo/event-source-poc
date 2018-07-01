using System.Threading.Tasks;
using Events;

namespace EventSourcing
{
    public interface IEventHandler<T> where T : BaseEvent
    {
        Task<bool> HandleEventAsync(T e);
    }
}
