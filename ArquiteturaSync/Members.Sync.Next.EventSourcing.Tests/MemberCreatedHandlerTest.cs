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
        public MemberCreatedHandlerTest()
        {
        }

        [Fact]
        public void HandleMemberWithMessageNull()
        {
            var provider = Setup();
            var handler = provider.GetService<MemberCreatedHandler>();
            Assert.ThrowsAsync<NotImplementedException>(() => handler.HandleMemberAsync(null));
        }

        [Fact]
        public void HandleMemberWithMessage()
        {
            var provider = Setup();
            var handler = provider.GetService<MemberCreatedHandler>();
            var message = new MemberCreatedEvent("im an identifier", 0, string.Empty, "im an legacy id", "FooName", 30, "Im an cellnumber", DateTime.Parse("07-30-1990"),
                                           "Im an event type", "im an fingerprint", "Im an ID", DateTime.Now, "TEST");

            Assert.ThrowsAsync<NotImplementedException>(() => handler.HandleMemberAsync(message));
        }

        private ServiceProvider Setup()
        {
            var serviceProvider = new ServiceCollection()
                                     .AddScoped<MemberCreatedHandler>()
                                     .AddScoped<ICassandraEventStore, CassandraEventStore>()
                                     .AddScoped<CassandraProvider>();

            return serviceProvider.BuildServiceProvider();
        }
    }
}