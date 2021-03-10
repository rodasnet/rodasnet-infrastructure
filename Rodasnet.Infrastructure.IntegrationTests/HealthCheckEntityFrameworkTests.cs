using System;
using Xunit;
using Rodasnet.Infrastructure.HealthCheck;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Rodasnet.Infrastructure.IntegrationTests
{
    public class HealthCheckEntityFrameworkTests
    {
        public IConfiguration Configuration { get; }

        public HealthCheckEntityFrameworkTests()
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
            //var service = new HealthServiceFixture(Configuration).HealthService;
        }

        [Fact]
        public void HealthCheckController_StatusHealthy()
        {
            var service = new HealthServiceFixture().HealthService;
            Assert.IsType<HealthCheckService>(service);
            
            string echoMessage = "performing integration tests";

            var controller = new HealthCheckEFControllerMock(service);
            
            var actual = controller.GetAsync(echoMessage).GetAwaiter().GetResult();

            Assert.Equal("Healthy", actual.Status);
            Assert.Equal(echoMessage, actual.Echo);
            Assert.Equal("Solid Gold.", actual.ApiVersion);
        }

        /*
        [Fact]
        public void HealthCheckControllerDefaultConstructor_StatusHealthy()
        {
            var controller = new HealthCheckControllerDefaultConstructorMock();

            var healthResult = controller.Get();

            string json = JsonConvert.SerializeObject(healthResult.Value);

            HealthCheckEntry entry = JsonConvert.DeserializeObject<HealthCheckEntry>(json);

            Console.WriteLine("Health Json Results To String" + json);

            Assert.Equal("Healthy", entry.Status);
            Assert.Equal("Solid Gold.", entry.ApiVersion);
        }

        [Fact]
        public void HealthCheckControllerApiVersionNotSetMock_StatusHealthy()
        {
            var controller = new HealthCheckControllerApiVersionNotSetMock();

            var healthResult = controller.Get();

            string json = JsonConvert.SerializeObject(healthResult.Value);

            HealthCheckEntry entry = JsonConvert.DeserializeObject<HealthCheckEntry>(json);

            Console.WriteLine("Health Json Results To String" + json);

            Assert.Equal("Healthy", entry.Status);
            Assert.Equal("API version not set.", entry.ApiVersion);
        }
        */
    }
}