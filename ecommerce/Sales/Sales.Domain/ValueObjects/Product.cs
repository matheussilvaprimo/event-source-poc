namespace Sales.Domain.ValueObjects
{
    public class Product
    {
        public string Description { get; private set; }
        public int Quantity { get; private set; }

        internal void SetProductDescription(string description)
        {
            Description = description;
        }

        internal void SetProductQuantity(int quantity)
        {
            Quantity = quantity;
        }
    }
}
