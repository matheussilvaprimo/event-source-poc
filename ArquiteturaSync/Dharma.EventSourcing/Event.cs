using System;

namespace Dharma.EventSourcing
{
    public abstract class Event
    {
        public string ID { get; }
        /// <summary>
        /// Date of the event
        /// </summary>
        public DateTime Date { get; }
        /// <summary>
        /// Finger print of the message that generated this event
        /// </summary>
        public string FingerPrint { get; }
        /// <summary>
        /// Source that generated this event
        /// </summary>
        public string Source { get; }

        public Event(string ID, DateTime Date, string FingerPrint, string Source)
        {
            //TODO: Validar necessidade de ter um ID para o evento
            this.ID = ID;
            this.Date = Date;
            this.FingerPrint = FingerPrint;
            this.Source = Source;
        }
    }
}
