using CRM.Model;
using CRM.Services;
using System.Data;

namespace CRM.Helpers
{
    internal class DataAccessLookupHelper
    {
        private Guid? _companyConfigurationId;
        private string _dataSubject;
        private bool? _dataSubjectFilter1;
        private string? _dataSubjectFilterColumn1;
        private Guid? _dataSubjectId1;
        private bool? _dataSubjectFilter2;
        private string? _dataSubjectFilterColumn2;
        private Guid? _dataSubjectId2;
        private DataOperationsService _dataOperationsService = new DataOperationsService();
        private FunctionTitle _functionTitle;
        private string _idColumnName;
        private object[]? _storedProcedureParameter;
        private string _storedProcedureName;
        private UIModelHelper _uiModelHelper = new UIModelHelper();

        // Add properties to expose display and value member column names
        public string DisplayMemberColumnName { get; private set; } = "Display Text";
        public string ValueMemberColumnName { get; private set; } = "Id";

        public DataAccessLookupHelper(
            FunctionTitle functionTitle,
            Guid? companyConfigurationId = null,
            bool? dataSubjectFilter1 = false,
            string? dataSubjectFilterColumn1 = null,
            Guid? dataSubjectId1 = null,
            bool? dataSubjectFilter2 = false,
            string? dataSubjectFilterColumn2 = null,
            Guid? dataSubjectId2 = null,
            object[]? storedProcedureParameter = null)
        {
            if (companyConfigurationId.HasValue && companyConfigurationId.Value != Guid.Empty)
            {
                _companyConfigurationId = companyConfigurationId;
            }
            _dataSubjectFilter1 = dataSubjectFilter1;
            if (dataSubjectFilterColumn1 != null)
            {
                _dataSubjectFilterColumn1 = dataSubjectFilterColumn1;
            }
            if (dataSubjectId1.HasValue && dataSubjectId1.Value != Guid.Empty)
            {
                _dataSubjectId1 = dataSubjectId1;
            }
            _dataSubjectFilter2 = dataSubjectFilter2;
            if (dataSubjectFilterColumn2 != null)
            {
                _dataSubjectFilterColumn2 = dataSubjectFilterColumn2;
            }
            if (dataSubjectId2.HasValue && dataSubjectId2.Value != Guid.Empty)
            {
                _dataSubjectId2 = dataSubjectId2;
            }
            _functionTitle = functionTitle;
            if (storedProcedureParameter != null && storedProcedureParameter.Length > 0)
            {
                _storedProcedureParameter = storedProcedureParameter;
            }

            var dataSubjectProperties = _uiModelHelper.GetDataSubjectProperties(_functionTitle);
            if (dataSubjectProperties == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Module.Function.NotImplemented", _functionTitle.ToString());
                return;
            }

            _dataSubject = dataSubjectProperties.DataSubject.DataSubjectFriendlyName;
            _idColumnName = dataSubjectProperties.DataSubject.DataSubjectIdFriendlyName ?? "Id";
            _storedProcedureName = dataSubjectProperties.DataSubject.DataSubjectSelectAllStoredProcedureName;
            ValueMemberColumnName = dataSubjectProperties.DataSubject.DataSubjectIdFriendlyName ?? "Id";

            // Set display/value member based on stored procedure
            SetColumnMappingsForStoredProcedure();
        }

        private void SetColumnMappingsForStoredProcedure()
        {
            switch (_functionTitle)
            {
                case FunctionTitle.CompanyConfiguration:
                    DisplayMemberColumnName = "Company Name";
                    break;
                case FunctionTitle.Currency:
                    DisplayMemberColumnName = "Currency Code";
                    break;
                case FunctionTitle.WholesaleDeliveryType:
                    DisplayMemberColumnName = "Wholesale Delivery Type";
                    break;
                default:
                    DisplayMemberColumnName = "Display Text";
                    break;
            }
        }

