using CRM.Model;
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
            DataGridView dataGridView,
            string detailsColumnText,
            FunctionTitle functionTitle,  
            Guid idValue
            )
        {
            await LoadActiveCompanyConfigurationAsync();

            var dataOperationsService = new DataOperationsService();

            string dataSubject = string.Empty;
            string? sortColumnName = string.Empty;
            DataSortingOrder? sortColumnOrder;            
            string storedProcedureName = string.Empty;
            string storedProcedureParameterIdName = string.Empty;
            var uiModelHelper = new UIModelHelper();

            var dataSubjectProperties = uiModelHelper.GetDataSubjectProperties(functionTitle);
            if (dataSubjectProperties == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Module.Function.NotImplemented", functionTitle.ToString());
                return;
            }

            dataSubject = dataSubjectProperties.DataSubject.DataSubjectFriendlyName;
            sortColumnName = dataSubjectProperties.DataSubject.DataSubjectSortingColumnName;
            sortColumnOrder = dataSubjectProperties.DataSubject.DataSubjectSortingColumnOrder;
            storedProcedureName = dataSubjectProperties.DataSubject.DataSubjectSelectAllStoredProcedureName;
            if (!string.IsNullOrWhiteSpace(dataSubjectProperties.DataSubject.DataSubjectStoredProcedureIdParameterName))
            {
                storedProcedureParameterIdName = dataSubjectProperties.DataSubject.DataSubjectStoredProcedureIdParameterName;
            }

            var parameters = new object[]
{
                new Dictionary<string, object>
                {
                    ["PropertyStoredProcedureParameterName"] = storedProcedureParameterIdName,
                    ["PropertyValue"] = idValue
                }
};

            await dataOperationsService.DataSubmissionServiceOrchestrator(
                dataSubjectName: dataSubject,
                dataToBeProcessed: parameters,
                operationType: DataOperationType.Select,
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

            dataTable.DefaultView.Sort = $"{sortColumn} {sortColumnOrder.ToString()}";
            dataGridView.AutoGenerateColumns = true;
            dataGridView.DataSource = dataTable;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            if (dataGridView.Columns.Contains("Details"))
                dataGridView.Columns.Remove("Details");

            var detailsLink = new DataGridViewLinkColumn
            {
                HeaderText = "Details",
                Text = detailsColumnText,
                UseColumnTextForLinkValue = true,
                Name = "Details"
            };
            dataGridView.Columns.Add(detailsLink);
        }

        // Handles the click event for a "Details" link column in a DataGridView.
        public static void HandleDetailsCellClick(
            DataGridView dataGridView,
            DataGridViewCellEventArgs dataGridViewEventArgs,
            FunctionTitle functionTitle,
            Action<Guid> showDetailForm)
        {
            UIModelHelper uiModelHelper = new UIModelHelper();

            var dataSubjectProperties = uiModelHelper.GetDataSubjectProperties(functionTitle);
            if (dataSubjectProperties == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Module.Function.NotImplemented", functionTitle.ToString());
                return;
            }

            string dataSubjectFriendlyName = string.Empty;
            string dataSubjectIdFriendlyName = string.Empty;
            
            dataSubjectFriendlyName = dataSubjectProperties.DataSubject.DataSubjectFriendlyName;
            if (!string.IsNullOrWhiteSpace(dataSubjectProperties.DataSubject.DataSubjectIdFriendlyName))
            {
                dataSubjectIdFriendlyName = dataSubjectProperties.DataSubject.DataSubjectIdFriendlyName;
            }

            if (dataGridViewEventArgs.ColumnIndex == dataGridView.Columns["Details"].Index && dataGridViewEventArgs.RowIndex >= 0)
            {
                try
                {
                    if (dataGridView.Columns.Contains(dataSubjectIdFriendlyName))
                    {
                        var cellValue = dataGridView.Rows[dataGridViewEventArgs.RowIndex].Cells[dataSubjectIdFriendlyName].Value;
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
                            new ErrorMessageService("Error.Data.IdColumnNotFound", dataSubjectIdFriendlyName);
                        }
                    }
                    else
                    {
                        new ErrorMessageService("Error.Data.IdColumnNotFound", dataSubjectIdFriendlyName);
                    }
                }
                catch (Exception ex)
                {
                    new ErrorMessageService("Error.Data.Retrieval", dataSubjectFriendlyName, ex.Message);
                }
            }
        }
    }
}