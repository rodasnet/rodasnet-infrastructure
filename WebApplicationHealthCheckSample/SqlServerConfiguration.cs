using Microsoft.Extensions.Configuration;
using Rodasnet.Infrastructure.HealthCheck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationHealthCheckSample
{
    public class SqlServerConfiguration : IHealthCheckStorageConfiguration
    {
        private readonly IConfiguration _configuration;

        public SqlServerConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public String ConnectionString => _configuration["ConnectionStrings:DefaultConnection"];
    }
}
