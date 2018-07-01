using System.Collections.Generic;

namespace EventSourcing
{
    public abstract class BaseAggregateRootEntity
    {
        private bool _commited { get; set; }
        public long Version { get; set; }

        public abstract void RebuildStateFromEventStream(IList<IEvent> events);
        protected abstract void SerializeState();

        protected virtual void CommitChanges()
        {
            if (!_commited)
            {
                Version++;
                _commited = true;
            }
        }
    }
}
