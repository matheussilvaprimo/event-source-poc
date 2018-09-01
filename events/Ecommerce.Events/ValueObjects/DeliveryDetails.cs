namespace ECommerce.Events.ValueObjects
{
    public class DeliveryDetails
    {
        public DeliveryDetails(string recipient, Address deliveryAddress)
        {
            Recipient = recipient;
            DeliveryAddress = deliveryAddress;
        }

        public string Recipient { get; }
        public Address DeliveryAddress { get; }
    }
}
