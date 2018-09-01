namespace ECommerce.Events.ValueObjects
{
    public class Product
    {
        public Product(string description, int quantity)
        {
            Description = description;
            Quantity = quantity;
        }

        public string Description { get; }
        public int Quantity { get; }
    }
}
