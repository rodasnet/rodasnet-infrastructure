using System;
using System.Threading.Tasks;

namespace Rodasnet.Infrastructure.HealthCheck
{
    public abstract class SystemHealthCheckControllerBase
    {
        public String ApiVersion { get; protected set; } = "API version not set.";

        public SystemHealthCheckControllerBase() { }

        abstract public Task<HealthCheckEntry> GetAsync(string echo);
    }
}
