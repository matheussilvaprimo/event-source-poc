using System;
using System.Collections.Generic;

namespace Members.Sync.Next.EventSourcing.Domain.Aggregates
{
    public class Member
    {
        public string ID { get; set; }
        public string LegacyID { get; set; }
        public string FullName { get; set; }
        public long Age { get; set; }
        public string CellNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
