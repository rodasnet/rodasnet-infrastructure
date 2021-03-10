using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Rodasnet.Infrastructure.HealthCheck;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rodasnet.Infrastructure.IntegrationTests
{
    class HealthServiceFixture
    {
        public HealthServiceFixture(IConfiguration configuration)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HealthCheckDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            var context = new HealthCheckDbContext(optionsBuilder.Options);

            var repo = new HealthCheckRepository(context);
            HealthService = new HealthCheckService(repo);
        }

        public HealthServiceFixture()
        {
            var fixture = new InMemoryTestFixture();
            
            var context = fixture.HealthContext;

            var repo = new HealthCheckRepository(context);
            HealthService = new HealthCheckService(repo);
        }

        public HealthCheckService HealthService { get; private set; }

    }
}
