using System;
using System.Collections.Generic;
using System.Linq;
using EventSourcing;
using Newtonsoft.Json;
using User.BackOffice.EventSourcing.VOs;

namespace User.BackOffice.EventSourcing.Aggregates
{
    public class UserAggregateRootEntity : BaseAggregateRootEntity
    {
        private string _aggregateState { get; set; }
        public string AggregateState { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
        public UserInformation UserInfo { get; set; }
        public List<Address> Addresses { get; set; }
        public List<CellPhone> CellPhones { get; set; }
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
