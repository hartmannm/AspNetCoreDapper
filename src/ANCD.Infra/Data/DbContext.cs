using ANCD.Application.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ANCD.Infra.Data
{
    public class DbContext : IDbContext
    {
        private readonly string _connectionString;

        public DbContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DatabaseConnection");
        }

        public IDbConnection GetConnection()
        {
            var connection = new SqlConnection(_connectionString);

            if(connection.State is ConnectionState.Closed)
                connection.Open();

            return connection;
        }
    }
}
