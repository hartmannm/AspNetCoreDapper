using Dapper;
using Microsoft.Data.SqlClient;

namespace ANCD.API.Database
{
    public static class AppDatabaseHandler
    {
        private const string _databaseName = "AspnetCoreDapper";

        public static void EnsureDatabase(IConfiguration configuration)
        {
            var parameters = new DynamicParameters();
            parameters.Add("name", _databaseName);
            using var connection = new SqlConnection(configuration.GetConnectionString("MasterConnection"));
            var records = connection.Query("SELECT * FROM sys.databases WHERE name = @name", parameters);

            if (!records.Any())
                connection.Execute($"CREATE DATABASE {_databaseName}");
        }
    }
}
