using Rodasnet.Infrastructure.HealthCheck;
using System;
using System.Threading.Tasks;

namespace Rodasnet.Infrastructure.IntegrationTests
{
    class HealthCheckControllerApiVersionNotSetMock : SystemHealthCheckControllerBase
    {
        public HealthCheckControllerApiVersionNotSetMock()
        {
            
        }
        public override async Task<HealthCheckEntry> GetAsync(string echo)
        {
            return await Task.Run(() =>
            {
                var rand = new Random();

                return new HealthCheckEntry()
                {
                    Id = rand.Next(),
                    ApiVersion = this.ApiVersion,
                    Status = "Healthy",
                    Echo = echo
                };
            });
        }
    }
}
