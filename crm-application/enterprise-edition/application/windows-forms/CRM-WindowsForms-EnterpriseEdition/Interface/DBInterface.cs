using CRM.Model;
using CRM.Services;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using Npgsql;
using System.Data;

namespace CRM.Interface
{
    internal class DBInterface
    {
        private static object[] BuildDbParameters(DatabaseConnectionSettings dbSettings, StoredProcedureParameter[] parameters)
        {
            switch (dbSettings.ActiveDatabaseEngine)
            {
                case "Azure SQL Database":
                case "Azure SQL Managed Instance":
                case "Microsoft SQL Server":
                    return parameters.Select(p => {
                        var sqlParam = new SqlParameter("@" + p.ParameterName, p.ParameterValue ?? DBNull.Value);
                        sqlParam.Direction = p.ParameterDirection;
                        return sqlParam;
                    }).ToArray();
                case "Azure Database for MySQL":
                case "MySQL":
                    return parameters.Select(p => {
                        var mySqlParam = new MySqlParameter(p.ParameterName, p.ParameterValue ?? DBNull.Value);
                        mySqlParam.Direction = p.ParameterDirection;
                        return mySqlParam;
                    }).ToArray();
                case "Azure Database for PostgreSQL":
                case "PostgreSQL":
                    return parameters.Select(p => {
                        var npgsqlParam = new NpgsqlParameter(p.ParameterName, p.ParameterValue ?? DBNull.Value);
                        npgsqlParam.Direction = p.ParameterDirection;
                        return npgsqlParam;
                    }).ToArray();
                default:
                    throw new NotSupportedException($"Database type '{dbSettings.ActiveDatabaseEngine}' is not supported.");
            }
        }

