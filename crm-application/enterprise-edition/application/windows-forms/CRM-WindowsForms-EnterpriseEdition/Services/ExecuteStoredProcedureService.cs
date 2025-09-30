using CRM.Interface;
using CRM.Model;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using Npgsql;
using System.Data;

namespace CRM.Services
{
    internal class ExecuteStoredProcedureService
    {
        private readonly DatabaseConnectionSettings _dbSettings;
        public DatabaseConnectionSettings DatabaseConnectionSettings;

        private ExecuteStoredProcedureService(DatabaseConnectionSettings dbSettings)
        {
            _dbSettings = dbSettings;
            DatabaseConnectionSettings = dbSettings;
        }

        public static async Task<ExecuteStoredProcedureService> CreateAsync()
        {
            var dbSettings = await DatabaseConnectionSettings.LoadAsync();
            return new ExecuteStoredProcedureService(dbSettings);
        }

        public async Task<DataTable> ExecuteAsync(string storedProcedureName, params object[] storedProcedureParameters)
        {
            switch (_dbSettings.ActiveDatabaseEngine)
            {
                case DatabaseEngine.AzureSQLDatabase:
                case DatabaseEngine.AzureSQLManagedInstance:
                case DatabaseEngine.MicrosoftSQLServer:
                    return await ExecuteSqlServerAsync(storedProcedureName, storedProcedureParameters);
                case DatabaseEngine.AzureDatabaseForMySQL:
                case DatabaseEngine.MySQL:
                    return await ExecuteMySqlAsync(storedProcedureName, storedProcedureParameters);
                case DatabaseEngine.AzureDatabaseForPostgreSQL:
                case DatabaseEngine.PostgreSQL:
                    return await ExecutePostgreSqlAsync(storedProcedureName, storedProcedureParameters);
                default:
                    throw new NotSupportedException($"Database type '{_dbSettings.ActiveDatabaseEngine}' is not supported.");
            }
        }

        private async Task<DataTable> ExecuteSqlServerAsync(string storedProcedureName, object[] storedProcedureParameters)
        {
            using var connection = new SqlConnection(_dbSettings.DatabaseConnectionString);
            using var command = new SqlCommand(storedProcedureName, connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            if (storedProcedureParameters != null)
            {
                foreach (SqlParameter param in storedProcedureParameters)
                    command.Parameters.Add(param);
            }
            await connection.OpenAsync();
            using var adapter = new SqlDataAdapter(command);
            var dataTable = new DataTable();
            await Task.Run(() => adapter.Fill(dataTable));
            return dataTable;
        }

        private async Task<DataTable> ExecuteMySqlAsync(string storedProcedureName, object[] storedProcedureParameters)
        {
            using var connection = new MySqlConnection(_dbSettings.DatabaseConnectionString);
            using var command = new MySqlCommand(storedProcedureName, connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            if (storedProcedureParameters != null)
            {
                foreach (MySqlParameter param in storedProcedureParameters)
                    command.Parameters.Add(param);
            }
            await connection.OpenAsync();
            using var adapter = new MySqlDataAdapter(command);
            var dataTable = new DataTable();
            await Task.Run(() => adapter.Fill(dataTable));
            return dataTable;
        }

        private async Task<DataTable> ExecutePostgreSqlAsync(string storedProcedureName, object[] storedProcedureParameters)
        {
            using var connection = new NpgsqlConnection(_dbSettings.DatabaseConnectionString);
            using var command = new NpgsqlCommand(storedProcedureName, connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            if (storedProcedureParameters != null)
            {
                foreach (NpgsqlParameter param in storedProcedureParameters)
                    command.Parameters.Add(param);
            }
            await connection.OpenAsync();
            using var adapter = new NpgsqlDataAdapter(command);
            var dataTable = new DataTable();
            await Task.Run(() => adapter.Fill(dataTable));
            return dataTable;
        }
    }
}