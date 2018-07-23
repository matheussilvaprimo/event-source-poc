using System;
using EventStore.Extensions;
using User.BackOffice.EventSourcing.Entities;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var agg = new UserAggregateRootEntity { UserName = "matheus", Teste = "teste" };
            var filter = agg.GetFilter();
        }
    }
}
