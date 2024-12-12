using Microsoft.Data.SqlClient;
using System.Data;

namespace CRM_WindowsForms.Model
{
    internal class ExecuteStoredProcedure
    {
        private readonly string _connectionString;

        public ExecuteStoredProcedure(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public async Task<DataTable> ExecuteAsync(string storedProcedureName, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            // Ensure parameter names and values are properly sanitized
                            if (string.IsNullOrWhiteSpace(parameter.ParameterName))
                            {
                                throw new ArgumentException("Parameter name cannot be null or whitespace.", nameof(parameters));
                            }
                            command.Parameters.Add(parameter);
                        }
                    }

                    await connection.OpenAsync();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        await Task.Run(() => adapter.Fill(dataTable));
                        return dataTable;
                    }
                }
            }
        }

        public async Task<int> ExecuteNonQueryAsync(string storedProcedureName, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            // Ensure parameter names and values are properly sanitized
                            if (string.IsNullOrWhiteSpace(parameter.ParameterName))
                            {
                                throw new ArgumentException("Parameter name cannot be null or whitespace.", nameof(parameters));
                            }
                            command.Parameters.Add(parameter);
                        }
                    }

                    await connection.OpenAsync();
                    return await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<object> ExecuteScalarAsync(string storedProcedureName, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            // Ensure parameter names and values are properly sanitized
                            if (string.IsNullOrWhiteSpace(parameter.ParameterName))
                            {
                                throw new ArgumentException("Parameter name cannot be null or whitespace.", nameof(parameters));
                            }
                            command.Parameters.Add(parameter);
                        }
                    }

                    await connection.OpenAsync();
                    return await command.ExecuteScalarAsync();
                }
            }
        }
    }
}