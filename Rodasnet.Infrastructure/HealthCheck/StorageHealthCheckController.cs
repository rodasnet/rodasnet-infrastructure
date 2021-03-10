using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using System;

namespace Rodasnet.Infrastructure.HealthCheck
{
    public abstract class StorageHealthCheckController : SystemHealthCheckControllerBase
    {
        protected readonly IHealthCheckStorageConfiguration _configuration;

        public StorageHealthCheckController(IHealthCheckStorageConfiguration config)
        {
            _configuration = config;
        }

        public override async Task<HealthCheckEntry> GetAsync(string echo)
        {
            var health = new HealthCheckEntry() { Echo = echo, ApiVersion = this.ApiVersion };

            try
            {
                using (var conn = new SqlConnection(_configuration.ConnectionString))
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT CURRENT_TIMESTAMP";

                        health.Timestamp = (DateTime) await cmd.ExecuteScalarAsync();

                        health.Status = "Healthy";

                        return health;
                    }
                }
            }
            catch (Exception e)
            {
                return await Task.Run(() => new HealthCheckEntry { Echo = echo, Error = e.Message, Status = "Database is Down" });
            }
        }
    }
}
