using System;
using System.Collections.Generic;
using ECommerce.EventSourcing;

namespace Sales.Domain.Entities
{
    public class SalesAggregateRootEntity : BaseAggregateRootEntity
    {
        public string UserName { get; private set; }
        public override void RebuildStateFromStream(List<IDomainEvent> domainEvents)
        {
            throw new NotImplementedException();
        }

        protected override void SerializeState()
        {
            throw new NotImplementedException();
        }
    }
}
