using System;
using System.Collections.Generic;
using System.Linq;
using ECommerce.EventSourcing;
using Sales.Domain.ValueObjects;

namespace Sales.Domain.Entities
{
    public class SalesAggregateRootEntity : BaseAggregateRootEntity
    {
        public string UserName { get; private set; }
        public List<Sale> Sales { get; private set; }
        public override void RebuildStateFromStream(List<IDomainEvent> domainEvents)
        {
            domainEvents.OrderBy(e => e.EventDate).ToList().ForEach(x =>
            {
                x.ApplyState(this);
            });
        }

        protected override void SerializeState()
        {
            throw new NotImplementedException();
        }
    }
}
