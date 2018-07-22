using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using EventSourcing;
using EventStore;
using Newtonsoft.Json;
using User.BackOffice.EventSourcing.VOs;

namespace User.BackOffice.EventSourcing.Entities
{
    public class UserAggregateRootEntity : BaseAggregateRootEntity
    {
        [NotMapped]
        private string _aggregateState { get; set; }
        [NotMapped]
        public string AggregateState { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
        [IndexedProperty]
        public string UserName { get; set; }
        [NotMapped]
        public UserInformation UserInfo { get; set; }
        [NotMapped]
        public Address Address { get; set; }
        [NotMapped]
        public CellPhone CellPhone { get; set; }
        public override void RebuildStateFromEventStream(IList<IEvent> events)
        {
            if (events?.Count == 0) return;

            events.OrderBy(x => x.EventDate).ToList().ForEach(x =>
            {
                x.ApplyState(this);
            });

            SerializeState();
            CommitChanges();
        }

        protected override void CommitChanges()
        {
            if (string.IsNullOrWhiteSpace(_aggregateState)) return;
            if (AggregateState != _aggregateState)
            {
                AggregateState = _aggregateState;
                base.CommitChanges();
            }
        }

        protected override void SerializeState()
        {
            _aggregateState = JsonConvert.SerializeObject(this);
        }
    }
}
