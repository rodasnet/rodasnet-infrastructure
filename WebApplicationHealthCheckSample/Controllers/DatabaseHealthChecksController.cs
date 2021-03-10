using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rodasnet.Infrastructure.HealthCheck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationHealthCheckSample.Controllers
{
    [Route("[controller]")]
    public class DatabaseHealthChecksController : StorageHealthCheckController
    {
        public DatabaseHealthChecksController(IHealthCheckStorageConfiguration config) : base(config)
        {
            ApiVersion = "v0.1.0";
        }
    }
}
