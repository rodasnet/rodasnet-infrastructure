using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Rodasnet.Infrastructure.HealthCheck
{
    public class HealthCheckRepository : IHealthCheckRepository
    {
        protected readonly HealthCheckDbContext _dbContext;

        public HealthCheckRepository(HealthCheckDbContext context)
        {
            _dbContext = context;
        }

        public async Task AddAsync(HealthCheckEntry healthCheckEntry)
        {
            await _dbContext.HealthChecks.AddAsync(healthCheckEntry);
        }

        public async Task<Int32> SaveChangesAsync()
        {
            try
            {
               return await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                // TODO : SEND notification to administrator
                throw e;
            }
             
        }
    }

    public interface IHealthCheckRepository
    {
        Task AddAsync(HealthCheckEntry healthCheck);

        Task<Int32> SaveChangesAsync();
    }

    public class HealthCheckEntry
    {
        public HealthCheckEntry()
        {
            Timestamp = DateTime.Now;
        }

        public int Id { get; set; }

        public string ApiVersion { get; set; }

        public string Status { get; set; }

        public DateTime Timestamp { get; set; }

        [NotMapped]
        public string Error { get ; set; }

        [NotMapped]
        public string Echo { get; set; }

    }

    public class HealthCheckEntryDto
    {
        public string ApiVersion { get; set; }

        public string Echo { get; set; }
    }

    public class HealthCheckDbContext : DbContext
    {
        public HealthCheckDbContext(DbContextOptions<HealthCheckDbContext> options) : base(options) { }

        public DbSet<HealthCheckEntry> HealthChecks { get; set; }
    }
}
