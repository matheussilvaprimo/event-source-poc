using System.Collections.Generic;
using System.Linq;
using ECommerce.EventSourcing;
using Sales.Domain.ValueObjects;

namespace Sales.Domain.Entities
{
    public class SaleAggregateRootEntity : BaseAggregateRootEntity
    {
        public string UserName { get; private set; }
        public Order Order { get; private set; }
        public DeliveryDetails DeliveryDetails { get; private set; }
        public override void RebuildStateFromStream(List<IDomainEvent> domainEvents)
        {
            domainEvents.OrderBy(e => e.EventDate).ToList().ForEach(x =>
            {
                x.ApplyState(this);
            });
        }
    }
}
