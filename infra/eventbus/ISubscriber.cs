using System;
using System.Collections.Generic;
using System.Text;

namespace EventBus
{
    public interface ISubscriber<T>
        where T : Message
    {
        bool IsRunning();

        void StartConsume(Func<T, bool> factory);
    }
}
