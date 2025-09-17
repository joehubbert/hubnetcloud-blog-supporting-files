using CRM.Services;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using Npgsql;
using System.Data;

namespace CRM.Interface
{
    internal class StoredProcedureParameter
    {
        public ParameterDirection ParameterDirection { get; set; } = ParameterDirection.Input;
        public string ParameterName { get; set; } = string.Empty;
        public object? ParameterValue { get; set; }
    }

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

        public static async Task<bool> ExecuteCreateUpdateDeleteStoredProcedureAsync(string storedProcedureName, StoredProcedureParameter[] parameters, string dataSubject, string operationType)
        {
            try
            {
                var executor = await ExecuteStoredProcedureService.CreateAsync();
                var dbSettings = executor.DatabaseConnectionSettings;
                var dbParameters = BuildDbParameters(dbSettings, parameters);

                switch (dbSettings.ActiveDatabaseEngine)
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
                        throw new NotSupportedException($"Database type '{dbSettings.ActiveDatabaseEngine}' is not supported.");
                }

                await executor.ExecuteAsync(storedProcedureName, dbParameters);

                if (operationType != "select")
                {
                    string successMessage = operationType switch
                    {
                        "update" => $"{dataSubject} details updated successfully.",
                        "delete" => $"{dataSubject} deleted successfully.",
                        "create" => $"New {dataSubject} created successfully.",
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
                    "update" => $"Failed to update {dataSubject} details: {ex.Message}",
                    "delete" => $"Failed to delete {dataSubject}: {ex.Message}",
                    "create" => $"Failed to create new {dataSubject}: {ex.Message}",
                    "select" => $"No data found for the specified {dataSubject}: {ex.Message}",
                    _ => $"Failed to complete {dataSubject} operation: {ex.Message}"
                };

                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static async Task<DataTable> ExecuteSelectStoredProcedureAsync(string storedProcedureName, StoredProcedureParameter[] parameters, string dataSubject)
        {
            try
            {
                var executor = await ExecuteStoredProcedureService.CreateAsync();
                var dbSettings = executor.DatabaseConnectionSettings;
                var dbParameters = BuildDbParameters(dbSettings, parameters);
                
                switch (dbSettings.ActiveDatabaseEngine)
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
                        throw new NotSupportedException($"Database type '{dbSettings.ActiveDatabaseEngine}' is not supported.");
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

        public static async Task<DataTable> ExecuteSelectStoredProcedureNoParameterAsync(string storedProcedureName, string dataSubject)
        {
            try
            {
                var executor = await ExecuteStoredProcedureService.CreateAsync();
                var dbSettings = executor.DatabaseConnectionSettings;

                switch (dbSettings.ActiveDatabaseEngine)
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
                        throw new NotSupportedException($"Database type '{dbSettings.ActiveDatabaseEngine}' is not supported.");
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

        public static async Task<bool> TestConnectionAsync(string connectionString)
        {
            var dbSettings = await DatabaseConnectionSettings.LoadAsync();
            string? engine = dbSettings.ActiveDatabaseEngine;

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