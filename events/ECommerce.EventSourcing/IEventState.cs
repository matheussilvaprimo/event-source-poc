using System;

namespace ECommerce.EventSourcing
{
    public interface IEventState
    {
        DateTime EventDate { get; }
        void ApplyState(object target);
    }
}
