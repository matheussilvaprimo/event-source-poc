using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventBus
{
    public interface IPublisher
    {
        bool IsActive();

        Task PublishAsync<T>(T message, string topic = null) where T : Message;
    }
}
