using System;
using Members.Sync.Next.EventSourcing.Domain.Aggregates;
using Members.Sync.Next.EventSourcing.Domain.Events;
using Xunit;

namespace Members.Sync.Next.EventSourcing.Tests
{
    public class MemberAggregateRootTests
    {
        [Fact]
        public void AddMemberCreatedEventToAggregateRootStreamTest()
        {
            var e = new MemberCreatedEvent("im an identifier", 0, string.Empty, "im an legacy id", "FooName", 30, "Im an cellnumber", DateTime.Parse("07-30-1990"), 
                                           "Im an event type", null,"im an fingerprint", "Im an ID", DateTime.Now, "TEST");
            var agg = MemberAggregateRoot.New();
            agg.AddEventToStream(e);

            Assert.Contains(agg.Events, x => x.ID == e.ID);
        }

        [Fact]
        public void AddMemberUpdatedEventToExistingAggregateRootStreamTest()
        {

        }

        [Fact]
        public void RebuildUnordedMemberAggregateRootStreamTest()
        {

        }
    }
}
