using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Rodasnet.Infrastructure.HealthCheck
{
    public class SqlServerAdo : IAdoStorageProvider
    {
        private SqlConnection _conn;


        public void CloseConnection()
        {
            throw new System.NotImplementedException();
        }

        public void CreateConnection(string connectionString)
        {
            _conn = new SqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            _conn.Open();
        }

        public SqlDataReader SendQuery()
        {
            using (SqlCommand cmd = _conn.CreateCommand())
            {
                cmd.CommandText = "SELECT CURRENT_TIMESTAMP";
                return cmd.ExecuteReader();
            }
        }

        public async Task<HealthCheckEntry> ProcessResultAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
