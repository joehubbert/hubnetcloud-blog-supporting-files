using CRM.Services;
using System.Data;

namespace CRM.Helpers
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
            await LoadActiveCompanyConfigurationAsync();

            var dataOperationsService = new DataOperationsService();

            var parameters = new object[]
            {
                new Dictionary<string, object>
                {
                    ["PropertyStoredProcedureParameterName"] = idParameterName,
                    ["PropertyValue"] = idValue
                }
            };

            await dataOperationsService.DataSubmissionServiceOrchestrator(
                operationType: "Select",
                dataSubjectName: dataSubject,
                dataToBeProcessed: parameters,
                storedProcedureName: storedProcedureName
            );

            DataTable? dataTable = dataOperationsService.SelectResults;

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