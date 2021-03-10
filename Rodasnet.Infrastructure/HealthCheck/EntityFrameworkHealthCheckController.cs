using System;
using System.Threading.Tasks;

namespace Rodasnet.Infrastructure.HealthCheck
{
    public abstract class EntityFrameworkHealthCheckController : SystemHealthCheckControllerBase
    {
        protected readonly IHealthCheckService _healthService;

        public EntityFrameworkHealthCheckController(IHealthCheckService healthService)
        {
            _healthService = healthService;
        }

        public override async Task<HealthCheckEntry> GetAsync(string echo)
        {
            return await _healthService.CreateAsync(new HealthCheckEntryDto
            {
                ApiVersion = this.ApiVersion,
                Echo = echo
            });
        }
    }
}
