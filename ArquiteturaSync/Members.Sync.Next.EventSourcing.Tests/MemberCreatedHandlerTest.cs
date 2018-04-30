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
                                     .AddScoped<ICassandraEventStore, CassandraEventStore>()
                                     .AddScoped<CassandraProvider>()
                                     .BuildServiceProvider()
                                     .GetService<MemberCreatedHandler>();
        }

        [Fact]
        public void HandleMemberWithMessageNull()
        {
            var result = _handler.HandleMemberAsync(null);
            Assert.False(result.Result);
        }

        [Fact]
        public void HandleMemberWithMessage()
        {
            var @event = new MemberCreatedEvent("im an identifier", 0, string.Empty, "im an legacy id", "FooName", 30, "Im an cellnumber", DateTime.Parse("07-30-1990"),
                                           "Im an event type", null, "im an fingerprint", "Im an ID", DateTime.Now, "TEST");

            var result = _handler.HandleMemberAsync(@event);

            Assert.True(result.Result);
        }
    }
}