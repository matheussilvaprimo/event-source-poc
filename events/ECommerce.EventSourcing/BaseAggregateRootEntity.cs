using System.Collections.Generic;

namespace ECommerce.EventSourcing
{
    public abstract class BaseAggregateRootEntity
    {
        private bool _commited { get; set; }

        /// <summary>
        /// Aggregate Version.
        /// </summary>
        public long Version { get; protected set; }

        /// <summary>
        /// Rebuilds the aggregate based on the event stream
        /// </summary>
        public abstract void RebuildStateFromStream(List<IDomainEvent> domainEvents);

        protected abstract void SerializeState();

        /// <summary>
        /// This method increments the current Aggregate's version.
        /// </summary>
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
