using System;
using EventStore.Attributes;

namespace User.BackOffice.EventSourcing.Entities
{
    public class UserEvent
    {
        public UserEvent(DateTime date, string source, string qualifiedName, string eventType, string state)
        {
            Date = date;
            Source = source;
            QualifiedName = qualifiedName;
            EventType = eventType;
            State = state;
        }

        public Guid Id { get; set; } = Guid.NewGuid();

        public string Source { get; set; }
        public string QualifiedName { get; set; }

        [IndexedProperty]
        [QueryableField(Order = 1)]
        public string UserName { get; set; }

        [IndexedProperty]
        [QueryableField(Order = 2)]
        public string EventType { get; set; }

        [IndexedProperty]
        [QueryableField(Order = 3)]
        public DateTime Date { get; set; }
        public string State { get; set; }
    }
}