        public async Task<DataTable?> GetFilteredDataTableAsync()
        {
            DataTable? dataTable = new DataTable();

            if (_storedProcedureParameter != null)
            {
                bool success = await _dataOperationsService.DataOperationsServiceOrchestrator(                    
                    dataSubjectName: _dataSubject,
                    dataToBeProcessed: _storedProcedureParameter,
                    operationType: DataOperationType.Select,
                    storedProcedureName: _storedProcedureName
                );

                if (success)
                {
                    dataTable = _dataOperationsService.SelectResults;
                }
                else
                {
                    return dataTable;
                }
            }
            else
            {
                bool success = await _dataOperationsService.DataOperationsServiceOrchestrator(                    
                    dataSubjectName: _dataSubject,
                    operationType: DataOperationType.SelectNoParameter,
                    storedProcedureName: _storedProcedureName
                );

                if (success)
                {
                    dataTable = _dataOperationsService.SelectResults;
                }
                else
                {
                    return dataTable;
                }
            }

            // If the table has a "Display Text" column but should use a different column name
            // create that column if needed (specifically for FunctionTitle.WholesaleDeliveryType)
            if (_functionTitle == FunctionTitle.WholesaleDeliveryType && 
                dataTable.Columns.Contains("Wholesale Delivery Type") && 
                !dataTable.Columns.Contains("Display Text"))
            {
                dataTable.Columns.Add("Display Text", typeof(string));
                foreach (DataRow row in dataTable.Rows)
                {
                    row["Display Text"] = row["Wholesale Delivery Type"].ToString();
                }
            }

            // Filtering logic (same as in LoadDataAsync)
            var filteredRows = dataTable.AsEnumerable();

            if (_companyConfigurationId != null && (_dataSubjectFilter1 != true || string.IsNullOrEmpty(_dataSubjectFilterColumn1) || _dataSubjectId1 == null) &&
                (_dataSubjectFilter2 != true || string.IsNullOrEmpty(_dataSubjectFilterColumn2) || _dataSubjectId2 == null))
            {
                filteredRows = filteredRows.Where(row =>
                    row.Table.Columns.Contains("Company Configuration Id") &&
                    row.Field<Guid>("Company Configuration Id") == _companyConfigurationId);
            }

            if (_dataSubjectFilter1 == true && !string.IsNullOrEmpty(_dataSubjectFilterColumn1) && _dataSubjectId1 != null &&
                (_companyConfigurationId == null) && (_dataSubjectFilter2 != true || string.IsNullOrEmpty(_dataSubjectFilterColumn2) || _dataSubjectId2 == null))
            {
                filteredRows = filteredRows.Where(row =>
                    row.Table.Columns.Contains(_dataSubjectFilterColumn1) &&
                    row.Field<Guid>(_dataSubjectFilterColumn1) == _dataSubjectId1);
            }

            if (_dataSubjectFilter2 == true && !string.IsNullOrEmpty(_dataSubjectFilterColumn2) && _dataSubjectId2 != null &&
                (_companyConfigurationId == null) && (_dataSubjectFilter1 != true || string.IsNullOrEmpty(_dataSubjectFilterColumn1) || _dataSubjectId1 == null))
            {
                filteredRows = filteredRows.Where(row =>
                    row.Table.Columns.Contains(_dataSubjectFilterColumn2) &&
                    row.Field<Guid>(_dataSubjectFilterColumn2) == _dataSubjectId2);
            }

            if (_dataSubjectFilter1 == true && !string.IsNullOrEmpty(_dataSubjectFilterColumn1) && _dataSubjectId1 != null &&
                _dataSubjectFilter2 == true && !string.IsNullOrEmpty(_dataSubjectFilterColumn2) && _dataSubjectId2 != null &&
                _companyConfigurationId == null)
            {
                filteredRows = filteredRows.Where(row =>
                    row.Table.Columns.Contains(_dataSubjectFilterColumn1) &&
                    row.Field<Guid>(_dataSubjectFilterColumn1) == _dataSubjectId1 &&
                    row.Table.Columns.Contains(_dataSubjectFilterColumn2) &&
                    row.Field<Guid>(_dataSubjectFilterColumn2) == _dataSubjectId2);
            }

            if (_companyConfigurationId != null && _dataSubjectFilter1 == true && !string.IsNullOrEmpty(_dataSubjectFilterColumn1) && _dataSubjectId1 != null &&
                (_dataSubjectFilter2 != true || string.IsNullOrEmpty(_dataSubjectFilterColumn2) || _dataSubjectId2 == null))
            {
                filteredRows = filteredRows.Where(row =>
                    row.Table.Columns.Contains("Company Configuration Id") &&
                    row.Field<Guid>("Company Configuration Id") == _companyConfigurationId &&
                    row.Table.Columns.Contains(_dataSubjectFilterColumn1) &&
                    row.Field<Guid>(_dataSubjectFilterColumn1) == _dataSubjectId1);
            }

            if (_companyConfigurationId != null && _dataSubjectFilter2 == true && !string.IsNullOrEmpty(_dataSubjectFilterColumn2) && _dataSubjectId2 != null &&
                (_dataSubjectFilter1 != true || string.IsNullOrEmpty(_dataSubjectFilterColumn1) || _dataSubjectId1 == null))
            {
                filteredRows = filteredRows.Where(row =>
                    row.Table.Columns.Contains("Company Configuration Id") &&
                    row.Field<Guid>("Company Configuration Id") == _companyConfigurationId &&
                    row.Table.Columns.Contains(_dataSubjectFilterColumn2) &&
                    row.Field<Guid>(_dataSubjectFilterColumn2) == _dataSubjectId2);
            }

            if (_companyConfigurationId != null &&
                _dataSubjectFilter1 == true && !string.IsNullOrEmpty(_dataSubjectFilterColumn1) && _dataSubjectId1 != null &&
                _dataSubjectFilter2 == true && !string.IsNullOrEmpty(_dataSubjectFilterColumn2) && _dataSubjectId2 != null)
            {
                filteredRows = filteredRows.Where(row =>
                    row.Table.Columns.Contains("Company Configuration Id") &&
                    row.Field<Guid>("Company Configuration Id") == _companyConfigurationId &&
                    row.Table.Columns.Contains(_dataSubjectFilterColumn1) &&
                    row.Field<Guid>(_dataSubjectFilterColumn1) == _dataSubjectId1 &&
                    row.Table.Columns.Contains(_dataSubjectFilterColumn2) &&
                    row.Field<Guid>(_dataSubjectFilterColumn2) == _dataSubjectId2);
            }

            // Create a new DataTable with the same schema and add filtered rows
            DataTable filteredTable = dataTable.Clone();
            foreach (var row in filteredRows)
            {
                filteredTable.ImportRow(row);
            }

            return filteredTable.Rows.Count > 0 ? filteredTable : null;
        }
    }
}