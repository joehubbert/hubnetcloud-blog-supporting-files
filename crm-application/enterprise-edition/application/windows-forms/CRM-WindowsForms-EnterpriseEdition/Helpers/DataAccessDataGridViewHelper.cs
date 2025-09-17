using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Services;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Helpers
{
    internal class DataAccessDataGridViewHelper
    {
        private static Guid _companyConfigurationId;

        private static async Task LoadActiveCompanyConfigurationAsync()
        {
            var companyConfiguration = await ApplicationConfigurationService.GetCompanyConfigurationAsync();
            if (companyConfiguration == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Warning.CompanyConfiguration.NoData");
                return;
            }
            else
            {
                _companyConfigurationId = companyConfiguration.companyConfigurationId;
            }
        }

        //Loads data into a DataGridView from a stored procedure and adds a "Details" link column.
        public static async Task LoadDataGridViewAsync(
            DatabaseConnectionSettings? dbSettings,
            object idValue,
            string idParameterName,
            string storedProcedureName,
            string dataSubject,
            DataGridView grid,
            string keyColumnName,
            string detailsColumnText,
            string sortColumnOrder,
            string? sortColumnName)
        {
            if (dbSettings == null)
            {
                dbSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            bool connectionAvailable = false;
            try
            {
                connectionAvailable = await DBInterface.TestConnectionAsync(dbSettings.DatabaseConnectionString);
            }
            catch (Exception ex)
            {
                new ErrorMessageService("Error.Database.Connection.Failed", dataSubject, ex.Message);
                return;
            }

            if (!connectionAvailable)
            {
                new ErrorMessageService("Error.Database.Connection.Failed", dataSubject, "Could not connect to the database.");
                return;
            }

            await LoadActiveCompanyConfigurationAsync();

            var parameters = new[]
            {
                new StoredProcedureParameter
                {
                    ParameterName = idParameterName,
                    ParameterValue = idValue
                }
            };

            DataTable? dataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters, dataSubject);

            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                new ErrorMessageService("Information.NoDataFound", dataSubject);
                grid.DataSource = null;
                return;
            }

            string sortColumn = sortColumnName ?? "Created Timestamp UTC";

            if (dataTable.Columns.Contains("Company Configuration Id") &&
                !string.Equals(storedProcedureName, "spGetAllCompanyConfiguration", StringComparison.OrdinalIgnoreCase))
            {
                if (dataTable.Columns["Company Configuration Id"].DataType == typeof(Guid))
                {
                    string filter = $"[Company Configuration Id] = '{_companyConfigurationId}'";
                    dataTable.DefaultView.RowFilter = filter;
                }
            }

            dataTable.DefaultView.Sort = $"{sortColumn} {sortColumnOrder}";
            grid.AutoGenerateColumns = true;
            grid.DataSource = dataTable;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            if (grid.Columns.Contains("Details"))
                grid.Columns.Remove("Details");

            var detailsLink = new DataGridViewLinkColumn
            {
                HeaderText = "Details",
                Text = detailsColumnText,
                UseColumnTextForLinkValue = true,
                Name = "Details"
            };
            grid.Columns.Add(detailsLink);
        }

        // Handles the click event for a "Details" link column in a DataGridView.
        public static void HandleDetailsCellClick(
            DataGridView grid,
            DataGridViewCellEventArgs e,
            string keyColumnName,
            string dataSubject,
            Action<Guid> showDetailForm)
        {
            if (e.ColumnIndex == grid.Columns["Details"].Index && e.RowIndex >= 0)
            {
                try
                {
                    if (grid.Columns.Contains(keyColumnName))
                    {
                        var cellValue = grid.Rows[e.RowIndex].Cells[keyColumnName].Value;
                        if (cellValue is Guid id)
                        {
                            showDetailForm(id);
                        }
                        else if (cellValue != null && Guid.TryParse(cellValue.ToString(), out Guid parsedId))
                        {
                            showDetailForm(parsedId);
                        }
                        else
                        {
                            new ErrorMessageService("Error.Data.IdColumnNotFound", dataSubject);
                        }
                    }
                    else
                    {
                        new ErrorMessageService("Error.Data.IdColumnNotFound", dataSubject);
                    }
                }
                catch (Exception ex)
                {
                    new ErrorMessageService("Error.Data.Retrieval", dataSubject, ex.Message);
                }
            }
        }
    }
}