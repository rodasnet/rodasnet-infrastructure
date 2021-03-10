using System;
using Xunit;
using Rodasnet.Infrastructure.HealthCheck;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Rodasnet.Infrastructure.IntegrationTests
{
    public class HealthCheckDefaultTests
    {
        [Fact]
        public void HealthCheckControllerDefaultConstructor_StatusHealthy()
        {
            var controller = new HealthCheckControllerDefaultConstructorMock();

            var echoMessage = "performing integration tests";

            var actual = controller.GetAsync(echoMessage).GetAwaiter().GetResult();

            Assert.Equal(echoMessage, actual.Echo);
            Assert.Equal("Healthy", actual.Status);
            Assert.Equal("Solid Gold.", actual.ApiVersion);
        }
    }
}
