using CRM.Services;
using System.Data;

namespace CRM.Helpers
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
        private DataOperationsService _dataOperationsService = new();
        private string _storedProcedureName;
        private object[]? _storedProcedureParameter;
        private bool _treatFiltersAsPreselection;

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
            object[]? storedProcedureParameter = null,
            bool treatFiltersAsPreselection = false)
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
            _treatFiltersAsPreselection = treatFiltersAsPreselection;
        }

        private class ComboBoxItem
        {
            public Guid Id { get; set; }
            public string DisplayText { get; set; } = string.Empty;
            public Dictionary<string, object> Columns { get; set; } = new();
        }

        public async Task LoadDataAsync()
        {
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
                DataTable? dataTable;

                if (_storedProcedureParameter != null)
                {
                    await _dataOperationsService.DataSubmissionServiceOrchestrator(
                        operationType: "Select",
                        dataSubjectName: dataSubject,
                        dataToBeProcessed: _storedProcedureParameter,
                        storedProcedureName: _storedProcedureName
                    );

                    dataTable = _dataOperationsService.SelectResults;
                }
                else
                {
                    await _dataOperationsService.DataSubmissionServiceOrchestrator(
                        operationType: "SelectNoParameter",
                        dataSubjectName: dataSubject,
                        storedProcedureName: _storedProcedureName
                    );

                    dataTable = _dataOperationsService.SelectResults;
                }

                if (!string.IsNullOrWhiteSpace(idColumnName) && !dataTable.Columns.Contains(idColumnName))
                {
                    throw new Exception($"Column '{idColumnName}' does not exist in the result set.");
                }

                var allItems = dataTable.AsEnumerable()
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
                    .OrderBy(i => i.DisplayText)
                    .ToList();

                // Always restrict dataset first if a Company Configuration Id is provided
                if (_companyConfigurationId.HasValue)
                {
                    allItems = allItems
                        .Where(ci => TryGetGuid(ci, "Company Configuration Id", out var g) && g == _companyConfigurationId.Value)
                        .OrderBy(i => i.DisplayText)
                        .ToList();
                }

                List<ComboBoxItem> finalList;
                Guid? preselectId = null;

                if (_treatFiltersAsPreselection)
                {
                    // Determine preselect from filters (priority: DataSubject1 then DataSubject2 then CompanyConfiguration)
                    if (_dataSubjectFilter1 == true &&
                        !string.IsNullOrWhiteSpace(_dataSubjectFilterColumn1) &&
                        _dataSubjectId1.HasValue)
                    {
                        preselectId = FindMatchingItemId(allItems, _dataSubjectFilterColumn1, _dataSubjectId1.Value);
                    }
                    else if (_dataSubjectFilter2 == true &&
                             !string.IsNullOrWhiteSpace(_dataSubjectFilterColumn2) &&
                             _dataSubjectId2.HasValue)
                    {
                        preselectId = FindMatchingItemId(allItems, _dataSubjectFilterColumn2, _dataSubjectId2.Value);
                    }
                    else if (_companyConfigurationId.HasValue)
                    {
                        preselectId = FindMatchingItemId(allItems, "Company Configuration Id", _companyConfigurationId.Value);
                    }

                    finalList = allItems;
                }
                else
                {
                    // Apply remaining restrictive filters (Company Configuration already applied)
                    IEnumerable<ComboBoxItem> filtered = allItems;

                    if (_dataSubjectFilter1 == true &&
                        !string.IsNullOrWhiteSpace(_dataSubjectFilterColumn1) &&
                        _dataSubjectId1.HasValue)
                    {
                        filtered = filtered.Where(ci =>
                            TryGetGuid(ci, _dataSubjectFilterColumn1, out var g) && g == _dataSubjectId1.Value);
                    }

                    if (_dataSubjectFilter2 == true &&
                        !string.IsNullOrWhiteSpace(_dataSubjectFilterColumn2) &&
                        _dataSubjectId2.HasValue)
                    {
                        filtered = filtered.Where(ci =>
                            TryGetGuid(ci, _dataSubjectFilterColumn2, out var g) && g == _dataSubjectId2.Value);
                    }

                    finalList = filtered.OrderBy(i => i.DisplayText).ToList();
                }

                if (finalList.Count == 0)
                {
                    _ = new ErrorMessageService("Information.NoDataFound", dataSubject);
                }

                _comboBox.DataSource = finalList;
                _comboBox.DisplayMember = "DisplayText";
                _comboBox.ValueMember = "Id";

                if (_treatFiltersAsPreselection && preselectId.HasValue)
                {
                    _comboBox.SelectedValue = preselectId.Value;
                    if (_comboBox.SelectedValue == null || !_comboBox.SelectedValue.Equals(preselectId.Value))
                    {
                        int idx = finalList.FindIndex(i => i.Id == preselectId.Value);
                        if (idx >= 0) _comboBox.SelectedIndex = idx;
                    }
                }
                else if (finalList.Count > 0)
                {
                    _comboBox.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                _ = new ErrorMessageService("Error.Data.Retrieval", dataSubject, ex.Message);
            }
        }

        private Guid? FindMatchingItemId(List<ComboBoxItem> items, string columnName, Guid match)
        {
            foreach (var item in items)
            {
                if (TryGetGuid(item, columnName, out var g) && g == match)
                {
                    return item.Id; // Use the item's Id as the selection
                }
            }
            return null;
        }

        private static bool TryGetGuid(ComboBoxItem item, string columnName, out Guid value)
        {
            value = Guid.Empty;
            if (!item.Columns.TryGetValue(columnName, out var raw) || raw == null || raw == DBNull.Value)
                return false;

            if (raw is Guid g)
            {
                value = g;
                return true;
            }

            if (raw is string s && Guid.TryParse(s, out g))
            {
                value = g;
                return true;
            }

            return false;
        }
    }
}