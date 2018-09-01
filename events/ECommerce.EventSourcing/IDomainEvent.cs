using System;

namespace ECommerce.EventSourcing
{
    public interface IDomainEvent
    {
        DateTime EventDate { get; }
        void ApplyState(object target);
    }
}
