using CRM.Services;
using System.Data;

namespace CRM.Helpers
{
    internal class DataAccessLookupHelper
    {
        private Guid? _companyConfigurationId;
        private bool? _dataSubjectFilter1;
        private string? _dataSubjectFilterColumn1;
        private Guid? _dataSubjectId1;
        private bool? _dataSubjectFilter2;
        private string? _dataSubjectFilterColumn2;
        private Guid? _dataSubjectId2;
        private DataSubmissionService _dataSubmissionService;
        private string _storedProcedureName;
        private object[]? _storedProcedureParameter;

        // Add properties to expose display and value member column names
        public string DisplayMemberColumnName { get; private set; } = "Display Text";
        public string ValueMemberColumnName { get; private set; } = "Id";

        public DataAccessLookupHelper(
            string storedProcedureName,
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
            _storedProcedureName = storedProcedureName;
            if (storedProcedureParameter != null && storedProcedureParameter.Length > 0)
            {
                _storedProcedureParameter = storedProcedureParameter;
            }
            
            // Set display/value member based on stored procedure
            SetColumnMappingsForStoredProcedure(storedProcedureName);
        }

        private void SetColumnMappingsForStoredProcedure(string storedProcedureName)
        {
            switch (storedProcedureName)
            {
                case "spGetCompanyConfiguration":
                    DisplayMemberColumnName = "Company Configuration Name";
                    ValueMemberColumnName = "Company Configuration Id";
                    break;
                case "spGetAllCurrency":
                    DisplayMemberColumnName = "Currency Name";
                    ValueMemberColumnName = "Currency Id";
                    break;
                case "spGetAllWholesaleDeliveryType":
                    DisplayMemberColumnName = "Wholesale Delivery Type";
                    ValueMemberColumnName = "Wholesale Delivery Type Id";
                    break;
                default:
                    DisplayMemberColumnName = "Display Text";
                    ValueMemberColumnName = "Id";
                    break;
            }
        }

        public async Task<DataTable?> GetFilteredDataTableAsync()
        {
            string dataSubject = string.Empty;
            string idColumnName = string.Empty;

            switch (_storedProcedureName)
            {
                case "spGetAllCompanyConfiguration":
                    dataSubject = "Company Configuration";
                    idColumnName = "Company Configuration Id";
                    break;
                case "spGetAllCurrency":
                    dataSubject = "Currency";
                    idColumnName = "Currency Id";
                    break;
                case "spGetAllWholesaleDeliveryType":
                    dataSubject = "Wholesale Delivery Type";
                    idColumnName = "Wholesale Delivery Type Id";
                    break;
                default:
                    throw new ArgumentException("Invalid stored procedure name.");
            }

            DataTable? dataTable;

            if (_storedProcedureParameter != null)
            {
                await _dataSubmissionService.DataSubmissionServiceOrchestrator(
                    operationType: "Select",
                    dataSubjectName: dataSubject,
                    dataToBeProcessed: _storedProcedureParameter,
                    storedProcedureName: _storedProcedureName
                );

                dataTable = _dataSubmissionService.SelectResults;
            }
            else
            {
                await _dataSubmissionService.DataSubmissionServiceOrchestrator(
                    operationType: "SelectNoParameter",
                    dataSubjectName: dataSubject,
                    storedProcedureName: _storedProcedureName
                );

                dataTable = _dataSubmissionService.SelectResults;
            }

            // If the table has a "Display Text" column but should use a different column name
            // create that column if needed (specifically for "spGetAllWholesaleDeliveryType")
            if (_storedProcedureName == "spGetAllWholesaleDeliveryType" && 
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