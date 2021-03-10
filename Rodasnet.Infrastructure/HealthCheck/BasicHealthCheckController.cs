using System;
using System.Threading.Tasks;

namespace Rodasnet.Infrastructure.HealthCheck
{
    public abstract class BasicHealthCheckController : SystemHealthCheckControllerBase
    {
        public BasicHealthCheckController() { }

        public override async Task<HealthCheckEntry> GetAsync(string echo)
        {
            return await Task.Run(()=>
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
