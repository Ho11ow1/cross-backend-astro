using MySqlConnector;
using Microsoft.Extensions.Configuration;

namespace DotnetBackend.Services
{
    public class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService(IConfiguration Iconfiguration)
        {
            _connectionString = Iconfiguration.GetConnectionString("DatabaseConnection");
        }
    }
}
