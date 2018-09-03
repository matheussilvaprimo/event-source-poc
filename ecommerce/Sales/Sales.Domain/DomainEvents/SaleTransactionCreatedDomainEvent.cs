using System;
using ECommerce.Events.Sales;
using ECommerce.Events.ValueObjects;
using ECommerce.EventSourcing;

namespace Sales.Domain.DomainEvents
{
    public class SaleTransactionCreatedDomainEvent : SaleTransactionCreatedEvent, IDomainEvent
    {
        public SaleTransactionCreatedDomainEvent(Order order, DeliveryDetails deliveryDetails) : base(order, deliveryDetails)
        {
        }

        public DateTime EventDate => EventDate;

        public void ApplyState(object target)
        {
            throw new NotImplementedException();
        }
    }
}
