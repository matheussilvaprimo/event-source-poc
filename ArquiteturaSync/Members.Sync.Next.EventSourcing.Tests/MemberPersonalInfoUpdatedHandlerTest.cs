using Members.Sync.Next.EventSourcing.Domain.Events;
using Members.Sync.Next.EventSourcing.Domain.Handlers;
using Members.Sync.Next.EventSourcing.Infra;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace Members.Sync.Next.EventSourcing.Tests
{
    public class MemberPersonalInfoUpdatedHandlerTest
    {
        private MemberPersonalInfoUpdatedHandler _handler;

        public MemberPersonalInfoUpdatedHandlerTest()
        {
            _handler = new ServiceCollection()
                                     .AddScoped<MemberPersonalInfoUpdatedHandler>()
                                     .AddScoped<ICassandraEventStore, MockEventStore>()
                                     .AddScoped<CassandraProvider>()
                                     .BuildServiceProvider()
                                     .GetService<MemberPersonalInfoUpdatedHandler>();
        }

        [Fact]
        public void HandlePersonalInfoWithMessageNull()
        {
            var result = _handler.HandleEventAsync(null);
            Assert.False(result.Result);
        }

        [Fact]
        public void HandlePersonalInfoWithMessageValid()
        {

            //var @event = new MemberPersonalInfoUpdatedEvent(CassandraUtils.GenerateTimeUUID(), 0, string.Empty, CassandraUtils.GenerateTimeUUID(), "FooName", 30, "Im an cellnumber", DateTime.Parse("07-30-1990"),
            //                               "Im an event type", null, "im an fingerprint", CassandraUtils.GenerateTimeUUID(), DateTime.Now, "TEST");

            //var result = _handler.HandleEventAsync(@event);

            //Assert.True(result.Result);
        }
    }
}