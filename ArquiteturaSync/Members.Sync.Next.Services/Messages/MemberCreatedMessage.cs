using System.Collections.Generic;

namespace Members.Sync.Next.Services.Messages
{
    public class MemberCreatedMessage
    {
        public List<AddressCreatedMessage> Addresses { get; set; }
    }

    public class AddressCreatedMessage
    {
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }
        public string ReferencePoint { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public bool DefaultAddress { get; set; }
        public string Type { get; set; }
    }
}