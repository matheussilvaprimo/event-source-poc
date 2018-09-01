namespace Ecommerce.Events.ValueObjects
{
    public class Address
    {
        public Address(string street, string number, string postalCode, string city, string state, string country, string alias)
        {
            Street = street;
            Number = number;
            PostalCode = postalCode;
            City = city;
            State = state;
            Country = country;
            Alias = alias;
        }

        public string Street { get; }
        public string Number { get; }
        public string PostalCode { get; }
        public string City { get; }
        public string State { get; }
        public string Country { get; }
        public string Alias { get; }
    }
}
