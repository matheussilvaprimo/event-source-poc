using System.Collections.Generic;

namespace Sales.Domain.ValueObjects
{
    public class Sale
    {
        public string UserName { get; private set; }
        public List<Product> Products { get; private set; }

        internal void SetUserName(string userName)
        {
            UserName = userName;
        }

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
