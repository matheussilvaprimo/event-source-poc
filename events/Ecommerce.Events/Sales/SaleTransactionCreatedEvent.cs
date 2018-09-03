using ECommerce.Events.ValueObjects;

namespace ECommerce.Events.Sales
{
    public class SaleTransactionCreatedEvent
    {
        public SaleTransactionCreatedEvent(Order order, DeliveryDetails deliveryDetails)
        {
            Order = order;
            DeliveryDetails = deliveryDetails;
        }

        public Order Order {get;}
        public DeliveryDetails DeliveryDetails { get; }
    }
}
