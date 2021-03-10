using Microsoft.EntityFrameworkCore;
using Rodasnet.Infrastructure.HealthCheck;

namespace Rodasnet.Infrastructure.IntegrationTests
{
    public class TestDbContext : DbContext
    {
        private DbContextOptions options;

        public TestDbContext(DbContextOptions options)
        {
            this.options = options;
        }

        public TestDbContext()
        {

        }

        public DbSet<HealthCheckEntry> healthCheckEntries { get; set; }
    }
}