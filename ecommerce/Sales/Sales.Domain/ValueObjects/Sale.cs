using System.Collections.Generic;

namespace Sales.Domain.ValueObjects
{
    public class Order
    {
        public List<Product> Products { get; private set; }

        internal void AddProductToList(Product product)
        {
            if (Products == null) Products = new List<Product>();
            Products.Add(product);
        }

        internal void SetProductLists(List<Product> products)
        {
            Products = products;
        }
    }
}
