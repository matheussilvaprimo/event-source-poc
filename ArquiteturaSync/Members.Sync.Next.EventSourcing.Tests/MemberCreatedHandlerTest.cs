using Members.Sync.Next.EventSourcing.Domain.Events;
using Members.Sync.Next.EventSourcing.Domain.Handlers;
using Members.Sync.Next.EventSourcing.Infra;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace Members.Sync.Next.EventSourcing.Tests
{
    public class MemberCreatedHandlerTest
    {
        private MemberCreatedHandler _handler;

        public MemberCreatedHandlerTest()
        {
            _handler = new ServiceCollection()
                                     .AddScoped<MemberCreatedHandler>()
                                     .AddScoped<ICassandraEventStore, MockEventStore>()
                                     .AddScoped<CassandraProvider>()
                                     .BuildServiceProvider()
                                     .GetService<MemberCreatedHandler>();
        }

        [Fact]
        public void HandleMemberWithMessageNull()
        {
            var result = _handler.HandleEventAsync(null);
            Assert.False(result.Result);
        }

        [Fact]
        public void HandleMemberWithMessageValid()
        {
            var @event = new MemberCreatedEvent(CassandraUtils.GenerateTimeUUID(), 0, string.Empty, CassandraUtils.GenerateTimeUUID(), "FooName", 30, "Im an cellnumber", DateTime.Parse("07-30-1990"),
                                           "Im an event type", null, "im an fingerprint", CassandraUtils.GenerateTimeUUID(), CassandraUtils.GenerateTimeUUID(), DateTime.Now, "TEST");

            var result = _handler.HandleEventAsync(@event);

            Assert.True(result.Result);
        }

        [Fact]
        public void HandleMemberWithDuplicatedEvent()
        {
            var @event = new MemberCreatedEvent(CassandraUtils.GenerateTimeUUID(), 0, string.Empty, CassandraUtils.GenerateTimeUUID(), "FooName", 30, "Im an cellnumber", DateTime.Parse("07-30-1990"),
                                           "Im an event type", null, "im an fingerprint", CassandraUtils.GenerateTimeUUID(), DateTime.Now, "TEST");

            _handler.HandleEventAsync(@event).GetAwaiter().GetResult();

            var result = _handler.HandleEventAsync(@event);

            Assert.False(result.Result);
        }

        [Fact]
        public void HandleMemberWithDuplicatedEventWithDiferentDate()
        {
            var @event = new MemberCreatedEvent(CassandraUtils.GenerateTimeUUID(), 0, string.Empty, CassandraUtils.GenerateTimeUUID(), "FooName", 30, "Im an cellnumber", DateTime.Parse("07-30-1990"),
                                           "Im an event type", null, "im an fingerprint", CassandraUtils.GenerateTimeUUID(), DateTime.Now.Date.AddMinutes(-1), "TEST");

            _handler.HandleEventAsync(@event).GetAwaiter().GetResult();

            var @event2 = new MemberCreatedEvent(CassandraUtils.GenerateTimeUUID(), 0, string.Empty, CassandraUtils.GenerateTimeUUID(), "FooName", 30, "Im an cellnumber", DateTime.Parse("07-30-1990"),
                                                        "Im an event type", null, "im an fingerprint", CassandraUtils.GenerateTimeUUID(), DateTime.Now, "TEST");

            var result = _handler.HandleEventAsync(@event2);

            Assert.True(result.Result);
        }

        [Fact]
        public void HandleMemberWithDiferentEvent()
        {
            var @event = new MemberCreatedEvent(CassandraUtils.GenerateTimeUUID(), 0, string.Empty, CassandraUtils.GenerateTimeUUID(), "FooName", 30, "Im an cellnumber", DateTime.Parse("07-30-1990"),
                                           "Im an event type", null, "im an fingerprint", CassandraUtils.GenerateTimeUUID(), DateTime.Now, "TEST");

            _handler.HandleEventAsync(@event).GetAwaiter().GetResult();
            var result = _handler.HandleEventAsync(@event);

            Assert.False(result.Result);
        }
    }
}