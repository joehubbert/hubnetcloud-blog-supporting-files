using CRM_WindowsForms_EnterpriseEdition.Model;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using Npgsql;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Interface
{
    internal class Parameter
    {
        public string ParameterName { get; set; } = string.Empty;
        public object? ParameterValue { get; set; }
    }

    internal class DBInterface
    {
        private static object[] BuildDbParameters(DatabaseConnectionSettings dbSettings, Parameter[] parameters)
        {
            switch (dbSettings.ActiveDatabaseEngine)
            {
                case "Azure SQL Database":
                case "Azure SQL Managed Instance":
                case "Microsoft SQL Server":
                    return parameters.Select(p => new SqlParameter("@" + p.ParameterName, p.ParameterValue ?? DBNull.Value)).ToArray();
                case "Azure Database for MySQL":
                case "MySQL":
                    return parameters.Select(p => new MySqlParameter(p.ParameterName, p.ParameterValue ?? DBNull.Value)).ToArray();
                case "Azure Database for PostgreSQL":
                case "PostgreSQL":
                    return parameters.Select(p => new NpgsqlParameter(p.ParameterName, p.ParameterValue ?? DBNull.Value)).ToArray();
                default:
                    throw new NotSupportedException($"Database type '{dbSettings.ActiveDatabaseEngine}' is not supported.");
            }
        }

        public static async Task<bool> ExecuteCreateUpdateDeleteStoredProcedureAsync(string storedProcedureName, Parameter[] parameters, string dataSubject, string operationType)
        {
            try
            {
                var executor = await ExecuteStoredProcedure.CreateAsync();
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

        public static async Task<DataTable> ExecuteSelectStoredProcedureAsync(string storedProcedureName, Parameter[] parameters, string dataSubject)
        {
            try
            {
                var executor = await ExecuteStoredProcedure.CreateAsync();
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
                var executor = await ExecuteStoredProcedure.CreateAsync();
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
    }
}