using System;
using System.Collections.Generic;
using System.Linq;

namespace DotzNext.EventSourcing
{
    public abstract  class AggregateRoot<TEvent> where TEvent : Event
    {
        public string ID { get; set; }
        public List<TEvent> Events { get; set; }
        private long _version { get; set; }
        public long Version { get; private set; }
        private bool _commited { get; set; }

        /// <summary>
        /// Rebuilds the aggregate based on the event stream
        /// </summary>
        public abstract void RebuildEventStream();

        /// <summary>
        /// Adds an event to the stream
        /// </summary>
        /// <param name="e"></param>
        public abstract void AddEventToStream(TEvent e);

        /// <summary>
        /// This method increments the current Aggregate version plus one
        /// </summary>
        public void CommitChanges()
        {
            if (!_commited)
            {
                Version++;
                _commited = true;
            }
        }

        /// <summary>
        /// Verifies if the event stream has a specific event by its base date and source attributes
        /// </summary>
        /// <param name="e">event to be searched</param>
        /// <returns></returns>
        public abstract bool HasEvent(TEvent e);
    }
}
