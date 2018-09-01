using ECommerce.Events.ValueObjects;

namespace ECommerce.Events.Shipment
{
    public class ShipmentOrderCreatedEvent
    {
        public ShipmentOrderCreatedEvent(Order order, DeliveryDetails deliveryDetails)
        {
            Order = order;
            DeliveryDetails = deliveryDetails;
        }

        public Order Order {get;}
        public DeliveryDetails DeliveryDetails { get; }
    }
}
