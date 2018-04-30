using Members.Sync.Next.EventSourcing.Domain.Aggregates;
using Members.Sync.Next.EventSourcing.Domain.Events;
using System;
using Xunit;

namespace Members.Sync.Next.EventSourcing.Tests
{
    public class MemberEventStoreTest
    {
        private MockEventStore _eventStore;

        public MemberEventStoreTest()
        {
            _eventStore = new MockEventStore();
        }

        [Fact]
        public void GetEventWithoutAggregateValid()
        {
            var id = Guid.NewGuid().ToString();
            var list = _eventStore.GetEventsAsync(id).Result;

            Assert.Empty(list);
        }

        [Fact]
        public void GetEventWithAggregateValid()
        {
            var aggregate = new MemberAggregateRoot()
            {
                ID = "im am a id",
                Addresses = "im am a adress",
                Member = "i am a member",
                LegacyID = "im an legacy id",
                MemberID = "i an MemberId",
                Events = new System.Collections.Generic.List<BaseMemberEvent>(),
                AddressState = new System.Collections.Generic.List<Address>(),
            };

            var @event = new MemberCreatedEvent("im an identifier", 0, string.Empty, "im an legacy id", "FooName", 30, "Im an cellnumber", DateTime.Parse("07-30-1990"),
                                  "Im an event type", "im an fingerprint", "Im an ID", DateTime.Now, "TEST");

            aggregate.Events.Add(@event);

            _eventStore.SaveAggregateAsync(aggregate).GetAwaiter();
            var list = _eventStore.GetEventsAsync(aggregate.ID).Result;

            Assert.Single(list, @event);
        }
    }
}