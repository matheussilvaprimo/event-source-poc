using Members.Sync.Next.EventSourcing.Domain.Aggregates;
using Members.Sync.Next.EventSourcing.Domain.Events;
using System;
using System.Linq;
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
        public void SaveAggregateWithoutAggregate()
        {
            _eventStore.SaveAggregateAsync(null).GetAwaiter().GetResult();
        }

        [Fact]
        public void SaveAggregateWithAggregateValid()
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

            _eventStore.SaveAggregateAsync(aggregate).GetAwaiter().GetResult();

            var agg = _eventStore.GetAggregateAsync(x => x.ID == aggregate.ID).Result;

            Assert.Equal(aggregate, agg);
        }

        [Fact]
        public void GetEventWithoutAggregate()
        {
            var list = _eventStore.GetEventsAsync(string.Empty).Result;

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
                                  "Im an event type", null, "im an fingerprint", "Im an ID", DateTime.Now, "TEST");

            aggregate.Events.Add(@event);

            _eventStore.SaveAggregateAsync(aggregate).GetAwaiter();

            var list = _eventStore.GetEventsAsync(aggregate.ID).Result;

            Assert.Single(list, @event);
        }

        [Fact]
        public void AddEventWithoutAggregate()
        {
            var @event = new MemberCreatedEvent("im an identifier", 0, string.Empty, "im an legacy id", "FooName", 30, "Im an cellnumber", DateTime.Parse("07-30-1990"),
                                  "Im an event type", null, "im an fingerprint", "Im an ID", DateTime.Now, "TEST");

            var ret = _eventStore.SaveEventAsync(string.Empty, @event);
            Assert.Null(ret);
        }

        [Fact]
        public void AddEventWithAggregateValid()
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

            _eventStore.SaveAggregateAsync(aggregate).GetAwaiter();

            var @event = new MemberCreatedEvent("im an identifier", 0, string.Empty, "im an legacy id", "FooName", 30, "Im an cellnumber", DateTime.Parse("07-30-1990"),
                                  "Im an event type", null, "im an fingerprint", "Im an ID", DateTime.Now, "TEST");

            _eventStore.SaveEventAsync(aggregate.ID, @event);

            var list = _eventStore.GetEventsAsync(aggregate.ID).Result;

            Assert.Single(list, @event);
            Assert.Equal(@event.ID, list.FirstOrDefault().ID);
        }
    }
}