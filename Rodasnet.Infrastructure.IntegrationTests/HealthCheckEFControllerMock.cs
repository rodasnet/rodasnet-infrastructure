using Rodasnet.Infrastructure.HealthCheck;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rodasnet.Infrastructure.IntegrationTests
{
    public class HealthCheckEFControllerMock : EntityFrameworkHealthCheckController
    {
        public HealthCheckEFControllerMock(IHealthCheckService healthService) : base(healthService)
        {
            ApiVersion = "Solid Gold.";
        }
    }
}
