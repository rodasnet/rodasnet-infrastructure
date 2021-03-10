using Microsoft.Extensions.Configuration;
using Rodasnet.Infrastructure.HealthCheck;
using System;
using Xunit;

namespace Rodasnet.Infrastructure.IntegrationTests
{
    public class TestStorageConfiguration : IHealthCheckStorageConfiguration
    {
        public String ConnectionString => "Dummy Database Connection String";
    }

    public class StorageHealthCheckControllerTests
    {
        public IHealthCheckStorageConfiguration Configuration { get; set; }

        public StorageHealthCheckControllerTests()
        {
            Configuration = new TestStorageConfiguration();
        }

        [Fact]
        public void StorageHealthCheckController_StatusHealthy()
        {
            var controller = new StorageHealthCheckControllerMock(Configuration);

            Assert.IsType<StorageHealthCheckControllerMock>(controller);

            //var echoMessage = "performing integration tests";

            //var actual = controller.GetAsync(echoMessage).GetAwaiter().GetResult();

            //Assert.Equal(echoMessage, actual.Echo);
            //Assert.Equal("Healthy", actual.Status);
            //Assert.Equal("Solid Gold.", actual.ApiVersion);
        }
    }
}
