using System;
using Members.Sync.Next.Services.Messages;

namespace Members.Sync.Next.EventSourcing.Domain.Events
{
    public static class EventMappers
    {
        public static AddressCreatedEvent MapFromMessage(this AddressCreatedMessage m, string memberIdentifier, string type, DateTime eventDate, string source)
        {
            return new AddressCreatedEvent(string.Empty, memberIdentifier, type, m.StreetName, m.StreetNumber, m.ReferencePoint,
                                            m.City, m.State, m.Country, m.DefaultAddress, type, "fingerprint here", "ID here", eventDate, source);
        }
    }
}
