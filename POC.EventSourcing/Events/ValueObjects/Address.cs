namespace Events.ValueObjects
{
    public class Address
    {
        public Address(string streetName, string addressNumber, string additionalInformation, string city, string state,
                       string country, string district, string postalCode, string referencePoint)
        {
            StreetName = streetName;
            AddressNumber = addressNumber;
            AdditionalInformation = additionalInformation;
            City = city;
            State = state;
            Country = country;
            District = district;
            PostalCode = postalCode;
            ReferencePoint = referencePoint;
        }

        public string StreetName { get; }
        public string AddressNumber { get; }
        public string AdditionalInformation { get; }
        public string City { get; }
        public string State { get; }
        public string Country { get; }
        public string District { get; }
        public string PostalCode { get; }
        public string ReferencePoint { get; }
    }
}
