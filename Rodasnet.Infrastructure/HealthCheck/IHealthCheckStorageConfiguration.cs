using System;

namespace Rodasnet.Infrastructure.HealthCheck
{
    public interface IHealthCheckStorageConfiguration
    {
        String ConnectionString { get;  }
    }
}