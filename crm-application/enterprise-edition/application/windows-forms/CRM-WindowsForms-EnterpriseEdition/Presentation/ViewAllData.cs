using CRM_WindowsForms_EnterpriseEdition.Interface;
using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;
using System.Data;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class ViewAllData : Form
    {
        private readonly string _functionTitle;
        private readonly string _moduleGroup;
        private readonly string applicationTitlePrefix = "CRM - ";
        private DatabaseConnectionSettings? _databaseConnectionSettings;
        private string dataSortingColumnName;
        private string dataSortingColumnOrder;
        private readonly Guid? _dataSubjectFilterId;
        private string dataSubjectFriendlyName;
        private string dataSubjectIdentityColumn;
        private string? dataSubjectParentIdentityId;
        private string functionFriendlyName;
        private string storedProcedureName;
        private readonly string viewAllPrefix = "View All ";

        public ViewAllData(string functionTitle, string moduleGroup, Guid? dataSubjectFilterId = null)
        {
            InitializeComponent();
            _dataSubjectFilterId = dataSubjectFilterId;
            _functionTitle = functionTitle;
            _moduleGroup = moduleGroup;
            SetModuleTheme(_moduleGroup);
            SetParameters(_functionTitle);
            viewAllDataDataGridView.CellContentClick += viewAllDataDataGridView_CellContentClick;
            viewAllDataQuickFilterTextbox.TextChanged += viewAllDataQuickFilterTextbox_TextChanged;
        }

        private async Task LoadDatabaseConnectionSettingsAsync()
        {
            _databaseConnectionSettings = await DatabaseConnectionSettings.LoadAsync();
        }

        private void SetModuleTheme(string moduleGroup)
        {
            switch (moduleGroup)
            {
                case "CompanyManagement":
                    this.BackColor = Color.LemonChiffon;
                    viewAllDataDataGridView.BackgroundColor = Color.LemonChiffon;
                    break;
                case "CustomerManagement":
                    this.BackColor = Color.LightGreen;
                    viewAllDataDataGridView.BackgroundColor = Color.LightGreen;
                    break;
                case "MarketingManagement":
                    this.BackColor = Color.NavajoWhite;
                    viewAllDataDataGridView.BackgroundColor = Color.NavajoWhite;
                    break;
                case "OrderManagement":
                    this.BackColor = Color.LightSalmon;
                    viewAllDataDataGridView.BackgroundColor = Color.LightSalmon;
                    break;
                case "ProductManagement":
                    this.BackColor = Color.SkyBlue;
                    viewAllDataDataGridView.BackgroundColor = Color.SkyBlue;
                    break;
                case "SupplierManagement":
                    this.BackColor = Color.MediumAquamarine;
                    viewAllDataDataGridView.BackgroundColor = Color.MediumAquamarine;
                    break;
                default:
                    ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Module.NotImplemented", moduleGroup);
                    break;
            }
        }

        private void SetParameters(string functionTitle)
        {
            switch (functionTitle)
            {
                case "AccountManager":
                    dataSortingColumnName = "Last Name";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Account Manager Id";
                    dataSubjectFriendlyName = "Account Manager";
                    functionFriendlyName = "Account Managers";
                    storedProcedureName = "[dbo].[spGetAllAccountManager]";
                    break;
                case "CompanyConfiguration":
                    dataSortingColumnName = "Company Name";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Company Configuration Id";
                    dataSubjectFriendlyName = "Company Configuration";
                    functionFriendlyName = "Company Configurations";
                    storedProcedureName = "[dbo].[spGetAllCompanyConfiguration]";
                    break;
                case "Country":
                    dataSortingColumnName = "Country English Name";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Country Id";
                    dataSubjectFriendlyName = "Country";
                    functionFriendlyName = "Countries";
                    storedProcedureName = "[dbo].[spGetAllCountry]";
                    break;
                case "CountryTranslation":
                    dataSortingColumnName = "Country English Name";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Country Translation Id";
                    dataSubjectFriendlyName = "Country Translation";
                    functionFriendlyName = "Country Translations";
                    storedProcedureName = "[dbo].[spGetAllCountryTranslation]";
                    break;
                case "Currency":
                    dataSortingColumnName = "Currency Code";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Currency Id";
                    dataSubjectFriendlyName = "Currency";
                    functionFriendlyName = "Currencies";
                    storedProcedureName = "[dbo].[spGetAllCurrency]";
                    break;
                case "CurrencyConversion":
                    dataSortingColumnName = "Currency Conversion Friendly Name";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Currency Conversion Id";
                    dataSubjectFriendlyName = "Currency Conversion";
                    functionFriendlyName = "Currency Conversions";
                    storedProcedureName = "[dbo].[spGetAllCurrencyConversion]";
                    break;
                case "Customer":
                    dataSortingColumnName = "Customer Id";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Customer Id";
                    dataSubjectFriendlyName = "Customer";
                    functionFriendlyName = "Customers";
                    storedProcedureName = "[dbo].[spGetAllCustomer]";
                    break;
                case "CustomerContact":
                    dataSortingColumnName = "Customer Contact Id";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Customer Contact Id";
                    dataSubjectFriendlyName = "Customer Contact";
                    dataSubjectParentIdentityId = "customerId;";
                    functionFriendlyName = "Customer Contacts";
                    storedProcedureName = "[dbo].[spGetAllCustomerContactForCustomer]";
                    break;
                case "CustomerLeadNote":
                    dataSortingColumnName = "Customer Lead Note";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Customer Lead Note Id";
                    dataSubjectFriendlyName = "Customer Lead Note";
                    functionFriendlyName = "Customer Lead Notes";
                    storedProcedureName = "[dbo].[spGetAllNoteForCustomerLead]";
                    break;
                case "CustomerLeadNoteType":
                    dataSortingColumnName = "Customer Lead Note Type";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Customer Lead Note Type Id";
                    dataSubjectFriendlyName = "Customer Lead Note Type";
                    functionFriendlyName = "Customer Lead Note Types";
                    storedProcedureName = "[dbo].[spGetAllCustomerLeadNoteType]";
                    break;
                case "CustomerLeadStatus":
                    dataSortingColumnName = "Customer Lead Status";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Customer Lead Status Id";
                    dataSubjectFriendlyName = "Customer Lead Status";
                    functionFriendlyName = "Customer Lead Statuses";
                    storedProcedureName = "[dbo].[spGetAllCustomerLeadStatus]";
                    break;
                case "CustomerLeadType":
                    dataSortingColumnName = "Customer Lead Type";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Customer Lead Type Id";
                    dataSubjectFriendlyName = "Customer Lead Type";
                    functionFriendlyName = "Customer Lead Types";
                    storedProcedureName = "[dbo].[spGetAllCustomerLeadType]";
                    break;
                case "CustomerNote":
                    dataSortingColumnName = "Customer Note";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Customer Note Id";
                    dataSubjectFriendlyName = "Customer Note";
                    functionFriendlyName = "Customer Notes";
                    storedProcedureName = "[dbo].[spGetAllNoteForCustomer]";
                    break;
                case "CustomerNoteType":
                    dataSortingColumnName = "Customer Note Type";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Customer Note Type Id";
                    dataSubjectFriendlyName = "Customer Note Type";
                    functionFriendlyName = "Customer Note Types";
                    storedProcedureName = "[dbo].[spGetAllCustomerNoteType]";
                    break;
                case "CustomerTier":
                    dataSortingColumnName = "Customer Tier Description";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Customer Tier Id";
                    dataSubjectFriendlyName = "Customer Tier";
                    functionFriendlyName = "Customer Tiers";
                    storedProcedureName = "[dbo].[spGetAllCustomerTier]";
                    break;
                case "CustomerType":
                    dataSortingColumnName = "Customer Type";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Customer Type Id";
                    dataSubjectFriendlyName = "Customer Type";
                    functionFriendlyName = "Customer Types";
                    storedProcedureName = "[dbo].[spGetAllCustomerType]";
                    break;
                case "DeliveryMethod":
                    dataSortingColumnName = "Delivery Method";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Delivery Method Id";
                    dataSubjectFriendlyName = "Delivery Method";
                    functionFriendlyName = "Delivery Methods";
                    storedProcedureName = "[dbo].[spGetAllDeliveryMethod]";
                    break;
                case "HTMLTemplate":
                    dataSortingColumnName = "HTML Template";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "HTML Template Id";
                    dataSubjectFriendlyName = "HTML Template";
                    functionFriendlyName = "HTML Templates";
                    storedProcedureName = "[dbo].[spGetAllHTMLTemplateTypeForCompanyConfiguration]";
                    break;
                case "HTMLTemplateType":
                    dataSortingColumnName = "HTML Template Type";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "HTML Template Type Id";
                    dataSubjectFriendlyName = "HTML Template Type";
                    functionFriendlyName = "HTML Template Types";
                    storedProcedureName = "[dbo].[spGetAllHTMLTemplateType]";
                    break;
                case "MarketingCampaign":
                    dataSortingColumnName = "Marketing Campaign Id";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Marketing Campaign Id";
                    dataSubjectFriendlyName = "Marketing Campaign";
                    functionFriendlyName = "Marketing Campaigns";
                    storedProcedureName = "[dbo].[spGetAllMarketingCampaign]";
                    break;
                case "MarketingCampaignStatus":
                    dataSortingColumnName = "Marketing Campaign Status Id";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Marketing Campaign Status Id";
                    dataSubjectFriendlyName = "Marketing Campaign Status";
                    functionFriendlyName = "Marketing Campaign Statuses";
                    storedProcedureName = "[dbo].[spGetAllMarketingCampaignStatus]";
                    break;
                case "MarketingCampaignType":
                    dataSortingColumnName = "Marketing Campaign Type Id";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Marketing Campaign Type Id";
                    dataSubjectFriendlyName = "Marketing Campaign Type";
                    functionFriendlyName = "Marketing Campaign Types";
                    storedProcedureName = "[dbo].[spGetAllMarketingCampaignType]";
                    break;
                case "MarketingChannel":
                    dataSortingColumnName = "Marketing Channel Id";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Marketing Channel Id";
                    dataSubjectFriendlyName = "Marketing Channel";
                    functionFriendlyName = "Marketing Channelss";
                    storedProcedureName = "[dbo].[spGetAllMarketingChannel]";
                    break;
                case "Order":
                    dataSortingColumnName = "Order Id";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Order Id";
                    dataSubjectFriendlyName = "Order";
                    functionFriendlyName = "Orders";
                    storedProcedureName = "[dbo].[spGetAllOrder]";
                    break;
                case "OrderLineItemStatus":
                    dataSortingColumnName = "Order Line Item Status";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Order Line Item Status Id";
                    dataSubjectFriendlyName = "Order Line Item Status";
                    functionFriendlyName = "Order Line Item Statuses";
                    storedProcedureName = "[dbo].[spGetAllOrderLineItemStatus]";
                    break;
                case "OrderPaymentStatus":
                    dataSortingColumnName = "Order Payment Status";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Order Payment Status Id";
                    dataSubjectFriendlyName = "Order Payment Status";
                    functionFriendlyName = "Order Payment Statuses";
                    storedProcedureName = "[dbo].[spGetAllOrderPaymentStatus]";
                    break;
                case "OrderStatus":
                    dataSortingColumnName = "Order Status";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Order Status Id";
                    dataSubjectFriendlyName = "Order Status";
                    functionFriendlyName = "Order Statuses";
                    storedProcedureName = "[dbo].[spGetAllOrderStatus]";
                    break;
                case "OrderType":
                    dataSortingColumnName = "Order Type";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Order Type Id";
                    dataSubjectFriendlyName = "Order Type";
                    functionFriendlyName = "Order Types";
                    storedProcedureName = "[dbo].[spGetAllOrderType]";
                    break;
                case "PaymentMethod":
                    dataSortingColumnName = "Payment Method";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Payment Method Id";
                    dataSubjectFriendlyName = "Payment Method";
                    functionFriendlyName = "Payment Methods";
                    storedProcedureName = "[dbo].[spGetAllPaymentMethod]";
                    break;
                case "Product":
                    dataSortingColumnName = "Product Name";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Product Id";
                    dataSubjectFriendlyName = "Product";
                    functionFriendlyName = "Products";
                    storedProcedureName = "[dbo].[spGetAllProduct]";
                    break;
                case "ProductCategory":
                    dataSortingColumnName = "Product Category";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Product Category Id";
                    dataSubjectFriendlyName = "Product Category";
                    functionFriendlyName = "Product Categories";
                    storedProcedureName = "[dbo].[spGetAllProductCategory]";
                    break;
                case "ProductFamily":
                    dataSortingColumnName = "Product Family";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Product Family Id";
                    dataSubjectFriendlyName = "Product Family";
                    functionFriendlyName = "Product Families";
                    storedProcedureName = "[dbo].[spGetAllProductFamily]";
                    break;
                case "ProductNote":
                    dataSortingColumnName = "Product Note";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Product Note Id";
                    dataSubjectFriendlyName = "Product Note";
                    functionFriendlyName = "Product Notes";
                    storedProcedureName = "[dbo].[spGetAllNoteForProduct]";
                    break;
                case "ProductNoteType":
                    dataSortingColumnName = "Product Note Type";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Product Note Type Id";
                    dataSubjectFriendlyName = "Product Note Type";
                    functionFriendlyName = "Product Note Types";
                    storedProcedureName = "[dbo].[spGetAllProductNoteType]";
                    break;
                case "ProductSubCategory":
                    dataSortingColumnName = "Product Sub Category";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Product Sub Category Id";
                    dataSubjectFriendlyName = "Product Sub Category";
                    functionFriendlyName = "Product Sub Categories";
                    storedProcedureName = "[dbo].[spGetAllProductSubCategory]";
                    break;
                case "PromotionTargetType":
                    dataSortingColumnName = "Promotion Target Type";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Promotion Target Type Id";
                    dataSubjectFriendlyName = "Promotion Target Type";
                    functionFriendlyName = "Promotion Target Types";
                    storedProcedureName = "[dbo].[spGetAllPromotionTargetType]";
                    break;
                case "PromotionType":
                    dataSortingColumnName = "Promotion Type";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Promotion Type Id";
                    dataSubjectFriendlyName = "Promotion Type";
                    functionFriendlyName = "Promotion Types";
                    storedProcedureName = "[dbo].[spGetAllPromotionType]";
                    break;
                case "SalesRegion":
                    dataSortingColumnName = "Sales Region";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Sales Region Id";
                    dataSubjectFriendlyName = "Sales Region";
                    functionFriendlyName = "Sales Regions";
                    storedProcedureName = "[dbo].[spGetAllSalesRegion]";
                    break;
                case "SalesSubRegion":
                    dataSortingColumnName = "Sales Sub Region";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Sales Sub Region Id";
                    dataSubjectFriendlyName = "Sales Sub Region";
                    functionFriendlyName = "Sales Sub Regions";
                    storedProcedureName = "[dbo].[spGetAllSalesSubRegion]";
                    break;
                case "Supplier":
                    dataSortingColumnName = "Supplier Name";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Supplier Id";
                    dataSubjectFriendlyName = "Supplier";
                    functionFriendlyName = "Suppliers";
                    storedProcedureName = "[dbo].[spGetAllSupplier]";
                    break;
                case "SupplierContact":
                    dataSortingColumnName = "Supplier Contact Id";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Supplier Contact Id";
                    dataSubjectFriendlyName = "Supplier Contact";
                    dataSubjectParentIdentityId = "supplierId;";
                    functionFriendlyName = "Supplier Contacts";
                    storedProcedureName = "[dbo].[spGetAllSupplierContactForSupplier]";
                    break;
                case "SupplierNote":
                    dataSortingColumnName = "Supplier Note";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Supplier Note Id";
                    dataSubjectFriendlyName = "Supplier Note";
                    functionFriendlyName = "Supplier Notes";
                    storedProcedureName = "[dbo].[spGetAllNoteForSupplier]";
                    break;
                case "SupplierNoteType":
                    dataSortingColumnName = "Supplier Note Type";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Supplier Note Type Id";
                    dataSubjectFriendlyName = "Supplier Note Type";
                    functionFriendlyName = "Supplier Note Types";
                    storedProcedureName = "[dbo].[spGetAllSupplierNoteType]";
                    break;
                case "SupplierOrder":
                    dataSortingColumnName = "Supplier Order Id";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Supplier Order Id";
                    dataSubjectFriendlyName = "Supplier Order";
                    functionFriendlyName = "Supplier Orders";
                    storedProcedureName = "[dbo].[spGetAllSupplierOrder]";
                    break;
                case "SupplierOrderLineItemStatus":
                    dataSortingColumnName = "Supplier Order Line Item Status";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Supplier Order Line Item Status Id";
                    dataSubjectFriendlyName = "Supplier Order Line Item Status";
                    functionFriendlyName = "Supplier Order Line Item Statuses";
                    storedProcedureName = "[dbo].[spGetAllSupplierOrderLineItemStatus]";
                    break;
                case "SupplierOrderPaymentStatus":
                    dataSortingColumnName = "Supplier Order Payment Status";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Supplier Order Payment Status Id";
                    dataSubjectFriendlyName = "Supplier Order Payment Status";
                    functionFriendlyName = "Supplier Order Payment Statuses";
                    storedProcedureName = "[dbo].[spGetAllSupplierOrderPaymentStatus]";
                    break;
                case "SupplierOrderStatus":
                    dataSortingColumnName = "Supplier Order Status";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Supplier Order Status Id";
                    dataSubjectFriendlyName = "Supplier Order Status";
                    functionFriendlyName = "Supplier Order Statuses";
                    storedProcedureName = "[dbo].[spGetAllSupplierOrderStatus]";
                    break;
                case "TaxProfile":
                    dataSortingColumnName = "Tax Profile";
                    dataSortingColumnOrder = "ASC";
                    dataSubjectIdentityColumn = "Tax Profile Id";
                    dataSubjectFriendlyName = "Tax Profile";
                    functionFriendlyName = "Tax Profiles";
                    storedProcedureName = "[dbo].[spGetAllTaxProfile]";
                    break;
                default:
                    this.Text = functionTitle;
                    ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Module.Function.NotImplemented", functionTitle);
                    break;
            }

            this.Text = $"{applicationTitlePrefix}{viewAllPrefix}{functionFriendlyName}";
            viewAllDataTitleLabel.Text = $"{viewAllPrefix}{functionFriendlyName}";
        }

        private async Task PopulateDataGrid_Load()
        {
            if (_databaseConnectionSettings == null)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Database.Connection.SettingsNotLoaded");
                return;
            }

            try
            {
                DataTable? dataTable;

                if (_dataSubjectFilterId != null)
                {
                    var parameters = new[]
                    {
                        new Parameter
                        {
                            ParameterName = $"@{dataSubjectParentIdentityId}",
                            ParameterValue = dataSubjectParentIdentityId
                        }
                    };

                    dataTable = await DBInterface.ExecuteSelectStoredProcedureAsync(storedProcedureName, parameters.ToArray(), dataSubjectFriendlyName, _databaseConnectionSettings.DatabaseConnectionString);
                }

                else
                {
                    dataTable = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubjectFriendlyName, _databaseConnectionSettings.DatabaseConnectionString);
                }

                if (dataTable.Rows.Count == 0)
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Information.NoDataFound", functionFriendlyName);
                }
                else
                {
                    dataTable.DefaultView.Sort = $"{dataSortingColumnName} {dataSortingColumnOrder}";
                    viewAllDataDataGridView.AutoGenerateColumns = true;
                    viewAllDataDataGridView.DataSource = dataTable;
                    viewAllDataDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    if (viewAllDataDataGridView.Columns.Contains("Details"))
                    {
                        viewAllDataDataGridView.Columns.Remove("Details");
                    }
                    DataGridViewLinkColumn dataDetailLink = new DataGridViewLinkColumn
                    {
                        HeaderText = "Details",
                        Text = $"View {dataSubjectFriendlyName} Details",
                        UseColumnTextForLinkValue = true,
                        Name = "Details"
                    };
                    viewAllDataDataGridView.Columns.Add(dataDetailLink);
                }
            }
            catch (Exception ex)
            {
                ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Data.Retrieval", functionFriendlyName, ex.Message);
            }
        }

        private void viewAllDataQuickFilterTextbox_TextChanged(object sender, EventArgs e)
        {
            if (viewAllDataDataGridView.DataSource is DataTable dataTable)
            {
                string filterText = viewAllDataQuickFilterTextbox.Text.Replace("'", "''");
                if (string.IsNullOrWhiteSpace(filterText))
                {
                    dataTable.DefaultView.RowFilter = string.Empty;
                }
                else
                {
                    var filterConditions = dataTable.Columns
                        .Cast<DataColumn>()
                        .Where(col =>
                            col.DataType == typeof(string) ||
                            col.DataType == typeof(object) ||
                            col.DataType == typeof(Guid))
                        .Select(col =>
                            $"CONVERT([{col.ColumnName}], 'System.String') LIKE '%{filterText}%'"
                        );
                    dataTable.DefaultView.RowFilter = string.Join(" OR ", filterConditions);
                }
            }
        }

        private void viewAllDataDataGridView_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == viewAllDataDataGridView.Columns["Details"].Index && e.RowIndex >= 0)
            {
                try
                {
                    if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                    {
                        switch (_functionTitle)
                        {
                            case "AccountManager":
                                Guid accountManagerId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                AccountManagerDetail accountManagerDetail = new AccountManagerDetail(accountManagerId);
                                accountManagerDetail.Show();
                                break;
                            case "CompanyConfiguration":
                                Guid companyConfigurationId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                CompanyConfigurationDetail companyConfigurationDetail = new CompanyConfigurationDetail(companyConfigurationId);
                                companyConfigurationDetail.Show();
                                break;
                            case "Country":
                                Guid countryId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                CountryDetail countryDetail = new CountryDetail(countryId);
                                countryDetail.Show();
                                break;
                            case "CountryTranslation":
                                Guid countryTranslationId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                CountryTranslationDetail countryTranslationDetail = new CountryTranslationDetail(countryTranslationId);
                                countryTranslationDetail.Show();
                                break;
                            case "Currency":
                                Guid currencyId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                CurrencyDetail currencyDetail = new CurrencyDetail(currencyId);
                                currencyDetail.Show();
                                break;
                            case "CurrencyConversion":
                                Guid currencyConversionId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                CurrencyConversionDetail currencyConversionDetail = new CurrencyConversionDetail(currencyConversionId);
                                currencyConversionDetail.Show();
                                break;
                            case "Customer":
                                Guid customerId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                CustomerDetail customerDetail = new CustomerDetail(customerId);
                                customerDetail.Show();
                                break;
                            case "CustomerContact":
                                Guid customerContactId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                ContactDetail contactDetailCustomer = new ContactDetail("Customer", customerContactId);
                                contactDetailCustomer.Show();
                                break;
                            case "CustomerLeadNoteType":
                                Guid customerLeadNoteTypeId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailCustomerLeadNoteType = new MasterDataSimpleDetail(customerLeadNoteTypeId, _functionTitle, "CustomerManagement");
                                masterDataSimpleDetailCustomerLeadNoteType.Show();
                                break;
                            case "CustomerLeadStatus":
                                Guid customerLeadStatusId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailCustomerLeadStatus = new MasterDataSimpleDetail(customerLeadStatusId, _functionTitle, "CustomerManagement");
                                masterDataSimpleDetailCustomerLeadStatus.Show();
                                break;
                            case "CustomerLeadType":
                                Guid customerLeadTypeId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataEnhancedDetail masterDataEnhancedDetailCustomerLeadType = new MasterDataEnhancedDetail(customerLeadTypeId, _functionTitle, "CustomerManagement");
                                masterDataEnhancedDetailCustomerLeadType.Show();
                                break;
                            case "CustomerNoteType":
                                Guid customerNoteTypeId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailCustomerNoteType = new MasterDataSimpleDetail(customerNoteTypeId, _functionTitle, "CustomerManagement");
                                masterDataSimpleDetailCustomerNoteType.Show();
                                break;
                            case "CustomerTier":
                                Guid customerTierId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                CustomerTierDetail customerTierDetail = new CustomerTierDetail(customerTierId);
                                customerTierDetail.Show();
                                break;
                            case "CustomerType":
                                Guid customerTypeId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataEnhancedDetail masterDataEnhancedDetailCustomerType = new MasterDataEnhancedDetail(customerTypeId, _functionTitle, "CustomerManagement");
                                masterDataEnhancedDetailCustomerType.Show();
                                break;
                            case "DeliveryMethod":
                                Guid deliveryMethodId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                DeliveryMethodDetail deliveryMethodDetail = new DeliveryMethodDetail(deliveryMethodId);
                                deliveryMethodDetail.Show();
                                break;
                            case "HTMLTemplate":
                                Guid htmlTemplateId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                HTMLTemplateDetail htmlTemplateDetail = new HTMLTemplateDetail(htmlTemplateId);
                                htmlTemplateDetail.Show();
                                break;
                            case "HTMLTemplateType":
                                Guid htmlTemplateTypeId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailHTMLTemplateType = new MasterDataSimpleDetail(htmlTemplateTypeId, _functionTitle, "CompanyManagement");
                                masterDataSimpleDetailHTMLTemplateType.Show();
                                break;
                            case "MarketingCampaign":
                                Guid marketingCampaignId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MarketingCampaignDetail marketingCampaignDetail = new MarketingCampaignDetail(marketingCampaignId);
                                marketingCampaignDetail.Show();
                                break;
                            case "MarketingCampaignStatus":
                                Guid marketingCampaignStatusId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailMarketingCampaignStatus = new MasterDataSimpleDetail(marketingCampaignStatusId, _functionTitle, "MarketingManagement");
                                masterDataSimpleDetailMarketingCampaignStatus.Show();
                                break;
                            case "MarketingCampaignType":
                                Guid marketingCampaignTypeId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailMarketingCampaignType = new MasterDataSimpleDetail(marketingCampaignTypeId, _functionTitle, "MarketingManagement");
                                masterDataSimpleDetailMarketingCampaignType.Show();
                                break;
                            case "MarketingChannel":
                                Guid marketingChannelId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailMarketingChannel = new MasterDataSimpleDetail(marketingChannelId, _functionTitle, "MarketingManagement");
                                masterDataSimpleDetailMarketingChannel.Show();
                                break;
                            case "Order":
                                Guid orderId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                OrderDetail orderDetail = new OrderDetail(orderId);
                                orderDetail.Show();
                                break;
                            case "OrderLineItemStatus":
                                Guid orderLineItemStatusId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailOrderLineItemStatus = new MasterDataSimpleDetail(orderLineItemStatusId, _functionTitle, "OrderManagement");
                                masterDataSimpleDetailOrderLineItemStatus.Show();
                                break;
                            case "OrderPaymentStatus":
                                Guid orderPaymentStatusId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailOrderPaymentStatus = new MasterDataSimpleDetail(orderPaymentStatusId, _functionTitle, "OrderManagement");
                                masterDataSimpleDetailOrderPaymentStatus.Show();
                                break;
                            case "OrderStatus":
                                Guid orderStatusId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailOrderStatus = new MasterDataSimpleDetail(orderStatusId, _functionTitle, "OrderManagement");
                                masterDataSimpleDetailOrderStatus.Show();
                                break;
                            case "OrderType":
                                Guid orderTypeId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailOrderType = new MasterDataSimpleDetail(orderTypeId, _functionTitle, "OrderManagement");
                                masterDataSimpleDetailOrderType.Show();
                                break;
                            case "PaymentMethod":
                                Guid paymentMethodId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailPaymentMethod = new MasterDataSimpleDetail(paymentMethodId, _functionTitle, "CompanyManagement");
                                masterDataSimpleDetailPaymentMethod.Show();
                                break;
                            case "Product":
                                Guid productId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                ProductDetail productDetail = new ProductDetail(productId);
                                productDetail.Show();
                                break;
                            case "ProductCategory":
                                Guid productCategoryId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailProductCategory = new MasterDataSimpleDetail(productCategoryId, _functionTitle, "ProductManagement");
                                masterDataSimpleDetailProductCategory.Show();
                                break;
                            case "ProductFamily":
                                Guid productFamilyId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailProductFamily = new MasterDataSimpleDetail(productFamilyId, _functionTitle, "ProductManagement");
                                masterDataSimpleDetailProductFamily.Show();
                                break;
                            case "ProductNoteType":
                                Guid productNoteTypeId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailProductNoteType = new MasterDataSimpleDetail(productNoteTypeId, _functionTitle, "ProductManagement");
                                masterDataSimpleDetailProductNoteType.Show();
                                break;
                            case "ProductSubCategory":
                                Guid productSubCategoryId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataAdvancedDetail masterDataAdvancedDetailProductSubCategory = new MasterDataAdvancedDetail(productSubCategoryId, _functionTitle, "ProductManagement");
                                masterDataAdvancedDetailProductSubCategory.Show();
                                break;
                            case "PromotionTargetType":
                                Guid promotionTargetTypeId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataEnhancedDetail masterDataEnhancedDetailPromotionTargetType = new MasterDataEnhancedDetail(promotionTargetTypeId, _functionTitle, "MarketingManagement");
                                masterDataEnhancedDetailPromotionTargetType.Show();
                                break;
                            case "PromotionType":
                                Guid promotionTypeId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailPromotionType = new MasterDataSimpleDetail(promotionTypeId, _functionTitle, "MarketingManagement");
                                masterDataSimpleDetailPromotionType.Show();
                                break;
                            case "SalesRegion":
                                Guid salesRegionId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailSalesRegion = new MasterDataSimpleDetail(salesRegionId, _functionTitle, "CompanyManagement");
                                masterDataSimpleDetailSalesRegion.Show();
                                break;
                            case "SalesSubRegion":
                                Guid salesSubRegionId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataAdvancedDetail masterDataAdvancedDetailSalesSubRegion = new MasterDataAdvancedDetail(salesSubRegionId, _functionTitle, "CompanyManagement");
                                masterDataAdvancedDetailSalesSubRegion.Show();
                                break;
                            case "Supplier":
                                Guid supplierId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                SupplierDetail supplierDetail = new SupplierDetail(supplierId);
                                supplierDetail.Show();
                                break;
                            case "SupplierContact":
                                Guid supplierContactId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                ContactDetail contactDetailSupplier = new ContactDetail("Supplier", supplierContactId);
                                contactDetailSupplier.Show();
                                break;
                            case "SupplierNoteType":
                                Guid supplierNoteTypeId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailSupplierNoteType = new MasterDataSimpleDetail(supplierNoteTypeId, _functionTitle, "SupplierManagement");
                                masterDataSimpleDetailSupplierNoteType.Show();
                                break;
                            case "SupplierOrder":
                                Guid supplierOrderId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                SupplierOrderDetail supplierOrderDetail = new SupplierOrderDetail(supplierOrderId);
                                supplierOrderDetail.Show();
                                break;
                            case "SupplierOrderLineItemStatus":
                                Guid supplierOrderLineItemStatusId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailSupplierOrderLineItemStatus = new MasterDataSimpleDetail(supplierOrderLineItemStatusId, _functionTitle, "SupplierManagement");
                                masterDataSimpleDetailSupplierOrderLineItemStatus.Show();
                                break;
                            case "SupplierOrderPaymentStatus":
                                Guid supplierOrderPaymentStatusId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailSupplierOrderPaymentStatus = new MasterDataSimpleDetail(supplierOrderPaymentStatusId, _functionTitle, "SupplierManagement");
                                masterDataSimpleDetailSupplierOrderPaymentStatus.Show();
                                break;
                            case "SupplierOrderStatus":
                                Guid supplierOrderStatusId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataSimpleDetail masterDataSimpleDetailSupplierOrderStatus = new MasterDataSimpleDetail(supplierOrderStatusId, _functionTitle, "SupplierManagement");
                                masterDataSimpleDetailSupplierOrderStatus.Show();
                                break;
                            case "TaxProfile":
                                Guid taxProfileId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                TaxProfileDetail taxProfileDetail = new TaxProfileDetail(taxProfileId);
                                taxProfileDetail.Show();
                                break;
                            default:
                                ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Module.Function.NotImplemented", _functionTitle);
                                break;
                        }
                    }
                    else
                    {
                        ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Data.IdColumnNotFound", dataSubjectIdentityColumn);
                    }
                }
                catch (Exception ex)
                {
                    ErrorMessageService errorMessageService = new ErrorMessageService(AppConfiguration.Instance,"Error.Data.Retrieval", dataSubjectFriendlyName, ex.Message);
                }
            }
        }

        private void viewAllDataExportCSVButton_Click(object sender, EventArgs e)
        {
            var exportDataGridView = new DataGridView();

            foreach (DataGridViewColumn col in viewAllDataDataGridView.Columns)
            {
                if (col.Name != "Details")
                {
                    exportDataGridView.Columns.Add((DataGridViewColumn)col.Clone());
                }
            }

            if (viewAllDataDataGridView.DataSource is DataTable dataTable)
            {
                DataView filteredView = dataTable.DefaultView;
                foreach (DataRowView rowView in filteredView)
                {
                    var newRow = new DataGridViewRow();
                    foreach (DataGridViewColumn col in exportDataGridView.Columns)
                    {
                        var cell = new DataGridViewTextBoxCell();
                        cell.Value = rowView.Row[col.Name];
                        newRow.Cells.Add(cell);
                    }
                    exportDataGridView.Rows.Add(newRow);
                }
            }
            else
            {
                foreach (DataGridViewRow row in viewAllDataDataGridView.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        var newRow = new DataGridViewRow();
                        foreach (DataGridViewColumn col in exportDataGridView.Columns)
                        {
                            var cell = new DataGridViewTextBoxCell();
                            cell.Value = row.Cells[col.Name].Value;
                            newRow.Cells.Add(cell);
                        }
                        exportDataGridView.Rows.Add(newRow);
                    }
                }
            }

            CSVExportService.ExportDataGridViewToCSV(exportDataGridView, functionFriendlyName);
        }

        private async void viewAllDataRefreshDataButton_Click(object sender, EventArgs e)
        {
            await PopulateDataGrid_Load();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadDatabaseConnectionSettingsAsync();
            await PopulateDataGrid_Load();
        }
    }
}