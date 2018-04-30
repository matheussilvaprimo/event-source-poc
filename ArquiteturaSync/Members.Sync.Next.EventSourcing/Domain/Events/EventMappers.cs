using System;
using System.Collections.Generic;
using Members.Sync.Next.Services.Messages;

namespace Members.Sync.Next.EventSourcing.Domain.Events
{
    public static class EventMappers
    {
        public static AddressCreatedEvent MapFromMessage(this AddressCreatedMessage m, string memberIdentifier, int mIdentType, DateTime eventDate, string source)
        {
            return new AddressCreatedEvent(string.Empty, memberIdentifier, mIdentType, m.StreetName, m.StreetNumber, m.ReferencePoint,
                                            m.City, m.State, m.Country, m.DefaultAddress, m.Type, "fingerprint here", "ID here", eventDate, source);
        }

        public static MemberCreatedEvent MapFromMessage(this MemberCreatedMessage m)
        {
            var memberID = !string.IsNullOrEmpty(m.MemberID) ? m.MemberID : string.Empty;
            var legacyID = !string.IsNullOrEmpty(m.LegacyID) ? m.LegacyID : string.Empty;
            var addresses = new List<AddressCreatedEvent>();

            m?.Addresses.ForEach(x => 
            {
                addresses.Add(x.MapFromMessage(m.Identifier, m.IdentifierType, m.EventDate, m.Source));
            });

            return new MemberCreatedEvent(m.Identifier, m.IdentifierType, memberID, legacyID, m.FullName, m.Age, 
                                          m.CellNumber, m.DateOfBirth, m.EventType, addresses, "fingerprint here", "ID here", m.EventDate, m.Source);
        }
    }
}
