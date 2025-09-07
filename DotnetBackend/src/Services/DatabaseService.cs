using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

using MySqlConnector;

namespace DotnetBackend.Services
{
    public class DatabaseService
    {
        private readonly string? _connectionString;

        public DatabaseService(IConfiguration Iconfiguration)
        {
            _connectionString = Iconfiguration.GetConnectionString("DatabaseConnection");
        }

        public async Task<List<Models.User>> GetUsersAsync()
        {
            var users = new List<Models.User>();

            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new System.Exception("Connection string is not configured.");
            }

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var cmd = new MySqlCommand("SELECT Id, UserName, DisplayName, Email, Password FROM Users", connection);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        var user = new Models.User
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            UserName = reader.GetString(reader.GetOrdinal("UserName")),
                            Password = reader.GetString(reader.GetOrdinal("Password")),
                            DisplayName = reader.IsDBNull(reader.GetOrdinal("DisplayName")) ? null : reader.GetString(reader.GetOrdinal("DisplayName")),
                            Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email"))
                        };

                        users.Add(user);
                    }
                }
            }

            return users;
        }

        public async Task<Models.User?> GetUserByIdAsync(int id)
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new System.Exception("Connection string is not configured.");
            }

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var cmd = new MySqlCommand("SELECT Id, UserName, DisplayName, Email, Password FROM Users WHERE Id = @Id", connection);
                cmd.Parameters.AddWithValue("@Id", id);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        var user = new Models.User
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            UserName = reader.GetString(reader.GetOrdinal("UserName")),
                            Password = reader.GetString(reader.GetOrdinal("Password")),
                            DisplayName = reader.IsDBNull(reader.GetOrdinal("DisplayName")) ? null : reader.GetString(reader.GetOrdinal("DisplayName")),
                            Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email"))
                        };

                        return user;
                    }
                }
            }

            return null;
        }

        public async Task<bool> DeleteUserByIdAsync(int id)
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new System.Exception("Connection string is not configured.");
            }

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var cmd = new MySqlCommand("DELETE FROM Users WHERE Id = @Id", connection);
                cmd.Parameters.AddWithValue("@Id", id);

                var affected = await cmd.ExecuteNonQueryAsync();

                return affected > 0;
            }
        }
    }
}
