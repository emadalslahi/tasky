using System.Data.Common;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Tasky.Modules.Tasks.Application.Abstractions.Data;

namespace Tasky.Modules.Tasks.Infrastructure.Data
{
    /// <summary>
    /// Factory responsible for creating and opening database connections.
    /// Ensures proper connection string management and async open.
    /// </summary>
    public sealed class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;

        /// <summary>
        /// Initializes the factory with a connection string from configuration.
        /// </summary>
        public DbConnectionFactory(IConfiguration configuration)
        {
            // Reads from appsettings.json → "ConnectionStrings:DefaultConnection"
            _connectionString = configuration.GetConnectionString("TaskyDb")
                                ?? throw new InvalidOperationException("Database connection string not configured.");
        }

        /// <summary>
        /// Creates and opens a SQL Server database connection asynchronously.
        /// </summary>
        public async ValueTask<DbConnection> OpenConnectionAsync()
        {
            var connection = new SqlConnection(_connectionString);

            // Open the connection before returning
            await connection.OpenAsync();

            return connection;
        }
    }
}