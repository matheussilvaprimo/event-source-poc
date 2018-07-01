using System;

namespace EventSourcing
{
    public interface IEvent
    {
        DateTime EventDate { get; }
        void ApplyState(object target);
    }
}
