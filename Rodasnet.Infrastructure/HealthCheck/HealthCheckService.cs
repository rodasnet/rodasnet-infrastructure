using System;
using System.Threading.Tasks;

namespace Rodasnet.Infrastructure.HealthCheck
{
    public class HealthCheckService : IHealthCheckService
    {
        private readonly IHealthCheckRepository healthCheckRepository;

        public HealthCheckService(IHealthCheckRepository healthRepository)
        {
            healthCheckRepository = healthRepository;
        }

        public async Task<HealthCheckEntry> CreateAsync(HealthCheckEntryDto health)
        {
            var healthCheckEntry = new HealthCheckEntry()
            {
                ApiVersion = health.ApiVersion,
                Status = "Healthy",
                Echo = health.Echo
            };

            await healthCheckRepository.AddAsync(healthCheckEntry);

            try
            {
                await healthCheckRepository.SaveChangesAsync();                   
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                healthCheckEntry.Status = "Failure";
                healthCheckEntry.Error = e.ToString();
                return healthCheckEntry;
            }

            return healthCheckEntry;
        }

    }

    public interface IHealthCheckService
    {
        Task<HealthCheckEntry> CreateAsync(HealthCheckEntryDto apiversion);
    }
}
