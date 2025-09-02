using CRM_WindowsForms_EnterpriseEdition.Interface;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation.Functions
{
    internal class DataAccessComboBoxHelper
    {
        private ComboBox _comboBox;
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

        public DataAccessComboBoxHelper(
            ComboBox comboBox,
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
            _comboBox = comboBox;
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

        private class ComboBoxItem
        {
            public Guid Id { get; set; }
            public string DisplayText { get; set; } = string.Empty;
            public Dictionary<string, object> Columns { get; set; } = new();
        }

        private async void LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        public async Task LoadDataAsync()
        {
            if (_databaseConnectionSettings == null)
            {
                _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
            }

            string dataSubject = string.Empty;
            string idColumnName = string.Empty;

            switch (_storedProcedureName)
            {
                case "spGetAllAccountManager":
                    dataSubject = "Account Manager";
                    idColumnName = "Account Manager Id";
                    break;
                case "spGetAllCompanyConfiguration":
                    dataSubject = "Company Configuration";
                    idColumnName = "Company Configuration Id";
                    break;
                case "spGetAllCountry":
                    dataSubject = "Country";
                    idColumnName = "Country Id";
                    break;
                case "spGetAllCurrency":
                    dataSubject = "Currency";
                    idColumnName = "Currency Id";
                    break;
                case "spGetAllCustomerContactForCustomer":
                    dataSubject = "Customer Contact";
                    idColumnName = "Customer Contact Id";
                    break;
                case "spGetAllCustomerLeadNoteType":
                    dataSubject = "Customer Lead Note Type";
                    idColumnName = "Customer Lead Note Type Id";
                    break;
                case "spGetAllCustomerLeadType":
                    dataSubject = "Customer Lead Type";
                    idColumnName = "Customer Lead Type Id";
                    break;
                case "spGetAllCustomerNoteType":
                    dataSubject = "Customer Note Type";
                    idColumnName = "Customer Note Type Id";
                    break;
                case "spGetAllCustomerTier":
                    dataSubject = "Customer Tier";
                    idColumnName = "Customer Tier Id";
                    break;
                case "spGetAllCustomerType":
                    dataSubject = "Customer Type";
                    idColumnName = "Customer Type Id";
                    break;
                case "spGetAllGlobalParentCustomer":
                    dataSubject = "Global Parent Customer";
                    idColumnName = "Customer Id";
                    break;
                case "spGetAllHTMLTemplateType":
                    dataSubject = "HTML Template Type";
                    idColumnName = "HTML Template Type Id";
                    break;
                case "spGetAllManufacturer":
                    dataSubject = "Manufacturer";
                    idColumnName = "Manufacturer Id";
                    break;
                case "spGetAllMarketingChannel":
                    dataSubject = "Marketing Channel";
                    idColumnName = "Marketing Channel Id";
                    break;
                case "spGetAllProductCategory":
                    dataSubject = "Product Category";
                    idColumnName = "Product Category Id";
                    break;
                case "spGetAllProductFamily":
                    dataSubject = "Product Family";
                    idColumnName = "Product Family Id";
                    break;
                case "spGetAllProductNoteType":
                    dataSubject = "Product Note Type";
                    idColumnName = "Product Note Type Id";
                    break;
                case "spGetAllProductSubCategory":
                    dataSubject = "Product Sub Category";
                    idColumnName = "Product Sub Category Id";
                    break;
                case "spGetAllPromotionTargetType":
                    dataSubject = "Promotion Target Type";
                    idColumnName = "Promotion Target Type Id";
                    break;
                case "spGetAllSalesRegion":
                    dataSubject = "Sales Region";
                    idColumnName = "Sales Region Id";
                    break;
                case "spGetAllSalesSubRegion":
                    dataSubject = "Sales Sub Region";
                    idColumnName = "Sales Sub Region Id";
                    break;
                case "spGetAllSupplierNoteType":
                    dataSubject = "Supplier Note Type";
                    idColumnName = "Supplier Note Type Id";
                    break;
                case "spGetAllTaxProfile":
                    dataSubject = "Tax Profile";
                    idColumnName = "Tax Profile Id";
                    break;
                case "spGetAllTopParentCustomer":
                    dataSubject = "Top Parent Customer";
                    idColumnName = "Customer Id";
                    break;
                case "spGetAllWholesaleDeliveryType":
                    dataSubject = "Wholesale Delivery Type";
                    idColumnName = "Wholesale Delivery Type Id";
                    break;
                default:
                    throw new ArgumentException("Invalid stored procedure name.");
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

                // Defensive: Ensure idColumnName exists in the table
                if (!string.IsNullOrWhiteSpace(idColumnName) && !dataTable.Columns.Contains(idColumnName))
                {
                    throw new Exception($"Column '{idColumnName}' does not exist in the result set.");
                }

                if (dataTable == null || dataTable.Rows.Count == 0)
                {
                    if (_companyConfigurationId != null)
                    {
                        new ErrorMessageService("Warning.NoDataFound.CompanyConfiguration.Specific", dataSubject);
                        return;
                    }
                    else
                    {
                        new ErrorMessageService("Information.NoDataFound", dataSubject);
                        return;
                    }
                }

                var dataListQuery = dataTable.AsEnumerable()
                    .Select(row =>
                    {
                        var item = new ComboBoxItem();
                        foreach (DataColumn col in dataTable.Columns)
                        {
                            item.Columns[col.ColumnName] = row[col];
                        }
                        item.Id = (!string.IsNullOrWhiteSpace(idColumnName) && dataTable.Columns.Contains(idColumnName))
                            ? row.Field<Guid>(idColumnName)
                            : Guid.Empty;
                        item.DisplayText = _storedProcedureName switch
                        {
                            "spGetAllAccountManager" => $"{row.Field<string>("Last Name")}, {row.Field<string>("First Name")} | {row.Field<string>("Email Address")}",
                            "spGetAllCompanyConfiguration" => $"{row.Field<string>("Company Name")} ({row.Field<Guid>("Company Configuration Id")})",
                            "spGetAllCountry" => $"{row.Field<string>("ISO 3166-1 Alpha 2 Country Code")} - {row.Field<string>("Country English Name")}",
                            "spGetAllCurrency" => $"{row.Field<string>("Currency Code")} - {row.Field<string>("Currency Name")}",
                            "spGetAllCustomerContactForCustomer" => $"{row.Field<string>("Customer Contact Last Name")}, {row.Field<string>("Customer Contact First Name")} - {row.Field<string>("Customer Contact Email Address")}",
                            "spGetAllCustomerLeadNoteType" => row.Field<string>("Customer Lead Note Type"),
                            "spGetAllCustomerLeadType" => $"{row.Field<string>("Customer Lead Type")} - {row.Field<string>("Customer Lead Type Description")}",
                            "spGetAllCustomerNoteType" => row.Field<string>("Customer Note Type"),
                            "spGetAllCustomerTier" => $"{row.Field<string>("Customer Tier Code")} - {row.Field<string>("Customer Tier Description")}",
                            "spGetAllCustomerType" => $"{row.Field<string>("Customer Type")} - {row.Field<string>("Customer Type Description")}",
                            "spGetAllGlobalParentCustomer" => $"{row.Field<string>("Customer Id")} | {row.Field<string>("Company Name")}",
                            "spGetAllHTMLTemplateType" => row.Field<string>("HTML Template Type"),
                            "spGetAllManufacturer" => row.Field<string>("Manufacturer Name"),
                            "spGetAllMarketingChannel" => row.Field<string>("Marketing Channel"),
                            "spGetAllProductCategory" => row.Field<string>("Product Category"),
                            "spGetAllProductFamily" => row.Field<string>("Product Family"),
                            "spGetAllProductNoteType" => row.Field<string>("Product Note Type"),
                            "spGetAllProductSubCategory" => row.Field<string>("Product Sub Category"),
                            "spGetAllPromotionTargetType" => $"{row.Field<string>("Promotion Target Type")} - {row.Field<string>("Promotion Target Type Description")}",
                            "spGetAllSalesRegion" => row.Field<string>("Sales Region"),
                            "spGetAllSalesSubRegion" => row.Field<string>("Sales Sub Region"),
                            "spGetAllSupplierNoteType" => row.Field<string>("Supplier Note Type"),
                            "spGetAllTaxProfile" => $"{row.Field<string>("Tax Profile")} | {row.Field<decimal>("Tax Rate")}",
                            "spGetAllTopParentCustomer" => $"{row.Field<string>("Customer Id")} | {row.Field<string>("Company Name")}",
                            "spGetAllWholesaleDeliveryType" => row.Field<string>("Wholesale Delivery Type"),
                            _ => string.Empty
                        };
                        return item;
                    })
                    .OrderBy(item => item.DisplayText)
                    .ToList();

                // Filtering logic
                var filteredQuery = dataListQuery;

                // Filter by Company Configuration Id only
                if (_companyConfigurationId != null && (_dataSubjectFilter1 != true || string.IsNullOrEmpty(_dataSubjectFilterColumn1) || _dataSubjectId1 == null) &&
                    (_dataSubjectFilter2 != true || string.IsNullOrEmpty(_dataSubjectFilterColumn2) || _dataSubjectId2 == null))
                {
                    filteredQuery = filteredQuery.Where(item =>
                    {
                        var row = dataTable.AsEnumerable().FirstOrDefault(r => r.Field<Guid>(idColumnName) == item.Id);
                        return row != null && row.Table.Columns.Contains("Company Configuration Id") &&
                               row.Field<Guid>("Company Configuration Id") == _companyConfigurationId;
                    }).OrderBy(item => item.DisplayText).ToList();
                }

                // Filter by Data Subject 1 only
                if (_dataSubjectFilter1 == true && !string.IsNullOrEmpty(_dataSubjectFilterColumn1) && _dataSubjectId1 != null &&
                    (_companyConfigurationId == null) && (_dataSubjectFilter2 != true || string.IsNullOrEmpty(_dataSubjectFilterColumn2) || _dataSubjectId2 == null))
                {
                    filteredQuery = filteredQuery.Where(item =>
                    {
                        var row = dataTable.AsEnumerable().FirstOrDefault(r => r.Field<Guid>(idColumnName) == item.Id);
                        return row != null && row.Table.Columns.Contains(_dataSubjectFilterColumn1) &&
                               row.Field<Guid>(_dataSubjectFilterColumn1) == _dataSubjectId1;
                    }).OrderBy(item => item.DisplayText).ToList();
                }

                // Filter by Data Subject 2 only
                if (_dataSubjectFilter2 == true && !string.IsNullOrEmpty(_dataSubjectFilterColumn2) && _dataSubjectId2 != null &&
                    (_companyConfigurationId == null) && (_dataSubjectFilter1 != true || string.IsNullOrEmpty(_dataSubjectFilterColumn1) || _dataSubjectId1 == null))
                {
                    filteredQuery = filteredQuery.Where(item =>
                    {
                        var row = dataTable.AsEnumerable().FirstOrDefault(r => r.Field<Guid>(idColumnName) == item.Id);
                        return row != null && row.Table.Columns.Contains(_dataSubjectFilterColumn2) &&
                               row.Field<Guid>(_dataSubjectFilterColumn2) == _dataSubjectId2;
                    }).OrderBy(item => item.DisplayText).ToList();
                }

                // Filter by both Data Subject 1 and Data Subject 2
                if (_dataSubjectFilter1 == true && !string.IsNullOrEmpty(_dataSubjectFilterColumn1) && _dataSubjectId1 != null &&
                    _dataSubjectFilter2 == true && !string.IsNullOrEmpty(_dataSubjectFilterColumn2) && _dataSubjectId2 != null &&
                    _companyConfigurationId == null)
                {
                    filteredQuery = filteredQuery.Where(item =>
                    {
                        var row = dataTable.AsEnumerable().FirstOrDefault(r => r.Field<Guid>(idColumnName) == item.Id);
                        return row != null &&
                               row.Table.Columns.Contains(_dataSubjectFilterColumn1) &&
                               row.Field<Guid>(_dataSubjectFilterColumn1) == _dataSubjectId1 &&
                               row.Table.Columns.Contains(_dataSubjectFilterColumn2) &&
                               row.Field<Guid>(_dataSubjectFilterColumn2) == _dataSubjectId2;
                    }).OrderBy(item => item.DisplayText).ToList();
                }

                // Filter by both Company Configuration Id and Data Subject 1
                if (_companyConfigurationId != null && _dataSubjectFilter1 == true && !string.IsNullOrEmpty(_dataSubjectFilterColumn1) && _dataSubjectId1 != null &&
                    (_dataSubjectFilter2 != true || string.IsNullOrEmpty(_dataSubjectFilterColumn2) || _dataSubjectId2 == null))
                {
                    filteredQuery = filteredQuery.Where(item =>
                    {
                        var row = dataTable.AsEnumerable().FirstOrDefault(r => r.Field<Guid>(idColumnName) == item.Id);
                        return row != null &&
                               row.Table.Columns.Contains("Company Configuration Id") &&
                               row.Field<Guid>("Company Configuration Id") == _companyConfigurationId &&
                               row.Table.Columns.Contains(_dataSubjectFilterColumn1) &&
                               row.Field<Guid>(_dataSubjectFilterColumn1) == _dataSubjectId1;
                    }).OrderBy(item => item.DisplayText).ToList();
                }

                // Filter by both Company Configuration Id and Data Subject 2
                if (_companyConfigurationId != null && _dataSubjectFilter2 == true && !string.IsNullOrEmpty(_dataSubjectFilterColumn2) && _dataSubjectId2 != null &&
                    (_dataSubjectFilter1 != true || string.IsNullOrEmpty(_dataSubjectFilterColumn1) || _dataSubjectId1 == null))
                {
                    filteredQuery = filteredQuery.Where(item =>
                    {
                        var row = dataTable.AsEnumerable().FirstOrDefault(r => r.Field<Guid>(idColumnName) == item.Id);
                        return row != null &&
                               row.Table.Columns.Contains("Company Configuration Id") &&
                               row.Field<Guid>("Company Configuration Id") == _companyConfigurationId &&
                               row.Table.Columns.Contains(_dataSubjectFilterColumn2) &&
                               row.Field<Guid>(_dataSubjectFilterColumn2) == _dataSubjectId2;
                    }).OrderBy(item => item.DisplayText).ToList();
                }

                // Filter by Company Configuration Id, Data Subject 1 and Data Subject 2
                if (_companyConfigurationId != null &&
                    _dataSubjectFilter1 == true && !string.IsNullOrEmpty(_dataSubjectFilterColumn1) && _dataSubjectId1 != null &&
                    _dataSubjectFilter2 == true && !string.IsNullOrEmpty(_dataSubjectFilterColumn2) && _dataSubjectId2 != null)
                {
                    filteredQuery = filteredQuery.Where(item =>
                    {
                        var row = dataTable.AsEnumerable().FirstOrDefault(r => r.Field<Guid>(idColumnName) == item.Id);
                        return row != null &&
                               row.Table.Columns.Contains("Company Configuration Id") &&
                               row.Field<Guid>("Company Configuration Id") == _companyConfigurationId &&
                               row.Table.Columns.Contains(_dataSubjectFilterColumn1) &&
                               row.Field<Guid>(_dataSubjectFilterColumn1) == _dataSubjectId1 &&
                               row.Table.Columns.Contains(_dataSubjectFilterColumn2) &&
                               row.Field<Guid>(_dataSubjectFilterColumn2) == _dataSubjectId2;
                    }).OrderBy(item => item.DisplayText).ToList();
                }

                var finalList = filteredQuery;

                _comboBox.DataSource = finalList;
                _comboBox.DisplayMember = "DisplayText";
                _comboBox.ValueMember = "Id";
                if (finalList.Count > 0)
                {
                    _comboBox.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService("Error.Data.Retrieval", dataSubject, ex.Message);
            }
        }
    }
}