using System.Collections.Generic;

namespace ECommerce.Events.ValueObjects
{
    public class Order
    {
        public Order(string invoiceCode, string customerUserName, List<Product> products)
        {
            InvoiceCode = invoiceCode;
            CustomerUserName = customerUserName;
            Products = products;
        }

        public string InvoiceCode { get; }
        public string CustomerUserName { get; }
        public List<Product> Products { get; }
    }
}
