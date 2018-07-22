using System.Threading.Tasks;
using Events;

namespace EventSourcing
{
    public interface IEventHandler
    {
        Task<bool> HandleEventAsync<T>(T e) where T : BaseEvent;
    }
}