        public static async Task<bool> ExecuteCreateUpdateDeleteStoredProcedureAsync(DatabaseConnectionSettings databaseConnectionSettings, string storedProcedureName, StoredProcedureParameter[] parameters, string dataSubject, string operationType)
        {
            try
            {
                var executor = await ExecuteStoredProcedureService.CreateAsync();
                var dbParameters = BuildDbParameters(databaseConnectionSettings, parameters);

                switch (databaseConnectionSettings.ActiveDatabaseEngine)
                {
                    case "Azure SQL Database":
                    case "Azure SQL Managed Instance":
                    case "Microsoft SQL Server":
                        storedProcedureName = $"{storedProcedureName}";
                        break;
                    case "Azure Database for MySQL":
                    case "MySQL":
                    case "Azure Database for PostgreSQL":
                    case "PostgreSQL":
                        // No change to storedProcedureName for these engines
                        break;
                    default:
                        throw new NotSupportedException($"Database type '{databaseConnectionSettings.ActiveDatabaseEngine}' is not supported.");
                }

                await executor.ExecuteAsync(storedProcedureName, dbParameters);

                if (operationType != "Select")
                {
                    string successMessage = operationType switch
                    {
                        "Update" => $"{dataSubject} details updated successfully.",
                        "Delete" => $"{dataSubject} deleted successfully.",
                        "Create" => $"New {dataSubject} created successfully.",
                        _ => $"{dataSubject} operation completed successfully."
                    };

                    MessageBox.Show(successMessage, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return true;
            }
            catch (Exception ex)
            {
                string errorMessage = operationType switch
                {
                    "Update" => $"Failed to update {dataSubject} details: {ex.Message}",
                    "Delete" => $"Failed to delete {dataSubject}: {ex.Message}",
                    "Create" => $"Failed to create new {dataSubject}: {ex.Message}",
                    "Select" => $"No data found for the specified {dataSubject}: {ex.Message}",
                    _ => $"Failed to complete {dataSubject} operation: {ex.Message}"
                };

                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static async Task<Dictionary<string, object>?> ExecuteCreateUpdateDeleteStoredProcedureWithOutputParametersAsync(
            DatabaseConnectionSettings databaseConnectionSettings,
            string storedProcedureName,
            StoredProcedureParameter[] parameters,
            string dataSubject,
            string operationType,
            bool outputStoredProcedureParameterCapture = false,
            string? outboundStoredProcedureParameterName = null
            )
        {
            try
            {
                var executor = await ExecuteStoredProcedureService.CreateAsync();
                var dbParameters = BuildDbParameters(databaseConnectionSettings, parameters);
                var outputParameterValues = new Dictionary<string, object>();

                switch (databaseConnectionSettings.ActiveDatabaseEngine)
                {
                    case "Azure SQL Database":
                    case "Azure SQL Managed Instance":
                    case "Microsoft SQL Server":
                        await ExecuteSqlServerWithOutputAsync(storedProcedureName, dbParameters, dataSubject, operationType, outputParameterValues, outputStoredProcedureParameterCapture, outboundStoredProcedureParameterName, databaseConnectionSettings);
                        break;
                    case "Azure Database for MySQL":
                    case "MySQL":
                        await ExecuteMySqlWithOutputAsync(storedProcedureName, dbParameters, dataSubject, operationType, outputParameterValues, outputStoredProcedureParameterCapture, outboundStoredProcedureParameterName, databaseConnectionSettings);
                        break;
                    case "Azure Database for PostgreSQL":
                    case "PostgreSQL":
                        await ExecutePostgreSqlWithOutputAsync(storedProcedureName, dbParameters, dataSubject, operationType, outputParameterValues, outputStoredProcedureParameterCapture, outboundStoredProcedureParameterName, databaseConnectionSettings);
                        break;
                    default:
                        throw new NotSupportedException($"Database type '{databaseConnectionSettings.ActiveDatabaseEngine}' is not supported.");
                }

                if (operationType != "Select")
                {
                    string successMessage = operationType switch
                    {
                        "Update" => $"{dataSubject} details updated successfully.",
                        "Delete" => $"{dataSubject} deleted successfully.",
                        "Create" => $"New {dataSubject} created successfully.",
                        _ => $"{dataSubject} operation completed successfully."
                    };

                    MessageBox.Show(successMessage, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return outputParameterValues.Count > 0 ? outputParameterValues : new Dictionary<string, object>();
            }
            catch (Exception ex)
            {
                string errorMessage = operationType switch
                {
                    "Update" => $"Failed to update {dataSubject} details: {ex.Message}",
                    "Delete" => $"Failed to delete {dataSubject}: {ex.Message}",
                    "Create" => $"Failed to create new {dataSubject}: {ex.Message}",
                    _ => $"Failed to complete {dataSubject} operation: {ex.Message}"
                };

                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static async Task<DataTable> ExecuteSelectStoredProcedureAsync(DatabaseConnectionSettings databaseConnectionSettings, string storedProcedureName, StoredProcedureParameter[] parameters, string dataSubject)
        {
            try
            {
                var executor = await ExecuteStoredProcedureService.CreateAsync();
                var dbParameters = BuildDbParameters(databaseConnectionSettings, parameters);
                
                switch (databaseConnectionSettings.ActiveDatabaseEngine)
                {
                    case "Azure SQL Database":
                    case "Azure SQL Managed Instance":
                    case "Microsoft SQL Server":
                        storedProcedureName = $"{storedProcedureName}";
                        break;
                    case "Azure Database for MySQL":
                    case "MySQL":
                    case "Azure Database for PostgreSQL":
                    case "PostgreSQL":
                        // No change to storedProcedureName for these engines
                        break;
                    default:
                        throw new NotSupportedException($"Database type '{databaseConnectionSettings.ActiveDatabaseEngine}' is not supported.");
                }

                DataTable dataTable = await executor.ExecuteAsync(storedProcedureName, dbParameters);
                return dataTable;
            }
            catch (Exception ex)
            {
                string errorMessage = $"No data found for the specified {dataSubject}: {ex.Message}";

                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        public static async Task<DataTable> ExecuteSelectStoredProcedureNoParameterAsync(DatabaseConnectionSettings databaseConnectionSettings, string storedProcedureName, string dataSubject)
        {
            try
            {
                var executor = await ExecuteStoredProcedureService.CreateAsync();

                switch (databaseConnectionSettings.ActiveDatabaseEngine)
                {
                    case "Azure SQL Database":
                    case "Azure SQL Managed Instance":
                    case "Microsoft SQL Server":
                        storedProcedureName = $"{storedProcedureName}";
                        break;
                    case "Azure Database for MySQL":
                    case "MySQL":
                    case "Azure Database for PostgreSQL":
                    case "PostgreSQL":
                        // No change to storedProcedureName for these engines
                        break;
                    default:
                        throw new NotSupportedException($"Database type '{databaseConnectionSettings.ActiveDatabaseEngine}' is not supported.");
                }

                DataTable dataTable = await executor.ExecuteAsync(storedProcedureName);
                return dataTable;
            }
            catch (Exception ex)
            {
                string errorMessage = $"No data found for the specified {dataSubject}: {ex.Message}";

                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        private static async Task ExecuteSqlServerWithOutputAsync(
            string storedProcedureName,
            object[] dbParameters,
            string dataSubject,
            string operationType,
            Dictionary<string, object> outputParameterValues,
            bool outputStoredProcedureParameterCapture,
            string? outboundStoredProcedureParameterName,
            DatabaseConnectionSettings databaseConnectionSettings
            )
        {
            using var connection = new SqlConnection(databaseConnectionSettings.DatabaseConnectionString);
            using var command = new SqlCommand(storedProcedureName, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            // Add parameters to command
            foreach (SqlParameter param in dbParameters)
                command.Parameters.Add(param);

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();

            // Capture output parameters if enabled
            if (outputStoredProcedureParameterCapture)
            {
                foreach (SqlParameter param in command.Parameters)
                {
                    if (param.Direction == ParameterDirection.Output || param.Direction == ParameterDirection.InputOutput)
                    {
                        // If specific parameter name is provided, only capture that one
                        if (!string.IsNullOrWhiteSpace(outboundStoredProcedureParameterName))
                        {
                            if (param.ParameterName.TrimStart('@').Equals(outboundStoredProcedureParameterName, StringComparison.OrdinalIgnoreCase))
                            {
                                outputParameterValues[param.ParameterName.TrimStart('@')] = param.Value ?? DBNull.Value;
                            }
                        }
                        else
                        {
                            // Capture all output parameters
                            outputParameterValues[param.ParameterName.TrimStart('@')] = param.Value ?? DBNull.Value;
                        }
                    }
                }
            }
        }

        private static async Task ExecuteMySqlWithOutputAsync(
            string storedProcedureName,
            object[] dbParameters,
            string dataSubject,
            string operationType,
            Dictionary<string, object> outputParameterValues,
            bool outputStoredProcedureParameterCapture,
            string? outboundStoredProcedureParameterName,
            DatabaseConnectionSettings databaseConnectionSettings
            )
        {
            using var connection = new MySqlConnection(databaseConnectionSettings.DatabaseConnectionString);
            using var command = new MySqlCommand(storedProcedureName, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            // Add parameters to command
            foreach (MySqlParameter param in dbParameters)
                command.Parameters.Add(param);

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();

            // Capture output parameters if enabled
            if (outputStoredProcedureParameterCapture)
            {
                foreach (MySqlParameter param in command.Parameters)
                {
                    if (param.Direction == ParameterDirection.Output || param.Direction == ParameterDirection.InputOutput)
                    {
                        // If specific parameter name is provided, only capture that one
                        if (!string.IsNullOrWhiteSpace(outboundStoredProcedureParameterName))
                        {
                            if (param.ParameterName.Equals(outboundStoredProcedureParameterName, StringComparison.OrdinalIgnoreCase))
                            {
                                outputParameterValues[param.ParameterName] = param.Value ?? DBNull.Value;
                            }
                        }
                        else
                        {
                            // Capture all output parameters
                            outputParameterValues[param.ParameterName] = param.Value ?? DBNull.Value;
                        }
                    }
                }
            }
        }

        private static async Task ExecutePostgreSqlWithOutputAsync(
            string storedProcedureName,
            object[] dbParameters,
            string dataSubject,
            string operationType,
            Dictionary<string, object> outputParameterValues,
            bool outputStoredProcedureParameterCapture,
            string? outboundStoredProcedureParameterName,
            DatabaseConnectionSettings databaseConnectionSettings
            )
        {
            using var connection = new NpgsqlConnection(databaseConnectionSettings.DatabaseConnectionString);
            using var command = new NpgsqlCommand(storedProcedureName, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            // Add parameters to command
            foreach (NpgsqlParameter param in dbParameters)
                command.Parameters.Add(param);

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();

            // Capture output parameters if enabled
            if (outputStoredProcedureParameterCapture)
            {
                foreach (NpgsqlParameter param in command.Parameters)
                {
                    if (param.Direction == ParameterDirection.Output || param.Direction == ParameterDirection.InputOutput)
                    {
                        // If specific parameter name is provided, only capture that one
                        if (!string.IsNullOrWhiteSpace(outboundStoredProcedureParameterName))
                        {
                            if (param.ParameterName.Equals(outboundStoredProcedureParameterName, StringComparison.OrdinalIgnoreCase))
                            {
                                outputParameterValues[param.ParameterName] = param.Value ?? DBNull.Value;
                            }
                        }
                        else
                        {
                            // Capture all output parameters
                            outputParameterValues[param.ParameterName] = param.Value ?? DBNull.Value;
                        }
                    }
                }
            }
        }

        public static async Task<bool> TestConnectionAsync(DatabaseConnectionSettings databaseConnectionSettings, string connectionString)
        {
            string? engine = databaseConnectionSettings.ActiveDatabaseEngine;

            try
            {
                switch (engine)
                {
                    case "Azure SQL Database":
                    case "Azure SQL Managed Instance":
                    case "Microsoft SQL Server":
                        var sqlBuilder = new SqlConnectionStringBuilder(connectionString)
                        {
                            ConnectTimeout = 1
                        };
                        using (var conn = new SqlConnection(sqlBuilder.ConnectionString))
                        {
                            await conn.OpenAsync();
                            return conn.State == ConnectionState.Open;
                        }
                    case "Azure Database for MySQL":
                    case "MySQL":
                        var mysqlBuilder = new MySqlConnectionStringBuilder(connectionString)
                        {
                            ConnectionTimeout = 1
                        };
                        using (var conn = new MySqlConnection(mysqlBuilder.ConnectionString))
                        {
                            await conn.OpenAsync();
                            return conn.State == ConnectionState.Open;
                        }
                    case "Azure Database for PostgreSQL":
                    case "PostgreSQL":
                        var npgsqlBuilder = new NpgsqlConnectionStringBuilder(connectionString)
                        {
                            Timeout = 1
                        };
                        using (var conn = new NpgsqlConnection(npgsqlBuilder.ConnectionString))
                        {
                            await conn.OpenAsync();
                            return conn.State == ConnectionState.Open;
                        }
                    default:
                        throw new NotSupportedException($"Database type '{engine}' is not supported.");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Connection test failed: {ex.Message}");
                return false;
            }
        }
    }
}