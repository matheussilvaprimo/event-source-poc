using Members.Sync.Next.EventSourcing.Domain.Aggregates;
using Members.Sync.Next.EventSourcing.Domain.Events;
using Members.Sync.Next.EventSourcing.Infra;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Members.Sync.Next.EventSourcing.Tests
{
    internal class MemberCreateHandlerTest
    {
        public MemberCreateHandlerTest()
        {
        }

        private ServiceProvider Setup()
        {
            var serviceProvider = new ServiceCollection();

            return serviceProvider.BuildServiceProvider();
        }
    }


}