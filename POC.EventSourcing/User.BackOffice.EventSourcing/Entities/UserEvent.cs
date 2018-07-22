using System;
using EventStore;

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
        public DateTime Date { get; set; }
        public string Source { get; set; }
        public string QualifiedName { get; set; }
        [IndexedProperty]
        public string EventType { get; set; }
        public string State { get; set; }
    }
}
