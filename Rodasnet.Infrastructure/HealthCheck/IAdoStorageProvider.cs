using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Rodasnet.Infrastructure.HealthCheck
{
    public interface IAdoStorageProvider
    {
        void CreateConnection(string connectionString);
        void OpenConnection();
        SqlDataReader SendQuery();
        Task<HealthCheckEntry> ProcessResultAsync();
        void CloseConnection();
    }
}
