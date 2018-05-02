using System;

namespace DotzNext.EventSourcing
{
    public abstract class Event: IEvent
    {
        public string ID { get; }
        public string AggregateID { get; }
        /// <summary>
        /// Date of the event
        /// </summary>
        public DateTime Date { get; }
        /// <summary>
        /// Source that generated this event
        /// </summary>
        public string Source { get; }

        public Event(string ID, string AggregateID, DateTime Date, string Source)
        {
            this.ID = ID;
            this.AggregateID = AggregateID;
            this.Date = Date;
            this.Source = Source;
        }

        public abstract Object GetVersion();
    }


    public interface IEvent
    {
        Object GetVersion();
    }
}
