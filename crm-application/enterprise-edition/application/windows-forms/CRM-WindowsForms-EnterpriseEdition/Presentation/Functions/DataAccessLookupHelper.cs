using CRM_WindowsForms_EnterpriseEdition.Interface;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation.Functions
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
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private string _storedProcedureName;
        private StoredProcedureParameter[]? _storedProcedureParameter;

        public DataAccessLookupHelper(
            string storedProcedureName,
            Guid? companyConfigurationId = null,
            bool? dataSubjectFilter1 = false,
            string? dataSubjectFilterColumn1 = null,
            Guid? dataSubjectId1 = null,
            bool? dataSubjectFilter2 = false,
            string? dataSubjectFilterColumn2 = null,
            Guid? dataSubjectId2 = null,
            StoredProcedureParameter[]? storedProcedureParameter = null)
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
            LoadDatabaseConnectionSettingsAsync();
        }

        private async void LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        public async Task<DataTable?> GetFilteredDataTableAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

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
                default:
                    throw new ArgumentException("Invalid stored procedure name.");
            }

            DataTable? dataTable = null;
            if (_storedProcedureParameter != null)
            {
                dataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(_storedProcedureName, _storedProcedureParameter, dataSubject);
            }
            else
            {
                dataTable = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(_storedProcedureName, dataSubject);
            }

            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                return null;
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