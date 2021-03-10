using Rodasnet.Infrastructure.HealthCheck;

namespace Rodasnet.Infrastructure.IntegrationTests
{
    class StorageHealthCheckControllerMock : StorageHealthCheckController
    {
        public StorageHealthCheckControllerMock(IHealthCheckStorageConfiguration config) : base(config)
        {
            ApiVersion = "Solid Gold.";
        }
    }
}
