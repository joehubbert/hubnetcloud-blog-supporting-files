using CRM.Interface;
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

        public async Task<DataTable> ExecuteAsync(string storedProcedureName, params object[] parameters)
        {
            switch (_dbSettings.ActiveDatabaseEngine)
            {
                case "Azure SQL Database":
                case "Azure SQL Managed Instance":
                case "Microsoft SQL Server":
                    return await ExecuteSqlServerAsync(storedProcedureName, parameters);
                case "Azure Database for MySQL":
                case "MySQL":
                    return await ExecuteMySqlAsync(storedProcedureName, parameters);
                case "AzureDatabase for PostgreSQL":
                case "PostgreSQL":
                    return await ExecutePostgreSqlAsync(storedProcedureName, parameters);
                default:
                    throw new NotSupportedException($"Database type '{_dbSettings.ActiveDatabaseEngine}' is not supported.");
            }
        }

        private async Task<DataTable> ExecuteSqlServerAsync(string storedProcedureName, object[] parameters)
        {
            using var connection = new SqlConnection(_dbSettings.DatabaseConnectionString);
            using var command = new SqlCommand(storedProcedureName, connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            if (parameters != null)
            {
                foreach (SqlParameter param in parameters)
                    command.Parameters.Add(param);
            }
            await connection.OpenAsync();
            using var adapter = new SqlDataAdapter(command);
            var dataTable = new DataTable();
            await Task.Run(() => adapter.Fill(dataTable));
            return dataTable;
        }

        private async Task<DataTable> ExecuteMySqlAsync(string storedProcedureName, object[] parameters)
        {
            using var connection = new MySqlConnection(_dbSettings.DatabaseConnectionString);
            using var command = new MySqlCommand(storedProcedureName, connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            if (parameters != null)
            {
                foreach (MySqlParameter param in parameters)
                    command.Parameters.Add(param);
            }
            await connection.OpenAsync();
            using var adapter = new MySqlDataAdapter(command);
            var dataTable = new DataTable();
            await Task.Run(() => adapter.Fill(dataTable));
            return dataTable;
        }

        private async Task<DataTable> ExecutePostgreSqlAsync(string storedProcedureName, object[] parameters)
        {
            using var connection = new NpgsqlConnection(_dbSettings.DatabaseConnectionString);
            using var command = new NpgsqlCommand(storedProcedureName, connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            if (parameters != null)
            {
                foreach (NpgsqlParameter param in parameters)
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