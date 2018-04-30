using Microsoft.Extensions.DependencyInjection;

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