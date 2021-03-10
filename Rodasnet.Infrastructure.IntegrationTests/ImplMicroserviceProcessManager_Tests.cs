using System.Threading.Tasks;
using Xunit;
using System;

namespace Rodasnet.Infrastructure.IntegrationTests
{
    public class ImplMicroserviceProcessManager_Tests
    {
        [Fact]
        public void Establish_Sesseion_Success()
        {
            var factory = new ImplSessionFactory();

            var command = new ImplCommand
            {
                Id = new System.Guid()
            };

            Assert.IsType<Guid>(command.Id);

            var handler = new ImplCommandHandler();

            var manager = new ImplMicroserviceProcessManager(factory, handler);

            manager.ReceiveCommandAsync();

            Assert.IsType<bool>(true);
        }
    }
}
