using CRM.Interface;
using CRM.Services;
using System.Data;

namespace CRM.Helpers
{
    internal class DataAccessListViewHelper
    {
        private ListView _listView;
        private Guid? _companyConfigurationId;
        private bool? _dataSubjectFilter1;
        private string? _dataSubjectFilterColumn1;
        private Guid? _dataSubjectId1;
        private bool? _dataSubjectFilter2;
        private string? _dataSubjectFilterColumn2;
        private Guid? _dataSubjectId2;
        private DataTable? _dataTable;
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private List<DataRow>? _filteredRows;
        private string _storedProcedureName;
        private StoredProcedureParameter[]? _storedProcedureParameter;

        public DataAccessListViewHelper(
            ListView listView,
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
            _listView = listView;
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

        public async Task LoadDataAsync()
        {
            string dataSubject = string.Empty;
            string idColumnName = string.Empty;

            switch (_storedProcedureName)
            {
                case "spGetAllSalesSubRegion":
                    dataSubject = "Sales Sub Region";
                    idColumnName = "Sales Sub Region Id";
                    break;
                case "spGetAllSupplier":
                    dataSubject = "Supplier";
                    idColumnName = "Supplier Id";
                    break;
                default:
                    throw new ArgumentException($"Invalid stored procedure name., {_storedProcedureName}");
            }

            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            bool connectionAvailable = false;
            try
            {
                connectionAvailable = await DBInterface.TestConnectionAsync(_databaseConnectionSettings.DatabaseConnectionString);
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

            try
            {
                DataTable? dataTable = null;

                if (_storedProcedureParameter != null)
                {
                    dataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(_storedProcedureName, _storedProcedureParameter, dataSubject);
                }
                else
                {
                    dataTable = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(_storedProcedureName, dataSubject);
                }

                _dataTable = dataTable;

                var dataListQuery = dataTable.AsEnumerable()
                    .Select(row => {
                        string displayText = "";
                        if (_storedProcedureName == "spGetAllSalesSubRegion")
                        {
                            string subRegion = row.Field<string>("Sales Sub Region");
                            string region = row.Field<string>("Sales Region");
                            displayText = $"{subRegion} ({region})";
                        }
                        else if (_storedProcedureName == "spGetAllSupplier")
                        {
                            string name = row.Field<string>("Supplier Name");
                            Guid id = row.Field<Guid>("Supplier Id");
                            displayText = $"{name} ({id})";
                        }

                        return new
                        {
                            Id = row.Field<Guid>(idColumnName),
                            DisplayText = displayText,
                            Row = row
                        };
                    })
                    .OrderBy(item => item.DisplayText);

                var filteredQuery = dataListQuery;

                // Filter by Company Configuration Id only
                if (_companyConfigurationId != null && (_dataSubjectFilter1 != true || string.IsNullOrEmpty(_dataSubjectFilterColumn1) || _dataSubjectId1 == null) &&
                    (_dataSubjectFilter2 != true || string.IsNullOrEmpty(_dataSubjectFilterColumn2) || _dataSubjectId2 == null))
                {
                    filteredQuery = filteredQuery.Where(item =>
                    {
                        var row = item.Row;
                        return row.Table.Columns.Contains("Company Configuration Id") &&
                               row.Field<Guid>("Company Configuration Id") == _companyConfigurationId;
                    }).OrderBy(item => item.DisplayText);
                }

                // Filter by Data Subject 1 only
                if (_dataSubjectFilter1 == true && !string.IsNullOrEmpty(_dataSubjectFilterColumn1) && _dataSubjectId1 != null &&
                    (_companyConfigurationId == null) && (_dataSubjectFilter2 != true || string.IsNullOrEmpty(_dataSubjectFilterColumn2) || _dataSubjectId2 == null))
                {
                    filteredQuery = filteredQuery.Where(item =>
                    {
                        var row = item.Row;
                        return row.Table.Columns.Contains(_dataSubjectFilterColumn1) &&
                               row.Field<Guid>(_dataSubjectFilterColumn1) == _dataSubjectId1;
                    }).OrderBy(item => item.DisplayText);
                }

                // Filter by Data Subject 2 only
                if (_dataSubjectFilter2 == true && !string.IsNullOrEmpty(_dataSubjectFilterColumn2) && _dataSubjectId2 != null &&
                    (_companyConfigurationId == null) && (_dataSubjectFilter1 != true || string.IsNullOrEmpty(_dataSubjectFilterColumn1) || _dataSubjectId1 == null))
                {
                    filteredQuery = filteredQuery.Where(item =>
                    {
                        var row = item.Row;
                        return row.Table.Columns.Contains(_dataSubjectFilterColumn2) &&
                               row.Field<Guid>(_dataSubjectFilterColumn2) == _dataSubjectId2;
                    }).OrderBy(item => item.DisplayText);
                }

                // Filter by both Data Subject 1 and Data Subject 2
                if (_dataSubjectFilter1 == true && !string.IsNullOrEmpty(_dataSubjectFilterColumn1) && _dataSubjectId1 != null &&
                    _dataSubjectFilter2 == true && !string.IsNullOrEmpty(_dataSubjectFilterColumn2) && _dataSubjectId2 != null &&
                    _companyConfigurationId == null)
                {
                    filteredQuery = filteredQuery.Where(item =>
                    {
                        var row = item.Row;
                        return row.Table.Columns.Contains(_dataSubjectFilterColumn1) &&
                               row.Field<Guid>(_dataSubjectFilterColumn1) == _dataSubjectId1 &&
                               row.Table.Columns.Contains(_dataSubjectFilterColumn2) &&
                               row.Field<Guid>(_dataSubjectFilterColumn2) == _dataSubjectId2;
                    }).OrderBy(item => item.DisplayText);
                }

                // Filter by both Company Configuration Id and Data Subject 1
                if (_companyConfigurationId != null && _dataSubjectFilter1 == true && !string.IsNullOrEmpty(_dataSubjectFilterColumn1) && _dataSubjectId1 != null &&
                    (_dataSubjectFilter2 != true || string.IsNullOrEmpty(_dataSubjectFilterColumn2) || _dataSubjectId2 == null))
                {
                    filteredQuery = filteredQuery.Where(item =>
                    {
                        var row = item.Row;
                        return row.Table.Columns.Contains("Company Configuration Id") &&
                               row.Field<Guid>("Company Configuration Id") == _companyConfigurationId &&
                               row.Table.Columns.Contains(_dataSubjectFilterColumn1) &&
                               row.Field<Guid>(_dataSubjectFilterColumn1) == _dataSubjectId1;
                    }).OrderBy(item => item.DisplayText);
                }

                // Filter by both Company Configuration Id and Data Subject 2
                if (_companyConfigurationId != null && _dataSubjectFilter2 == true && !string.IsNullOrEmpty(_dataSubjectFilterColumn2) && _dataSubjectId2 != null &&
                    (_dataSubjectFilter1 != true || string.IsNullOrEmpty(_dataSubjectFilterColumn1) || _dataSubjectId1 == null))
                {
                    filteredQuery = filteredQuery.Where(item =>
                    {
                        var row = item.Row;
                        return row.Table.Columns.Contains("Company Configuration Id") &&
                               row.Field<Guid>("Company Configuration Id") == _companyConfigurationId &&
                               row.Table.Columns.Contains(_dataSubjectFilterColumn2) &&
                               row.Field<Guid>(_dataSubjectFilterColumn2) == _dataSubjectId2;
                    }).OrderBy(item => item.DisplayText);
                }

                // Filter by Company Configuration Id, Data Subject 1 and Data Subject 2
                if (_companyConfigurationId != null &&
                    _dataSubjectFilter1 == true && !string.IsNullOrEmpty(_dataSubjectFilterColumn1) && _dataSubjectId1 != null &&
                    _dataSubjectFilter2 == true && !string.IsNullOrEmpty(_dataSubjectFilterColumn2) && _dataSubjectId2 != null)
                {
                    filteredQuery = filteredQuery.Where(item =>
                    {
                        var row = item.Row;
                        return row.Table.Columns.Contains("Company Configuration Id") &&
                               row.Field<Guid>("Company Configuration Id") == _companyConfigurationId &&
                               row.Table.Columns.Contains(_dataSubjectFilterColumn1) &&
                               row.Field<Guid>(_dataSubjectFilterColumn1) == _dataSubjectId1 &&
                               row.Table.Columns.Contains(_dataSubjectFilterColumn2) &&
                               row.Field<Guid>(_dataSubjectFilterColumn2) == _dataSubjectId2;
                    }).OrderBy(item => item.DisplayText);
                }

                var dataList = filteredQuery.ToList();
                _filteredRows = filteredQuery.Select(item => item.Row).ToList();

                _listView.BeginUpdate();
                _listView.Items.Clear();
                _listView.FullRowSelect = true;
                _listView.Columns.Clear();
                switch (_storedProcedureName)
                {
                    case "spGetAllSalesSubRegion":
                        _listView.Columns.Add("Name", _listView.ClientSize.Width - 4);
                        break;
                    case "spGetAllSupplier":
                        _listView.Columns.Add("Name", 400);
                        break;
                }

                foreach (var item in dataList)
                {
                    ListViewItem listViewItem = new ListViewItem(item.DisplayText);
                    listViewItem.Tag = item.Id;
                    _listView.Items.Add(listViewItem);
                }
                

                _listView.EndUpdate();
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", dataSubject, ex.Message);
            }
        }

        public List<T> GetItems<T>() where T : class, new()
        {
            var items = new List<T>();
            var rows = _filteredRows ?? _dataTable?.Rows.Cast<DataRow>();
            if (rows == null)
                return items;

            foreach (DataRow row in rows)
            {
                var item = new T();
                foreach (var prop in typeof(T).GetProperties())
                {
                    var matchingColumn = row.Table.Columns
                        .Cast<DataColumn>()
                        .FirstOrDefault(col =>
                            string.Equals(
                                col.ColumnName.Replace(" ", ""),
                                prop.Name,
                                StringComparison.OrdinalIgnoreCase
                            )
                        );
                    if (matchingColumn != null && row[matchingColumn] != DBNull.Value)
                    {
                        prop.SetValue(item, Convert.ChangeType(row[matchingColumn], prop.PropertyType));
                    }
                }
                items.Add(item);
            }
            return items;
        }

        public static void PrepareListViewColumnsIfNeeded(ListView listView, string headerText)
        {
            if (listView == null) throw new ArgumentNullException(nameof(listView));
            if (string.IsNullOrWhiteSpace(headerText)) headerText = "Name";

            if (listView.View == View.Details)
            {
                if (listView.Columns.Count == 0)
                {
                    listView.Columns.Add(headerText, -2, HorizontalAlignment.Left);
                }
                // Auto-resize can be done by caller after items are added.
            }
            else if (listView.View != View.List && listView.View != View.Details)
            {
                // Force a safe mode
                listView.View = View.List;
            }
        }
    }
}