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
        private string dataSubjectFriendlyName;
        private string dataSubjectIdentityColumn;
        private string functionFriendlyName;
        private string storedProcedureName;
        private readonly string viewAllPrefix = "View All ";

        public ViewAllData(string functionTitle, string moduleGroup)
        {
            InitializeComponent();
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
                    MessageBox.Show($"{functionTitle} not onboarded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            this.Text = $"{applicationTitlePrefix}{viewAllPrefix}{functionFriendlyName}";
            viewAllDataTitleLabel.Text = $"{viewAllPrefix}{functionFriendlyName}";
        }

        private async Task PopulateDataGrid_Load()
        {
            if (_databaseConnectionSettings == null)
            {
                MessageBox.Show("Database connection settings are not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                DataTable? dataTable = await DBInterface.ExecuteSelectStoredProcedureNoParameterAsync(storedProcedureName, dataSubjectFriendlyName, _databaseConnectionSettings.DatabaseConnectionString);

                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("No data found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show($"Failed to load {functionFriendlyName}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        .Where(col => col.DataType == typeof(string) || col.DataType == typeof(object))
                        .Select(col => $"CONVERT([{col.ColumnName}], 'System.String') LIKE '%{filterText}%'");
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
                    switch(_functionTitle)
                    {
                        case "AccountManager":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid accountManagerId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                AccountManagerDetail accountManagerDetail = new AccountManagerDetail(accountManagerId);
                                accountManagerDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "CompanyConfiguration":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid companyConfigurationId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                CompanyConfigurationDetail companyConfigurationDetail = new CompanyConfigurationDetail(companyConfigurationId);
                                companyConfigurationDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "Country":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid countryId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                CountryDetail countryDetail = new CountryDetail(countryId);
                                countryDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "CountryTranslation":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid countryTranslationId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                CountryTranslationDetail countryTranslationDetail = new CountryTranslationDetail(countryTranslationId);
                                countryTranslationDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "Currency":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid currencyId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                CurrencyDetail currencyDetail = new CurrencyDetail(currencyId);
                                currencyDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "CurrencyConversion":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid currencyConversionId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                CurrencyConversionDetail currencyConversionDetail = new CurrencyConversionDetail(currencyConversionId);
                                currencyConversionDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "Customer":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid customerId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                CustomerDetail customerDetail = new CustomerDetail(customerId);
                                customerDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "CustomerLeadNoteType":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid customerLeadNoteTypeId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataSimpleDetail masterDataSimpleDetail = new MasterDataSimpleDetail(customerLeadNoteTypeId, _functionTitle, "CustomerManagement");
                                masterDataSimpleDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "CustomerLeadStatus":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid customerLeadStatusId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataSimpleDetail masterDataSimpleDetail = new MasterDataSimpleDetail(customerLeadStatusId, _functionTitle, "CustomerManagement");
                                masterDataSimpleDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "CustomerLeadType":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid customerLeadTypeId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataEnhancedDetail masterDataEnhancedDetail = new MasterDataEnhancedDetail(customerLeadTypeId, _functionTitle, "CustomerManagement");
                                masterDataEnhancedDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "CustomerNoteType":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid customerNoteTypeId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataSimpleDetail masterDataSimpleDetail = new MasterDataSimpleDetail(customerNoteTypeId, _functionTitle, "CustomerManagement");
                                masterDataSimpleDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "CustomerTier":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid customerTierId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                CustomerTierDetail customerTierDetail = new CustomerTierDetail(customerTierId);
                                customerTierDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "CustomerType":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid customerTypeId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataEnhancedDetail masterDataEnhancedDetail = new MasterDataEnhancedDetail(customerTypeId, _functionTitle, "CustomerManagement");
                                masterDataEnhancedDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "DeliveryMethod":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid deliveryMethodId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                DeliveryMethodDetail deliveryMethodDetail = new DeliveryMethodDetail(deliveryMethodId);
                                deliveryMethodDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "MarketingCampaign":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid marketingCampaignId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MarketingCampaignDetail marketingCampaignDetail = new MarketingCampaignDetail(marketingCampaignId);
                                marketingCampaignDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "MarketingCampaignStatus":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid marketingCampaignStatusId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataSimpleDetail masterDataSimpleDetail = new MasterDataSimpleDetail(marketingCampaignStatusId, _functionTitle, "MarketingManagement");
                                masterDataSimpleDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "MarketingCampaignType":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid marketingCampaignTypeId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataSimpleDetail masterDataSimpleDetail = new MasterDataSimpleDetail(marketingCampaignTypeId, _functionTitle, "MarketingManagement");
                                masterDataSimpleDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "MarketingChannel":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid marketingChannelId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataSimpleDetail masterDataSimpleDetail = new MasterDataSimpleDetail(marketingChannelId, _functionTitle, "MarketingManagement");
                                masterDataSimpleDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "Order":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid orderId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                OrderDetail orderDetail = new OrderDetail(orderId);
                                orderDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "OrderLineItemStatus":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid orderLineItemStatusId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataSimpleDetail masterDataSimpleDetail = new MasterDataSimpleDetail(orderLineItemStatusId, _functionTitle, "OrderManagement");
                                masterDataSimpleDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "OrderPaymentStatus":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid orderPaymentStatusId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataSimpleDetail masterDataSimpleDetail = new MasterDataSimpleDetail(orderPaymentStatusId, _functionTitle, "OrderManagement");
                                masterDataSimpleDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "OrderStatus":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid orderStatusId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataSimpleDetail masterDataSimpleDetail = new MasterDataSimpleDetail(orderStatusId, _functionTitle, "OrderManagement");
                                masterDataSimpleDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "PaymentMethod":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid paymentMethodId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataSimpleDetail masterDataSimpleDetail = new MasterDataSimpleDetail(paymentMethodId, _functionTitle, "CompanyManagement");
                                masterDataSimpleDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "Product":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid productId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                ProductDetail productDetail = new ProductDetail(productId);
                                productDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "ProductCategory":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid productCategoryId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataSimpleDetail masterDataSimpleDetail = new MasterDataSimpleDetail(productCategoryId, _functionTitle, "ProductManagement");
                                masterDataSimpleDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "ProductNoteType":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid productNoteTypeId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataSimpleDetail masterDataSimpleDetail = new MasterDataSimpleDetail(productNoteTypeId, _functionTitle, "ProductManagement");
                                masterDataSimpleDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "ProductSubCategory":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid productSubCategoryId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataAdvancedDetail masterDataAdvancedDetail = new MasterDataAdvancedDetail(productSubCategoryId, _functionTitle, "ProductManagement");
                                masterDataAdvancedDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "PromotionTargetType":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid promotionTargetTypeId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataEnhancedDetail masterDataEnhancedDetail = new MasterDataEnhancedDetail(promotionTargetTypeId, _functionTitle, "MarketingManagement");
                                masterDataEnhancedDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "PromotionType":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid promotionTypeId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataSimpleDetail masterDataSimpleDetail = new MasterDataSimpleDetail(promotionTypeId, _functionTitle, "MarketingManagement");
                                masterDataSimpleDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "SalesRegion":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid salesRegionId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataSimpleDetail masterDataSimpleDetail = new MasterDataSimpleDetail(salesRegionId, _functionTitle, "CompanyManagement");
                                masterDataSimpleDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "SalesSubRegion":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid salesSubRegionId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataAdvancedDetail masterDataAdvancedDetail = new MasterDataAdvancedDetail(salesSubRegionId, _functionTitle, "CompanyManagement");
                                masterDataAdvancedDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "Supplier":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid supplierId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                SupplierDetail supplierDetail = new SupplierDetail(supplierId);
                                supplierDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "SupplierNoteType":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid supplierNoteTypeId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataSimpleDetail masterDataSimpleDetail = new MasterDataSimpleDetail(supplierNoteTypeId, _functionTitle, "SupplierManagement");
                                masterDataSimpleDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "SupplierOrder":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid supplierOrderId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                SupplierOrderDetail supplierOrderDetail = new SupplierOrderDetail(supplierOrderId);
                                supplierOrderDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "SupplierOrderLineItemStatus":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid supplierOrderLineItemStatusId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataSimpleDetail masterDataSimpleDetail = new MasterDataSimpleDetail(supplierOrderLineItemStatusId, _functionTitle, "SupplierManagement");
                                masterDataSimpleDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "SupplierOrderPaymentStatus":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid supplierOrderPaymentStatusId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataSimpleDetail masterDataSimpleDetail = new MasterDataSimpleDetail(supplierOrderPaymentStatusId, _functionTitle, "SupplierManagement");
                                masterDataSimpleDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "SupplierOrderStatus":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid supplierOrderStatusId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                MasterDataSimpleDetail masterDataSimpleDetail = new MasterDataSimpleDetail(supplierOrderStatusId, _functionTitle, "SupplierManagement");
                                masterDataSimpleDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case "TaxProfile":
                            if (viewAllDataDataGridView.Columns.Contains(dataSubjectIdentityColumn))
                            {
                                Guid taxProfileId = (Guid)viewAllDataDataGridView.Rows[e.RowIndex].Cells[dataSubjectIdentityColumn].Value;
                                TaxProfileDetail taxProfileDetail = new TaxProfileDetail(taxProfileId);
                                taxProfileDetail.Show();
                            }
                            else
                            {
                                MessageBox.Show($"{dataSubjectIdentityColumn} column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        default:
                            MessageBox.Show("Function not implemented.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to open {dataSubjectFriendlyName} details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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