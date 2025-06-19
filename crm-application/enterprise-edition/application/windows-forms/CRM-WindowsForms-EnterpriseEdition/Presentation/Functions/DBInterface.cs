using CRM_WindowsForms.Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation.Functions
{
    public class Parameter
    {
        public string ParameterName { get; set; } = string.Empty;
        public object? ParameterValue { get; set; }
    }

    public static class DBInterface
    {
        public static async Task<bool> ExecuteCreateUpdateDeleteStoredProcedureAsync(string storedProcedureName, Parameter[] parameters, string dataSubject, string connectionString, string operationType)
        {
            try
            {
                ExecuteStoredProcedure executor = new ExecuteStoredProcedure(connectionString);
                var sqlParameters = new List<SqlParameter>();

                foreach (var parameter in parameters)
                {
                    sqlParameters.Add(new SqlParameter(parameter.ParameterName, parameter.ParameterValue ?? DBNull.Value));
                }

                await executor.ExecuteAsync(storedProcedureName, sqlParameters.ToArray());

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

        public static async Task<DataTable> ExecuteSelectStoredProcedureAsync(string storedProcedureName, Parameter[] parameters, string dataSubject, string connectionString)
        {
            try
            {
                ExecuteStoredProcedure executor = new ExecuteStoredProcedure(connectionString);
                var sqlParameters = new List<SqlParameter>();

                foreach (var parameter in parameters)
                {
                    sqlParameters.Add(new SqlParameter(parameter.ParameterName, parameter.ParameterValue ?? DBNull.Value));
                }

                DataTable dataTable = await executor.ExecuteAsync(storedProcedureName, sqlParameters.ToArray());
                return dataTable;
            }
            catch (Exception ex)
            {
                string errorMessage = $"No data found for the specified {dataSubject}: {ex.Message}";

                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        public static async Task<DataTable> ExecuteSelectStoredProcedureNoParameterAsync(string storedProcedureName, string dataSubject, string connectionString)
        {
            try
            {
                ExecuteStoredProcedure executor = new ExecuteStoredProcedure(connectionString);

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