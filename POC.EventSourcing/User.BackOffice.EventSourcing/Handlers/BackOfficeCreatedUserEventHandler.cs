using System.Threading.Tasks;
using Events;
using EventSourcing;
using User.BackOffice.EventSourcing.ProxyEvents;

namespace User.BackOffice.EventSourcing.Handlers
{
    public class BackOfficeCreatedUserEventHandler : IEventHandler
    {
        public async Task<bool> HandleEventAsync<T>(T e) where T : BaseEvent
        {
            if(e is UserCreatedEvent @event)
            {
                var proxyEvent = new BackOfficeCreatedUserEvent(@event.UserInformation, @event.RegistrationAddress, @event.UserName, @event.EventDate, 
                                                                @event.Source, @event.Version);

            }

            //return true so the invalid event gets taken out the queue
            return true;
        }
    }
}
