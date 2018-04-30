using System;

namespace Members.Sync.Next.Services.Messages
{
    public class MemberUpdatedMessage
    {
        public string Identifier { get; set; }
        public int IdentifierType { get; set; }
        public string MemberID { get; set; }
        public string LegacyID { get; set; }
        public string FullName { get; set; }
        public long Age { get; set; }
        public string CellNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EventType { get; set; }
        public DateTime EventDate { get; set; }
        public string Source { get; set; }
    }
}
